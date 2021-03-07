using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Google.Cloud.Speech.V1;
using Google.Cloud.TextToSpeech.V1;
using NAudio.Wave;
using TMPro;

public class SpeechHandler : MonoBehaviour
{
    //private bool microphoneInitialized;

    //private AudioClip microphoneInput;
    //private SpeechClientBuilder speechClientBuilder;

    private TextToSpeechClientBuilder textToSpeechClientBuilder;

    [SerializeField]
    private DialogueFlow dialogueFlow;

    [SerializeField]
    private AudioSource Harold;

    public GameObject captionText;

    public string speechTranscription;

    void Awake()
    {
        speechTranscription = "";
        StreamingMicRecognizeAsync(9999);
    }

    // Update is called once per frame
    void Update()
    {


        if (speechTranscription != "") // if you have something to say, say it!
        {
            StartCoroutine(SpeakOutLoud(speechTranscription));
            speechTranscription = "";
        }
    }

    IEnumerator SpeakOutLoud(string text)
    {
        AudioClip myClip = null;

        string filepath = Path.Combine(Application.dataPath, Speech.OUTPUT_FILENAME);

        textToSpeechClientBuilder = new TextToSpeechClientBuilder
        {
            JsonCredentials = Speech.CONVAI_GCP_CREDENTIALS
        };

        TextToSpeechClient client = textToSpeechClientBuilder.Build();

        SynthesisInput input = new SynthesisInput
        {
            Text = text
        };

        VoiceSelectionParams voiceSelection = new VoiceSelectionParams
        {
            Name = "en-GB-Wavenet-B",
            LanguageCode = "en-US",
            SsmlGender = SsmlVoiceGender.Male
        };

        AudioConfig audioConfig = new AudioConfig
        {
            AudioEncoding = AudioEncoding.Linear16
        };

        SynthesizeSpeechResponse response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);

        // saving the synthesized voice 
        using (FileStream output = File.Create(filepath))
        {
            response.AudioContent.WriteTo(output);
        }

        captionText.GetComponent<TextMeshProUGUI>().text = speechTranscription;

        // creating a new link for Unity to fetch
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)

        {
            filepath = "file:///" + filepath;
        }
        else
        {
            filepath = "file://" + filepath;
        }


        // fetching the saved file
        using (UnityWebRequest unityWebRequest = UnityWebRequestMultimedia.GetAudioClip(filepath, AudioType.WAV))
        {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.isNetworkError
                || unityWebRequest.isHttpError)
            {
                Debug.Log(unityWebRequest.error);
                myClip = null;
            }
            else
            {
                myClip = DownloadHandlerAudioClip.GetContent(unityWebRequest);
            }
        }

        // playing the fetched file

        Harold.clip = myClip;
        Harold.Play();

        //play subtitles
        captionText.SetActive(true);
        yield return new WaitForSeconds(myClip.length + 0.2f);
        captionText.SetActive(false);

    }

    public async Task<string> StreamingMicRecognizeAsync(int seconds)
    {
        string[] candidateLabels = new string[5] { "question about well-being", "greeting", "thanks", "positivity", "question about action" };

        string reply = "";

        SpeechClientBuilder speechClientBuilder = new SpeechClientBuilder
        {
            JsonCredentials = Speech.CONVAI_GCP_CREDENTIALS
        };

        SpeechClient speech = speechClientBuilder.Build();

        var streamingCall = speech.StreamingRecognize();

        // Write the initial request with the config.
        await streamingCall.WriteAsync(
            new StreamingRecognizeRequest()
            {
                StreamingConfig = new StreamingRecognitionConfig()
                {
                    Config = new RecognitionConfig()
                    {
                        Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                        SampleRateHertz = 16000,
                        LanguageCode = "en",
                    },
                    InterimResults = false,
                }
            });

        // Print responses as they arrive.
        Task printResponses = Task.Run(async () =>
        {
            var responseStream = streamingCall.GetResponseStream();
            while (await responseStream.MoveNextAsync())
            {
                StreamingRecognizeResponse response = responseStream.Current;
                foreach (StreamingRecognitionResult result in response.Results)
                {
                    foreach (SpeechRecognitionAlternative alternative in result.Alternatives)
                    {
                        Debug.Log("From ASR API: " + alternative.Transcript);

                        reply = ReplyIntentHandler.ProcessReplyTest(alternative.Transcript, ActionChoice.INTENT_CLASSIFICATION, candidateLabels);

                        Debug.LogError("Reply received by ASR API: " + reply);

                        speechTranscription = reply;
                    }
                }
            }
        });

        // Read from the microphone and stream to API.
        object writeLock = new object();
        bool writeMore = true;
        var waveIn = new WaveInEvent();

        waveIn.DeviceNumber = 0;
        waveIn.WaveFormat = new WaveFormat(16000, 1);
        waveIn.DataAvailable +=
            (object sender, WaveInEventArgs args) =>
            {
                lock (writeLock)
                {
                    if (!writeMore)
                    {
                        return;
                    }

                    streamingCall.WriteAsync(
                        new StreamingRecognizeRequest()
                        {
                            AudioContent = Google.Protobuf.ByteString.CopyFrom(args.Buffer, 0, args.BytesRecorded)
                        }).Wait();
                }
            };
        waveIn.StartRecording();
        Debug.Log("Speak now.");
        await Task.Delay(TimeSpan.FromSeconds(seconds));

        // Stop recording and shut down.
        waveIn.StopRecording();

        lock (writeLock)
        {
            writeMore = false;
        }

        await streamingCall.WriteCompleteAsync();
        await printResponses;
        return reply;
    }
}

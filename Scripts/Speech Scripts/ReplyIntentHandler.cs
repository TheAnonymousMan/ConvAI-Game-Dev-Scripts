using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System.IO;
using Newtonsoft.Json;


// attach to the npc, maybe?
public enum ActionChoice
{
    INTENT_CLASSIFICATION,
    QUESTION_ANSWERING
}

public class IntentClassificationPackage
{
    public string sentence;

    public string[] candidateLabels;
}

public class QuestionAnswererPackage
{
    public bool use_ans_extender = true;

    public string question;

    public string input_context;
}

public class IntentClassificationResult
{
    public string sequence;

    public string[] labels;

    public float[] scores;
}

public class QuestionAnswererResult
{
    public string result;

    public string context;

    public float p;
}

public static class ReplyIntentHandler
{
    public static string ProcessReply(string speechTranscription, ActionChoice actionChoice, string[] intentCandidateLabels)
    {
        // add options of what to do, i.e. intentClassification or questionAnswering
        string jsonPackage, result = null;

        if (actionChoice == ActionChoice.INTENT_CLASSIFICATION)
        {
            IntentClassificationPackage intentClassificationPackage = new IntentClassificationPackage
            {
                sentence = speechTranscription,
                candidateLabels = intentCandidateLabels
            };

            jsonPackage = JsonUtility.ToJson(intentClassificationPackage);
            result = intentClassifierCall(actionChoice, jsonPackage);
        }

        return result;
    }

    public static string ProcessReply(string speechTranscription, ActionChoice actionChoice, string characterContext)
    {
        string jsonPackage, result = null;
        if (actionChoice == ActionChoice.QUESTION_ANSWERING)
        {
            QuestionAnswererPackage questionAnswererPackage = new QuestionAnswererPackage
            {
                use_ans_extender = true,
                question = speechTranscription,
                input_context = characterContext
            };

            jsonPackage = JsonConvert.SerializeObject(questionAnswererPackage);
            result = intentClassifierCall(actionChoice, jsonPackage);
        }

        return result;
    }

    private static string intentClassifierCall(ActionChoice actionChoice, string jsonPackage)
    {
        string result;

        if (actionChoice == ActionChoice.INTENT_CLASSIFICATION)
        {

            //UnityWebRequest www = UnityWebRequest.Put(API.INTENT_CLASSIFIER_URL, jsonPackage);

            //www.method = UnityWebRequest.kHttpVerbPOST;

            //www.SetRequestHeader("content-type", "application/json");
            //www.SetRequestHeader("cache-control", "no-cache");

            //www.SendWebRequest();

            //if (www.result == UnityWebRequest.Result.ConnectionError
            //    || www.result == UnityWebRequest.Result.ProtocolError)
            //{
            //    Debug.LogError(www.error);
            //    result = null;
            //}
            //else
            //{
            //    Debug.Log(www.downloadHandler.text);
            //    result = www.downloadHandler.text;
            //}

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(API.INTENT_CLASSIFIER_URL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonPackage);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            IntentClassificationResult intentClassificationResult = JsonUtility.FromJson<IntentClassificationResult>(result);

            Debug.Log("From intentClassifierCall: " + intentClassificationResult.labels[0]);

            return intentClassificationResult.labels[0];
        }

        if (actionChoice == ActionChoice.QUESTION_ANSWERING)
        {
            //UnityWebRequest www = UnityWebRequest.Post(API.QUESTION_ANSWERER_URL, jsonPackage);
            //www.SetRequestHeader("content-type", "application/json");
            //www.SendWebRequest();

            //if (www.result == UnityWebRequest.Result.ConnectionError
            //    || www.result == UnityWebRequest.Result.ProtocolError)
            //{
            //    Debug.Log(www.error);
            //    result = null;
            //}
            //else
            //{
            //    result = www.downloadHandler.text;
            //}

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(API.INTENT_CLASSIFIER_URL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonPackage);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            QuestionAnswererResult questionAnswererResult = JsonConvert.DeserializeObject<QuestionAnswererResult>(result);

            return questionAnswererResult.result;
        }

        return null;
    }

    public static string ProcessReplyTest(string speechTranscription, ActionChoice actionChoice, string characterContext)
    {
        string reply = null;

        if ((speechTranscription.Contains("hello")
            || speechTranscription.Contains("hi"))
            && speechTranscription.Contains("how")
            && speechTranscription.Contains("are"))
        {
            reply = "Hello, good sir! I am doing well. Thank you.";
        }
        else if (speechTranscription.Contains("hello")
            || speechTranscription.Contains("hi"))
        {
            reply = "Hello, good sir! How are you?";
        }

        if (speechTranscription.Contains("fine")
            || speechTranscription.Contains("good"))
        {
            reply = "Hey! That sounds great!";
        }

        if (speechTranscription.Contains("fine")
            || speechTranscription.Contains("good"))
        {
            reply = "Hey! That sounds great!";
        }

        if (speechTranscription.Contains("how")
            && speechTranscription.Contains("are"))
        {
            reply = "I am doing well. Thank you.";
        }
        // what to do, how to go to next level, what is this

        if ((speechTranscription.Contains("how")
            || speechTranscription.Contains("what"))
            && speechTranscription.Contains("do"))
        {
            reply = "There is nothing to do, to be honest.";
        }

        if (speechTranscription.Contains("what")
            && speechTranscription.Contains("is")
            && speechTranscription.Contains("this"))
        {
            reply = "This is the demo for ConvAI's API."; // perhaps implement SSML so that ConvAI is pronounced properly
        }

        return reply;
    }

    public static string ProcessReplyTest(string speechTranscription, ActionChoice actionChoice, string[] characterLabels)
    {
        string reply = null;

        if ((speechTranscription.Contains("hello")
            || speechTranscription.Contains("hi"))
            && speechTranscription.Contains("how")
            && speechTranscription.Contains("are"))
        {
            reply = "Hello, good sir! I am doing well. Thank you.";
        }
        else if (speechTranscription.Contains("hello")
            || speechTranscription.Contains("hi"))
        {
            reply = "Hello, good sir! How are you?";
        }

        if (speechTranscription.Contains("fine")
            || speechTranscription.Contains("good"))
        {
            reply = "Hey! That sounds great!";
        }

        if (speechTranscription.Contains("fine")
            || speechTranscription.Contains("good"))
        {
            reply = "Hey! That sounds great!";
        }

        if (speechTranscription.Contains("how")
            && speechTranscription.Contains("are"))
        {
            reply = "I am doing well. Thank you.";
        }
        // what to do, how to go to next level, what is this

        if ((speechTranscription.Contains("how")
            || speechTranscription.Contains("what"))
            && speechTranscription.Contains("do"))
        {
            reply = "There is nothing to do, to be honest.";
        }

        if (speechTranscription.Contains("what")
            && speechTranscription.Contains("is")
            && speechTranscription.Contains("this"))
        {
            reply = "This is the demo for ConvAI's API."; // perhaps implement SSML so that ConvAI is pronounced properly
        }

        return reply;
    }
}


/*
var client = new RestClient("http://api.convai.com/zeroshot");
var request = new RestRequest(Method.POST);
request.AddHeader("postman-token", "a91dd4d6-ea7f-c516-40ae-a233f0fa0bdc");
request.AddHeader("cache-control", "no-cache");
request.AddHeader("content-type", "application/json");
request.AddParameter("application/json", "{\r\n    \"sentence\": \"Who are you voting for in 2020\",\r\n    \"candidateLabels\": [\"politics\", \"public health\", \"economics\", \"elections\"]\r\n}", ParameterType.RequestBody);
IRestResponse response = client.Execute(request);
 */
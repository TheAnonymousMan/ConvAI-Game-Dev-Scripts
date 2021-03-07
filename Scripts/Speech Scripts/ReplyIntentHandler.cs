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
    QUESTION_ANSWERING,
    CHITCHAT
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

public class ChitChatPackage
{
    public string userText;

    public double timestamp;
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

public class ChitChatResult
{
    public string userText;

    public double timestamp;

    public string botText;
};

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

    public static string ProcessReply(string speechTranscription, double timeStamp, ActionChoice actionChoice)
    {
        string jsonPackage, result = null;
        if (actionChoice == ActionChoice.CHITCHAT)
        {
            ChitChatPackage chitChatPackage = new ChitChatPackage
            {
                userText = speechTranscription,
                timestamp = timeStamp
            };

            jsonPackage = JsonConvert.SerializeObject(chitChatPackage);
            result = intentClassifierCall(actionChoice, jsonPackage);
        }

        return result;
    }

    private static string intentClassifierCall(ActionChoice actionChoice, string jsonPackage)
    {
        string result;

        if (actionChoice == ActionChoice.INTENT_CLASSIFICATION)
        {
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

        if (actionChoice == ActionChoice.CHITCHAT)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(API.CHIT_CHAT_URL);
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

            Debug.Log("From chitChatCall JSON: " + result);

            ChitChatResult chitChatResult = JsonUtility.FromJson<ChitChatResult>(result);

            Debug.Log("From chitChatCall: " + chitChatResult.botText);

            return chitChatResult.botText;
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

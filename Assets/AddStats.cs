using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class ApiConnector : MonoBehaviour
{
    private string apiUrl = "http://127.0.0.1:5000/addstats";


    void Start()
    {
        PostData();

        var dataToSend = new { score = 123 };
        //StartCoroutine(PostDataToApi(dataToSend));       
    }

    [Serializable]

    public class Quark
    {
        public string score;
    }

    // Update is called once per frame
    void PostData()
    {
        Quark player = new Quark();
        player.score = "228";

        string json = JsonUtility.ToJson(player);
        StartCoroutine(PostRequest("http://127.0.0.1:5000/addstats", json));
    }

    IEnumerator PostRequest(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsoneToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsoneToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Errore While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}

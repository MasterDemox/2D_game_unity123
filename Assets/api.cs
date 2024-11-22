using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ScoreSender : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SendScore(100));
    }

    [System.Serializable]
    public class ScoreData
    {
        public int score;
    }

    IEnumerator SendScore(int score)
    {
        string url = "http://127.0.0.1:5000/stats"; // URL вашего API
        ScoreData scoreData = new ScoreData { score = score };
        string jsonData = JsonUtility.ToJson(scoreData);
        Debug.Log("Sending JSON: " + jsonData); // Отладочное сообщение

        using (UnityWebRequest www = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Score sent successfully!");
            }
        }
    }
}
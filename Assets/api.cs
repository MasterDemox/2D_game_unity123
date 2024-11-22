using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ScoreSender : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SendScore(100));
    }

    IEnumerator SendScore(int score)
    {
        string url = "http://127.0.0.1:5000/api"; // ���������, ��� URL ����������
        string jsonData = JsonUtility.ToJson(new { score = score });

        using (UnityWebRequest www = UnityWebRequest.PostWwwForm(url, jsonData))
        {
            www.method = UnityWebRequest.kHttpVerbPOST;
            www.SetRequestHeader("Content-Type", "application/json");
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            www.downloadHandler = new DownloadHandlerBuffer();

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
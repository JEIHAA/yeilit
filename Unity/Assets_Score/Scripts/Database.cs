using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json;


public class Database : MonoBehaviour
{
    public class DataScore
    {
        public string id { get; set; }
        public int score { get; set; }
    }


    void Start()
    {
        StartCoroutine(AddScoreCoroutine("kch", 5));
        StartCoroutine(GetScoreCoroutine());
        //StartCoroutine(GetScoreCoroutine2());
    }

    private IEnumerator AddScoreCoroutine(string _id, int _score)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", _id);
        form.AddField("score", _score);

        using (UnityWebRequest www =
            UnityWebRequest.Post("http://127.0.0.1/addscore.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
                Debug.Log("AddScore Success : " + _id + "(" + _score + ")");
        }
    }

    private IEnumerator GetScoreCoroutine() {
        using (UnityWebRequest www =
            UnityWebRequest.Post("http://127.0.0.1/getscore.php", "")) {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log(www.error);
            } else {
                Debug.Log(www.downloadHandler.text);
                string data = www.downloadHandler.text;

                List<DataScore> dataScores =
                   JsonConvert.DeserializeObject<List<DataScore>>(data);

                foreach (DataScore dataScore in dataScores) {
                    Debug.Log(dataScore.id + " : " + dataScore.score);
                }
            }
        }
    }

    private IEnumerator GetScoreCoroutine2()
    {
        using (UnityWebRequest www =
            UnityWebRequest.Post("http://127.0.0.1/getscore2.php", ""))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
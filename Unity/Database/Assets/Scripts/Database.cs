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
        StartCoroutine(AddScoreCoroutine("kch1234", 5000));
        StartCoroutine(GetScoreCoroutine());
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

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
        }

        Debug.Log("AddScore Success : " + _id + "(" + _score + ")");
    }

    private IEnumerator GetScoreCoroutine() {
        using (UnityWebRequest www =
            UnityWebRequest.PostWwwForm("http://127.0.0.1/getscore.php", "")) {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
            } else {
                Debug.Log(www.downloadHandler.text);
                string data = www.downloadHandler.text;

                List<DataScore> dataScores = JsonConvert.DeserializeObject<List<DataScore>>(data); // Json이 DataScore 리스트 형으로 만들어서 역직렬화를 해줌

                foreach (DataScore dataScore in dataScores) {
                    Debug.Log(dataScore.id + " : " + dataScore.score);
                }
            }
        }
    }
}
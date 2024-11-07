using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class Login : MonoBehaviour {
    string loginUri = "http://127.0.0.1/login.php";

    void Start() {
        StartCoroutine(LoginCoroutine("kch1234", "kch1234"));

        Debug.Log(System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"));
        Debug.Log(System.DateTime.Now.ToString("yyyy-mm-dd-hh-mm-ss"));
    }

    private IEnumerator LoginCoroutine(
        string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www =
            UnityWebRequest.Post(loginUri, form)) {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log(www.error);
            } else {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
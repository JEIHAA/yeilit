using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class Login : MonoBehaviour {
    private string loginUri = "http://127.0.0.1/login.php";

    void Start() {
        StartCoroutine(LoginCoroutine("Kim", "9999"));

        /*Debug.Log(System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"));
        Debug.Log(System.DateTime.Now.ToString("yyyy-mm-dd-hh-mm-ss"));*/
    }

    private IEnumerator LoginCoroutine( string _username, string _password ) {

        // 패킷 구성
        WWWForm form = new WWWForm();
        //form.AddField("Key", Value);
        //DB에서 찾을 때 Key로 찾음. 짧은게 빠름
        form.AddField("loginUser", _username);
        form.AddField("loginPass", _password);

        //UnityWebRequest.Post(주소, 보낼 내용)
        using (UnityWebRequest www = UnityWebRequest.Post(loginUri, form)) {
            yield return www.SendWebRequest(); // 코루틴임. 통신 결과가 도착할때까지 기다림

            // 옛날방식 이제 안씀 if (www.isNetworkError || www.isHttpError) {
            // 아래처럼 바뀜
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) { 
                Debug.Log(www.error);
            } else {
                // DB로 데이터가 오거나 갈때 문자열로 쭉 나열해서 옴. 직렬화
                // 알아볼 수 있도록 풀어쓰는게 역직렬화
                // JSON은 직렬화, 역직렬화를 자동으로 해줌
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
} 
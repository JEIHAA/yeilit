using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEditor.LightingExplorerTableColumn;

public class SignInManager : MonoBehaviour
{
    private string signInUri = "http://127.0.0.1/signIn.php";
    [SerializeField] private TMP_InputField[] memberData;
    [SerializeField] private TMP_InputField userIDText;

    private static bool hasPermission = false;
    public static bool HasPermission { get { return hasPermission; } set { hasPermission = value; } }
    private static string userID;
    public static string UserID { get { return userID; } set { userID = value; } }

    private void Start()
    {
        SetLoginState();
    }

    public void SignInSubmit()
    {
        if (DataIsNull())
        {
            Debug.Log("모두 입력하세요.");
        }
        else
        {
            StartCoroutine(SignInCoroutine());
        }
    }
    public void SignUpSubmit()
    {
        SceneManager.LoadScene("SignUp");
    }

    private bool DataIsNull()
    {
        for (int i = 0; i < memberData.Length; ++i)
        {
            if (string.IsNullOrEmpty(memberData[i].text))
            {
                Debug.Log(memberData[i].name + "이(가) 비어있습니다.");
                return true;
            }
        }
        return false;
    }

    private void SetLoginState() {
        hasPermission = false;
        userID = "\0";
        /*loginState.hasPermission = false;
        loginState.userID = "\0";*/
    }

    private IEnumerator SignInCoroutine()
    {

        // 패킷 구성
        WWWForm form = new WWWForm();

        TMP_InputField dataType;
        for (int i = 0; i < memberData.Length; ++i)
        {
            dataType = memberData[i];
            form.AddField(dataType.name, dataType.text);
        }

        using (UnityWebRequest www = UnityWebRequest.Post(signInUri, form))
        {
            yield return www.SendWebRequest(); // 코루틴임. 통신 결과가 도착할때까지 기다림

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string state = www.downloadHandler.text;
                if (state == "success")
                {
                    Debug.Log("로그인 성공");
                    hasPermission = true;
                    userID = userIDText.text;
                    //loginState.hasPermission = true;
                    //loginState.userID = memberData[0].text;
                    SceneManager.LoadScene("Index");
                }
                else {
                    Debug.Log("로그인 실패");
                }
            }
        }
    }
}
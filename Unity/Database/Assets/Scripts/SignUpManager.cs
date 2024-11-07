using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using static UnityEditor.LightingExplorerTableColumn;
using static UnityEditor.ShaderData;
using System.Text.RegularExpressions;

public class SignUpManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField[] memberData;

    private string signUpUri = "http://127.0.0.1/signUp.php";

    public void SignUpSubmit() {
        if (IsAllowed())
        {
            StartCoroutine(SignUpCoroutine());
        }
        else {
            Debug.Log("유효하지 않습니다. 다시 입력하세요.");
        }
    }

    private bool IsAllowed() {
        string text;
        bool isAllowed = false;
        for (int i = 0; i < memberData.Length; ++i)
        {
            text = memberData[i].text;

            if (string.IsNullOrEmpty(memberData[i].text)) {
                Debug.Log(memberData[i].name+"은(는) 비워둘 수 없습니다.");
                isAllowed = false;
            }

            if (memberData[i].name.Equals("Id"))
            {
                Regex regexPass = new Regex(@"^[a-zA-Z\d]{3,20}$", RegexOptions.IgnorePatternWhitespace);
                isAllowed = regexPass.IsMatch(text);
                if (!isAllowed) {
                    Debug.Log("적합하지 않은 아이디입니다."); 
                    return isAllowed; 
                }
            }
            if (memberData[i].name.Equals("Pw")) {
                Regex regexPass = new Regex(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[^a-zA-Z\d가-힣])[\w\d\S]{3,20}$", RegexOptions.IgnorePatternWhitespace);
                isAllowed = regexPass.IsMatch(text);
                if (!isAllowed)
                {
                    Debug.Log("적합하지 않은 비밀번호입니다.");
                    return isAllowed;
                }
            }
            if (memberData[i].name.Equals("Email"))
            {
                Regex regexPass = new Regex(@"^(?=.*@)[a-zA-Z\d@]{3,30}$", RegexOptions.IgnorePatternWhitespace);
                isAllowed = regexPass.IsMatch(text);
                if (!isAllowed)
                {
                    Debug.Log("적합하지 않은 이메일입니다.");
                    return isAllowed;
                }
            }
            if (memberData[i].name.Equals("Name"))
            {
                Regex regexPass = new Regex(@"^[가-힣]{2,10}$", RegexOptions.IgnorePatternWhitespace);
                isAllowed = regexPass.IsMatch(text);
                if (!isAllowed)
                {
                    Debug.Log("적합하지 않은 이름입니다.");
                    return isAllowed;
                }
            }
            if (memberData[i].name.Equals("Birth"))
            {
                Regex regexPass = new Regex(@"^\d{8}$", RegexOptions.IgnorePatternWhitespace);
                isAllowed = regexPass.IsMatch(text);
                if (!isAllowed)
                {
                    Debug.Log("생년월일 8자를 입력하세요.");
                    return isAllowed;
                }
            }
            if (memberData[i].name.Equals("PhoneNumber"))
            {
                Regex regexPass = new Regex(@"^\d{11}$", RegexOptions.IgnorePatternWhitespace);
                isAllowed = regexPass.IsMatch(text);
                if (!isAllowed)
                {
                    Debug.Log("-제외 전화번호 11자를 입력하세요.");
                    return isAllowed;
                }
            }
        }
        return isAllowed;
    }

    private IEnumerator SignUpCoroutine()
    {

        // 패킷 구성
        WWWForm form = new WWWForm();

        TMP_InputField dataType;
        for (int i = 0; i< memberData.Length; ++i) {
            dataType = memberData[i];
            form.AddField(dataType.name, dataType.text);
        }

        using (UnityWebRequest www = UnityWebRequest.Post(signUpUri, form))
        {
            yield return www.SendWebRequest(); // 코루틴임. 통신 결과가 도착할때까지 기다림

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string hasPermission = www.downloadHandler.text;
                if (hasPermission == "success")
                {
                    Debug.Log("회원가입이 완료되었습니다.");
                    SceneManager.LoadScene("SignIn");
                }
            }
        }
    }
}

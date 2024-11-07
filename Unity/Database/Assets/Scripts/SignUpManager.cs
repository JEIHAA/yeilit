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
            Debug.Log("��ȿ���� �ʽ��ϴ�. �ٽ� �Է��ϼ���.");
        }
    }

    private bool IsAllowed() {
        string text;
        bool isAllowed = false;
        for (int i = 0; i < memberData.Length; ++i)
        {
            text = memberData[i].text;

            if (string.IsNullOrEmpty(memberData[i].text)) {
                Debug.Log(memberData[i].name+"��(��) ����� �� �����ϴ�.");
                isAllowed = false;
            }

            if (memberData[i].name.Equals("Id"))
            {
                Regex regexPass = new Regex(@"^[a-zA-Z\d]{3,20}$", RegexOptions.IgnorePatternWhitespace);
                isAllowed = regexPass.IsMatch(text);
                if (!isAllowed) {
                    Debug.Log("�������� ���� ���̵��Դϴ�."); 
                    return isAllowed; 
                }
            }
            if (memberData[i].name.Equals("Pw")) {
                Regex regexPass = new Regex(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[^a-zA-Z\d��-�R])[\w\d\S]{3,20}$", RegexOptions.IgnorePatternWhitespace);
                isAllowed = regexPass.IsMatch(text);
                if (!isAllowed)
                {
                    Debug.Log("�������� ���� ��й�ȣ�Դϴ�.");
                    return isAllowed;
                }
            }
            if (memberData[i].name.Equals("Email"))
            {
                Regex regexPass = new Regex(@"^(?=.*@)[a-zA-Z\d@]{3,30}$", RegexOptions.IgnorePatternWhitespace);
                isAllowed = regexPass.IsMatch(text);
                if (!isAllowed)
                {
                    Debug.Log("�������� ���� �̸����Դϴ�.");
                    return isAllowed;
                }
            }
            if (memberData[i].name.Equals("Name"))
            {
                Regex regexPass = new Regex(@"^[��-�R]{2,10}$", RegexOptions.IgnorePatternWhitespace);
                isAllowed = regexPass.IsMatch(text);
                if (!isAllowed)
                {
                    Debug.Log("�������� ���� �̸��Դϴ�.");
                    return isAllowed;
                }
            }
            if (memberData[i].name.Equals("Birth"))
            {
                Regex regexPass = new Regex(@"^\d{8}$", RegexOptions.IgnorePatternWhitespace);
                isAllowed = regexPass.IsMatch(text);
                if (!isAllowed)
                {
                    Debug.Log("������� 8�ڸ� �Է��ϼ���.");
                    return isAllowed;
                }
            }
            if (memberData[i].name.Equals("PhoneNumber"))
            {
                Regex regexPass = new Regex(@"^\d{11}$", RegexOptions.IgnorePatternWhitespace);
                isAllowed = regexPass.IsMatch(text);
                if (!isAllowed)
                {
                    Debug.Log("-���� ��ȭ��ȣ 11�ڸ� �Է��ϼ���.");
                    return isAllowed;
                }
            }
        }
        return isAllowed;
    }

    private IEnumerator SignUpCoroutine()
    {

        // ��Ŷ ����
        WWWForm form = new WWWForm();

        TMP_InputField dataType;
        for (int i = 0; i< memberData.Length; ++i) {
            dataType = memberData[i];
            form.AddField(dataType.name, dataType.text);
        }

        using (UnityWebRequest www = UnityWebRequest.Post(signUpUri, form))
        {
            yield return www.SendWebRequest(); // �ڷ�ƾ��. ��� ����� �����Ҷ����� ��ٸ�

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
                    Debug.Log("ȸ�������� �Ϸ�Ǿ����ϴ�.");
                    SceneManager.LoadScene("SignIn");
                }
            }
        }
    }
}

using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static ChecknPermission;
using static Database;
using static Login_Backup;

public class ChecknPermission : MonoBehaviour
{
    public struct ResultData
    {
        public string id;
        public string pw;
        public string email;
        public string name;
        public string birth;
        public string phoneNumber;
    }
    public struct MemberData
    {
        public string id;
        public string pw;
        public string email;
        public string name;
        public int birth;
        public string phoneNum;
    }
    
    private string getUserDataUri = "http://127.0.0.1/getUserData.php";
    
    [SerializeField] private TextMeshProUGUI userDataText;
    [SerializeField] private Button SignInBtn;

    private void Start()
    {
        Debug.Log("HasPermission: " + IsAllowed());
        if (IsAllowed())
        {
            StartCoroutine(GetUserDataCoroutine());
        }
        else {
            userDataText.text = "허용되지 않은 접근입니다.";
            SetBtnText(IsAllowed());
            SignInBtn.gameObject.SetActive(true);
        }
    }
    private bool IsAllowed()
    {
        return SignInManager.HasPermission;
    }

    private void ShowUserData(ResultData resultData) {
        MemberData memberData;
        StringBuilder sb = new StringBuilder();

        memberData.id = resultData.id;
        memberData.pw = resultData.pw;
        memberData.email = resultData.email;
        memberData.name = resultData.name;
        memberData.birth = int.Parse(resultData.birth);
        memberData.phoneNum = resultData.phoneNumber;

        sb.AppendLine(memberData.id+"님의 정보");
        sb.AppendLine("");
        sb.AppendLine("ID: " + memberData.id);
        sb.AppendLine("Password: " + memberData.pw);
        sb.AppendLine("Email: " + memberData.email);
        sb.AppendLine("Name: " + memberData.name);
        sb.AppendLine("Birth: " + memberData.birth.ToString());
        sb.AppendLine("Phone Number: " + memberData.phoneNum.ToString());
        
        userDataText.text = sb.ToString();
    }

    private void SetBtnText(bool hasPermission) {
        if (hasPermission)
        {
            SignInBtn.GetComponentInChildren<TextMeshProUGUI>().text = "로그아웃";
            SignInBtn.onClick.AddListener(() =>
            {
                SignOut();
            });
        }
        else { 
            SignInBtn.GetComponentInChildren<TextMeshProUGUI>().text = "로그인";
            SignInBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("SignIn");
            });
        }
        
    }

    private void SignOut() {
        SceneManager.LoadScene("SignIn");
        SignInManager.HasPermission = false;
        SignInManager.UserID = "\0";
    }

    private IEnumerator GetUserDataCoroutine()
    {
        WWWForm form = new WWWForm();

        form.AddField("Id", SignInManager.UserID);

        using (UnityWebRequest www = UnityWebRequest.Post(getUserDataUri, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string data = www.downloadHandler.text;
                if (data == "No data") SignOut();
                else
                {
                    ResultData resultData = JsonConvert.DeserializeObject<ResultData>(data);
                    ShowUserData(resultData);
                    SetBtnText(IsAllowed());
                }
            }
        }
    }
}

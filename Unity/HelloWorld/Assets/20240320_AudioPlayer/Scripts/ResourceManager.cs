using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


// Singleton Pattern
// 1. 객체가 무조건 하나일 것
// 2. 어디서나 접근이 가능할 것
// 3. 객체 생성이 불가능할 것
public class ResourceManager
{
    private static ResourceManager instance = null;

    // 객체가 존재하는지 확인하고 null이면 객체 생성
    // 이미 존재하면 만들어져있는 객체를 반환
    public static ResourceManager Instance
    {
        get {
            if (instance == null)
                instance = new ResourceManager();
            return instance;
        }
    }

    // 객체가 하나만 존재해야하기 때문에 객체 생성이 불가능하도록 만들어야함.
    // 문법적으로 객체 생성을 막으려면 생성자 호출이 불가능하게 만들면 됨.
    // 생성자를 private으로 만들어두면 외부에서 해당 클래스의 생성자를 호출할 수 없음.
    private ResourceManager() { }

    private const string audioPath = "Audios\\";
    private Dictionary<string, AudioClip> dicAudioClip = new Dictionary<string, AudioClip>();

    public AudioClip LoadAudioClip(string _fileName) {
        // 실제 파일이 존재하는지 예외처리
        if (dicAudioClip.ContainsKey(_fileName)){
            Debug.Log("Contains: " + _fileName);
            return dicAudioClip[_fileName];
        }

        // 리소스 불러오기
        AudioClip clip = Resources.Load<AudioClip>(audioPath + _fileName);
        // 템플릿으로 생성. 자료형을 다르게 같은 내용의 클래스를 만들면 복사본이 생김

        //AudioClip audio = Resources.Load(_path) as AudioClip; 다른 방법. 권장함
        //AudioClip ac = (AudioClip)Resources.Load(_path); // 명시적 형변환
        // 묵시적, 명시적 형 변환은 자료형을 강제로 변경함. 저장 위치는 같고 읽는 방식을 강제로 변경
        // as는 상속 관계를 확인함.
        // Resources.Load는 무조건 부모형으로 내보내는데 AudioClip으로 형 변환이 가능한지 확인 후에 가능하면 형 변환, 불가능하면 null 반환

        Debug.Log("Add: " + _fileName);
        dicAudioClip.Add(_fileName, clip);
        return clip;

    }
}

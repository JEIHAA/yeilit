using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


// Singleton Pattern
// 1. ��ü�� ������ �ϳ��� ��
// 2. ��𼭳� ������ ������ ��
// 3. ��ü ������ �Ұ����� ��
public class ResourceManager
{
    private static ResourceManager instance = null;

    // ��ü�� �����ϴ��� Ȯ���ϰ� null�̸� ��ü ����
    // �̹� �����ϸ� ��������ִ� ��ü�� ��ȯ
    public static ResourceManager Instance
    {
        get {
            if (instance == null)
                instance = new ResourceManager();
            return instance;
        }
    }

    // ��ü�� �ϳ��� �����ؾ��ϱ� ������ ��ü ������ �Ұ����ϵ��� ��������.
    // ���������� ��ü ������ �������� ������ ȣ���� �Ұ����ϰ� ����� ��.
    // �����ڸ� private���� �����θ� �ܺο��� �ش� Ŭ������ �����ڸ� ȣ���� �� ����.
    private ResourceManager() { }

    private const string audioPath = "Audios\\";
    private Dictionary<string, AudioClip> dicAudioClip = new Dictionary<string, AudioClip>();

    public AudioClip LoadAudioClip(string _fileName) {
        // ���� ������ �����ϴ��� ����ó��
        if (dicAudioClip.ContainsKey(_fileName)){
            Debug.Log("Contains: " + _fileName);
            return dicAudioClip[_fileName];
        }

        // ���ҽ� �ҷ�����
        AudioClip clip = Resources.Load<AudioClip>(audioPath + _fileName);
        // ���ø����� ����. �ڷ����� �ٸ��� ���� ������ Ŭ������ ����� ���纻�� ����

        //AudioClip audio = Resources.Load(_path) as AudioClip; �ٸ� ���. ������
        //AudioClip ac = (AudioClip)Resources.Load(_path); // ����� ����ȯ
        // ������, ����� �� ��ȯ�� �ڷ����� ������ ������. ���� ��ġ�� ���� �д� ����� ������ ����
        // as�� ��� ���踦 Ȯ����.
        // Resources.Load�� ������ �θ������� �������µ� AudioClip���� �� ��ȯ�� �������� Ȯ�� �Ŀ� �����ϸ� �� ��ȯ, �Ұ����ϸ� null ��ȯ

        Debug.Log("Add: " + _fileName);
        dicAudioClip.Add(_fileName, clip);
        return clip;

    }
}

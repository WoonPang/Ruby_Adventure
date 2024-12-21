using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { " �տ� �ִ� ���ô� �����ϴ°� �����̴ϴ�.\n ���� ���ø鼭 ���⸦ �߰��ߴٸ� �ִ��� ��Ƶδ� ���� ��õ�帮�ڽ��ϴ�." });
        talkData.Add(2000, new string[] { " ��񺴵��� �������� �������� �����̴� �� ������.\n �׵��� �������� �� Ȯ���ϸ鼭 �����̴°� ���ڽ��ϴ�." });
        talkData.Add(3000, new string[] { " �� �տ��� ���� ������ ����� ���� �ֱ���.\n ����� �� ������ �����ؼ� �� ������������ �սô�." });
        talkData.Add(4000, new string[] { " �̰����� ���ô��� ���� �����̽��ϴ�.\n �Ʒ��� �ִ� ȯǳ���� ���Ͽ� �̰��� ������ �� �����ʴϴ�.\n �������� ����� ������ ����� �����ϱ� �ٶ�ڽ��ϴ�." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

}

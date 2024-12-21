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
        talkData.Add(1000, new string[] { " 앞에 있는 가시는 조심하는게 좋을겁니다.\n 또한 가시면서 딸기를 발견했다면 최대한 모아두는 것을 추천드리겠습니다." });
        talkData.Add(2000, new string[] { " 경비병들의 움직임이 무작위로 움직이는 것 같군요.\n 그들의 움직임을 잘 확인하면서 움직이는게 좋겠습니다." });
        talkData.Add(3000, new string[] { " 이 앞에는 가시 함정과 경비병이 같이 있군요.\n 어려울 듯 하지만 조심해서 잘 옴직여보도록 합시다." });
        talkData.Add(4000, new string[] { " 이곳까지 오시느라 수고 많으셨습니다.\n 아래에 있는 환풍구를 통하여 이곳을 나가실 수 있으십니다.\n 앞으로의 당신의 여정에 행운이 가득하길 바라겠습니다." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

}

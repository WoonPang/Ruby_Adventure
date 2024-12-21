using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneMove : MonoBehaviour
{
    public void NextGameSceneMove()
    {
        SceneManager.LoadScene("MainPlay");
        Debug.Log("게임을 시작합니다.");
    }
}

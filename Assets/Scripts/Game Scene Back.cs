using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneBack : MonoBehaviour
{
    public void BackGameScene()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("����ȭ������ ���ư��ϴ�.");
    }
}
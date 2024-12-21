using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public GameObject HowToPlay;

    private void Start()
    {
        HowToPlay.SetActive(false);
    }

    void Update()
    {

    }

    public void OnPanel()
    {
        HowToPlay.SetActive(true);
        Debug.Log("���ӹ�� â�� ���ϴ�.");
    }

    public void OffPanel()
    {
        HowToPlay.SetActive(false);
        Debug.Log("���ӹ�� â�� �ݽ��ϴ�.");
    }

    public void GameExit()
    {
        Application.Quit();
        Debug.Log("������ �����մϴ�.");
    }
}

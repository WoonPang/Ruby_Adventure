using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int collectPoint;
    public int HP;
    public RubyMove player;
    public TalkManager talkManager;

    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public GameObject pauseMenu;

    public Image[] UIHP;
    public Text UIPoint;
    public GameObject UIRestartBtn;
    public GameObject Finished;

    void Start()
    {

    }

    void Update()
    {
        UIPoint.text = collectPoint.ToString();

        if (Input.GetButtonDown("Cancel"))
        {
            if (pauseMenu.activeSelf)
                pauseMenu.SetActive(false);
            else
                pauseMenu.SetActive(true);

        }
    }

    public void Action(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            scanObject = scanObj;
            ObjData objData = scanObj.GetComponent<ObjData>();
            Talk(objData.id, objData.isNpc);
        }

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            return;
        }

        if (isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }

        isAction = true;
    }

    public void GameExit()
    {
        Application.Quit();
        Debug.Log("게임을 종료합니다.");
    }

    public void GameClear()
    {
        Time.timeScale = 0;
        Debug.Log("게임 클리어!");
        Finished.SetActive(true);
    }

    public void HPDown()
    {
        if (HP > 1)
        {
            HP--;
            UIHP[HP].color = new Color(0, 0, 0, 0.4f);
        }

        else
        {
            player.OnDie();

            Debug.Log("플레이어가 사망했습니다.");

            UIRestartBtn.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainPlay");
    }
}

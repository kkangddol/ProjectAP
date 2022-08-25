using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    const int PHASETIME = 10;
    const int FIRSTPHASE = 30;
    const int SECONDPHASE = 50;
    const int THIRDPHASE = 80;
    int[] phaseTimes = {30, 50, 80};
    float baseTime = 0;
    int baseIndex = 0;
    public static GameManager instance;
    public ProgressBar progressBar;
    public GameObject[] backGrounds;
    public GameObject[] hpUIs;
    private int playerHp;
    public int PlayerHp
    {
        get {return playerHp;}
        set
        {
            if(value < 0) return;
            playerHp = value;
            StartCoroutine(SetHpUI(value));
            if(value <= 0)
            {
                StartCoroutine(GameEnd(false));
                return;
            }
        }
    }
    private float playingTime = 0;
    public float PlayingTime
    {
        get{ return playingTime;}
        set
        {
            playingTime = value;
            progressBar.SetProgress(value);
            if(value >= baseTime + phaseTimes[baseIndex])
            {
                GamePhase++;
                baseTime = value;
                baseIndex++;
                //playingTime = 0;
            }
        }
    }
    public bool isGameEnd = false;

    private int gamePhase = 1;
    public int GamePhase
    {
        get {return gamePhase;}
        set
        {
            if(value > 3)
            {
                StartCoroutine(GameEnd(true));
                return;
            }
            gamePhase = value;
            RainManager.instance.SetPhase(value);
            SetBackgrounds(value);
        }
    }

    public GameObject gameoverUI;
    public GameObject winUI;
    public GameObject loseUI;

    bool godMode = false;
    public bool GodMode
    {
        get{return godMode;}
        set
        {
            godMode = value;
        }
    }


    public TMPro.TextMeshProUGUI bulletText;

    private int bulletCount = 0;
    public int BulletCount
    {
        get{ return bulletCount; }
        set
        {
            bulletCount = value;
            bulletText.text = value.ToString();
        }
    }

    public GameObject PauseUI;


    private void Awake() {
        Time.timeScale = 1;
        instance = this;
        playerHp = 3;
    }

    private void Update() {
        if(isGameEnd) return;

        PlayingTime += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.P))
        {
            godMode = !godMode;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if(Time.timeScale == 0)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
            PauseUI.SetActive(true);
        }
    }

    public void ReducePlayerHp(int value)
    {
        PlayerHp -= value;
    }

    void SetBackgrounds(int index)
    {
        Debug.Log(index);
        foreach(var back in backGrounds)
        {
            back.SetActive(false);
        }
        switch(index)
        {
            case 1:
            backGrounds[0].SetActive(true);
            break;

            case 2:
            backGrounds[1].SetActive(true);
            break;

            case 3:
            backGrounds[2].SetActive(true);
            break;
        }
    }

    IEnumerator SetHpUI(int value)
    {
        hpUIs[value].GetComponent<Animator>().SetTrigger("Hit");
        yield return new WaitForSeconds(1);
        hpUIs[value].transform.GetChild(0).gameObject.SetActive(false);
    }

    IEnumerator GameEnd(bool isWin)
    {
        isGameEnd = true;

        yield return new WaitForSeconds(1.2f);

        GetComponent<AudioSource>().Stop();

        Time.timeScale = 0;
        gameoverUI.SetActive(true);
        if(isWin)
        {
            winUI.SetActive(true);
            winUI.GetComponent<AudioSource>().Play();
        }   
        else
        {
            loseUI.SetActive(true);
            loseUI.GetComponent<AudioSource>().Play();
        }
            
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

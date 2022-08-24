using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const int PHASETIME = 10;
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
            playerHp = value;
            StartCoroutine(SetHpUI(value));
            if(value <= 0)
            {
                GameEnd();
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
            if(value >= PHASETIME)
            {
                GamePhase++;
                playingTime = 0;
            }
        }
    }
    private bool isGameEnd = false;

    private int gamePhase = 1;
    public int GamePhase
    {
        get {return gamePhase;}
        set
        {
            if(value > 3)
            {
                GameEnd();
                return;
            }
            gamePhase = value;
            SetBackgrounds(value);
        }
    }

    public GameObject gameoverUI;

    private void Awake() {
        Time.timeScale = 1;
        instance = this;
        playerHp = 3;
    }

    private void Update() {
        if(isGameEnd) return;

        PlayingTime += Time.deltaTime;
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

    public void GameEnd()
    {
        isGameEnd = true;
        Time.timeScale = 0;
        gameoverUI.SetActive(true);
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene("GameScene");
    }
}

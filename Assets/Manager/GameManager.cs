using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ProgressBar progressBar;
    private int playerHp;
    private float playingTime = 0;
    public float PlayingTime
    {
        get{ return playingTime;}
        set
        {
            playingTime = value;
            progressBar.SetProgress(value);
            if(value >= 60)
            {
                gamePhase++;
                playingTime = 0;
            }
        }
    }
    private bool isGameEnd = false;

    private int gamePhase = 1;
    private void Awake() {
        instance = this;
        playerHp = 3;
    }

    public void ReducePlayerHp(int value)
    {
        playerHp -= value;
    }

    private void Update() {
        if(isGameEnd) return;

        PlayingTime += Time.deltaTime;
    }
}

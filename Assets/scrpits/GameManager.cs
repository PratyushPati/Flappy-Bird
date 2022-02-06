using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public player player;
    public Text scoretext;
    public int score;
    public GameObject play;
    public GameObject gameoverscreen;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        pause();
    }
    public void pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void Gplay()
    {
        score = 0;
        scoretext.text = score.ToString();

        play.SetActive(false);
        gameoverscreen.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        pipesmovement[] pipes = FindObjectsOfType<pipesmovement>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void gameover()
    {
        gameoverscreen.SetActive(true);
        play.SetActive(true);
        pause();
    }
    public void increaseScore()
    {
        score++;
        scoretext.text = score.ToString();
    }
   
}

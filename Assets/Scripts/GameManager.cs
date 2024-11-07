using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameObject virtualCamera;
    public Player player;
    public Lives lifeDisplayer;
    public GameObject resultPopup;
    public TextMeshProUGUI scoreLabel;

    public float timeLimit = 30;
    public int lives = 3;

    public bool isCleared;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        lifeDisplayer.SetLives(lives);
        isCleared = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;

        scoreLabel.text = "Time Left " + ((int)timeLimit).ToString();
    }

    public void AddTime(float time)
    {
        timeLimit += time;
    }

    public void Die()
    {
        virtualCamera.SetActive(false);

        lives--;
        lifeDisplayer.SetLives(lives);
        Invoke("Restart", 2);
    }

    public void Restart()
    {
        if (lives == 0)
        {
            GameOver();
        }
        else
        {
            virtualCamera.SetActive(true);
            player.Restart();
        }
    }

    public void StageClear()
    {
        isCleared = true;

        resultPopup.SetActive(true);
    }

    public void GameOver()
    {
        isCleared = false;

        resultPopup.SetActive(true);
    }
}

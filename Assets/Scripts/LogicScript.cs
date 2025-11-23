using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Logic Manager of the in-game scene
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverScreen;
    public GameObject scoreObject;
    public GameObject bird;
    public GameObject getReady;
    public GameObject pipeSpawner;
    public AudioSource scoreUp;
    public AudioSource gameOverEffect;
    public AudioSource crash;
    private bool soundPlayed = false;
    private int highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        scoreUp = audioSources[0];
        gameOverEffect = audioSources[1];
        crash = audioSources[2];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void UpdateHighScore()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    public void addScore(int scoreToAdd)
    {
        if (!soundPlayed)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            UpdateHighScore();
            scoreUp.Play();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    //Game over intrface
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        scoreObject.SetActive(false);
        if (!soundPlayed)
        {
            bird.transform.rotation *= Quaternion.Euler(0f, 0f, -90f);
            crash.Play();
            gameOverEffect.Play();
            soundPlayed = true;
        }
    }

    //Start playing
    public void Play()
    {
        bird.SetActive(true);
        pipeSpawner.SetActive(true);
        scoreObject.SetActive(true);
        getReady.SetActive(false);
    }
}

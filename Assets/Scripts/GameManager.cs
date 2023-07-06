using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameStarted;

    public GameObject platformSpawner;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public GameObject gamePlayUI;
    public GameObject menuUI;

    AudioSource audioSource;
    public AudioClip[] gameMusic;

    int score = 0;
    int highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best Score : " + highScore;
    }

    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
    }

    public void GameStart()
    {
        gameStarted = true;
        platformSpawner.SetActive(true);
        gamePlayUI.SetActive(true);
        menuUI.SetActive(false);

        audioSource.clip = gameMusic[1];
        audioSource.Play();

    }

    public void GameOver()
    {
        platformSpawner.SetActive(false);
        gameStarted = false;

        SaveHighScore();

        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }


    public void TapScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void IncrementScore()
    {
        score += 2;
        scoreText.text = score.ToString();

        audioSource.PlayOneShot(gameMusic[2],0.5f);
    }

    void SaveHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}

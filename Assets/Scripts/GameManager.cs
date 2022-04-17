using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted;
    public GameObject platformSpawner;
    public GameObject gamePlayUI;
    public GameObject menuUI;

    public Text scoreText;
    public Text highScoreText;

    AudioSource audioSource;
    public AudioClip[] gameMusic;
    public AudioClip[] backGrounndMusic;

    int score = 0;
    int highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();
 

    }
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore");
        highScoreText.text = "Best Score: " + highScore;
    }

    // Update is called once per frame
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

        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);

        //Play some music
        int bgMusicIdx = Random.Range(0, 3);

        audioSource.clip = backGrounndMusic[bgMusicIdx];
        audioSource.Play(); 
        StartCoroutine("UpdateScore");
        
    }

    public void GameOver()
    {
        platformSpawner.SetActive(false);

        StopCoroutine("UpdateScore");

        SaveHighScore();
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            score++;

            scoreText.text = score.ToString();

            print(score);
        }
    }
    public void IncrementScore()
    {
        score += 5;
        scoreText.text = score.ToString();

        //play sound Effect
        audioSource.PlayOneShot(gameMusic[2], 0.2f);


    }


    void SaveHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            //we already have a highscore
            if (score > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }

        else //Playing for the first time
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}

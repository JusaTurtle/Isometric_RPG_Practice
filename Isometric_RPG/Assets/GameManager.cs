using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public int baseScore;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;
    public GameObject gameOver;

    private void Start()
    {
        gameOver.SetActive(false);
    }

    private void Update()
    {
        if (player != null)
            score = player.dameDealt * baseScore;
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver?.SetActive(true);
        scoreText?.gameObject.SetActive(false);
        if (gameOverScoreText != null)
            gameOverScoreText.text = score.ToString();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextScene()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

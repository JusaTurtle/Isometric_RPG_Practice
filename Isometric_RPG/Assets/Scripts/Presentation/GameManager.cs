using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerPresenter player;
    public int baseScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;
    public GameObject gameOver;
    private int score;

    private void Start()
    {
        gameOver.SetActive(false);
    }

    private void Update() {
        score = player.GetDameDealt() * baseScore;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver?.SetActive(true);
        scoreText?.gameObject.SetActive(false);
        if (gameOverScoreText != null)
            gameOverScoreText.text = score.ToString();
        Time.timeScale = 0f;
    }
}

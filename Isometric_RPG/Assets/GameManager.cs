using UnityEngine;
using TMPro;

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
            score = player.DameDealt * baseScore;
        if (scoreText != null)
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

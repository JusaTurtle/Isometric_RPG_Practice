using UnityEngine;
using TMPro;

public class ScoreDisplayer : MonoBehaviour, Displayable
{
    public TextMeshProUGUI[] scoreText;
    public int baseScore;
    public GameObject gameOverScreen;
    private ScoreManager sm;

    public ScoreManager Manager { get => sm; }

    private void Start()
    {
        sm = new ScoreManager(this)
        {
            baseScore = baseScore
        };
        gameOverScreen.SetActive(false);
    }

    public void Display(string text)
    {
        foreach (TextMeshProUGUI t in scoreText)
        {
            t.text = text;
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
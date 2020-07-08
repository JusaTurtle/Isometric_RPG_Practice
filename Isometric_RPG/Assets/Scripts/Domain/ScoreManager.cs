using UnityEngine;

[System.Serializable]
public class ScoreManager
{
    public int baseScore;
    private Displayable displayer;

    public ScoreManager(ScoreDisplayer scoreDisplayer)
    {
        this.displayer = scoreDisplayer;
    }

    public void UpdateScore(int score) {
        displayer.Display((score * baseScore).ToString());
    }
}

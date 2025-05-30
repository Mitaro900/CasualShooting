using TMPro;
using UnityEngine;

public class InGameUI : UIBase
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = scoreText.text;
    }

    public void OnClickRestartBtn()
    {
        GameManager.Instance.RestartGame();
        gameOverPanel.SetActive(false);
    }

    public void OnClickQuitBtn()
    {
        GameManager.Instance.QuitGame();
    }
}

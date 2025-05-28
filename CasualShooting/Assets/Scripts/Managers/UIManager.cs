using Singleton.Component;
using TMPro;
using UnityEngine;

public class UIManager : SingletonComponent<UIManager>
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;

    #region Singleton
    protected override void AwakeInstance()
    {
        Initialize();
    }

    protected override bool InitInstance()
    {
        return true;
    }

    protected override void ReleaseInstance()
    {
        Destroy(gameObject);
    }
    #endregion

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = scoreText.text;
    }
}

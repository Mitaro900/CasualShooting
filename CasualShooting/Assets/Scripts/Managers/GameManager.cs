using Singleton.Component;
using UnityEngine;

public class GameManager : SingletonComponent<GameManager>
{
    private int score;
    public int difficultyLevel = 1; // 게임 난이도 레벨

    #region Singleton
    protected override void AwakeInstance()
    {
        Initialize();
    }

    protected override bool InitInstance()
    {
        UIManager.Instance.UpdateScore(score);
        return true;
    }

    protected override void ReleaseInstance()
    {
        Destroy(gameObject);
    }
    #endregion

    public void PauseGame(bool _pause)
    {
        if (_pause)
        {
            Time.timeScale = 0f; // 게임 일시 정지
        }
        else
        {
            Time.timeScale = 1f; // 게임 재개
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UIManager.Instance.UpdateScore(score);
    }

    public void GameOver()
    {
        UIManager.Instance.UpdateScore(score);
        UIManager.Instance.ShowGameOverPanel();
        PauseGame(true);
    }
}

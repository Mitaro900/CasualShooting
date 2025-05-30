using Singleton.Component;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonComponent<GameManager>
{
    private int score;
    public int DifficultyLevel { get; set; } = 1; // 게임 난이도 레벨
    public bool IsFirstWave { get; set; } = true;

    #region Singleton
    protected override void AwakeInstance()
    {
        Initialize();
    }

    protected override bool InitInstance()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        return true;
    }

    protected override void ReleaseInstance()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        if (Instance != this)
            Destroy(gameObject); // 중복 인스턴스 방지
    }
    #endregion

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UIManager.Instance.CloseUI();

        if (scene.name == "InGame")
        {
            UIManager.Instance.OpenUI<InGameUI>();
            UIManager.Instance.GetUI<InGameUI>()?.UpdateScore(score);
        }
    }

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
        UIManager.Instance.GetUI<InGameUI>()?.UpdateScore(score);
    }

    public void GameOver()
    {
        UIManager.Instance.GetUI<InGameUI>()?.UpdateScore(score);
        UIManager.Instance.GetUI<InGameUI>()?.ShowGameOverPanel();
        PauseGame(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResetGame();
        PauseGame(false);
    }

    private void ResetGame()
    {
        score = 0;
        DifficultyLevel = 1;
        IsFirstWave = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

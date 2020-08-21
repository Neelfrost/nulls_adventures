using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int _currentScene = 1;

    public void LoadScene()
    {
        SaveCurrentStats();

        _currentScene++;
        SceneManager.LoadScene(_currentScene);
    }

    private void SaveCurrentStats()
    {
        StatsTracker.Instance.currentHealth = PlayerStats.Instance.currentHealth;
    }
}

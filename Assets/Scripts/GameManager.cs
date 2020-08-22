using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int _currentScene = 1;
    private GameObject[] _enemies;
    public int enemyCount;

    private void Start()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = _enemies.Length;
    }

    private void Update()
    {
        if (enemyCount == 1)
        {
            GameObject[] spouts = GameObject.FindGameObjectsWithTag("Spout");
            foreach (var spout in spouts)
            {
                spout.GetComponent<Spout>().TriggerAnimation();
            }
        }
    }

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

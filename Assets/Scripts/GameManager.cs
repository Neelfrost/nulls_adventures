using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private GameObject[] _enemies;
    public int enemyCount;

    private void Start()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = _enemies.Length;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 && enemyCount == 1)
        {
            GameObject[] spouts = GameObject.FindGameObjectsWithTag("Spout");
            foreach (var spout in spouts)
            {
                spout.GetComponent<Spout>().Activate();
            }
        }
    }

    public void LoadScene(int Level)
    {
        SceneManager.LoadScene(Level);
    }

    public void LoadNext()
    {
        SaveCurrentStats();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void SaveCurrentStats()
    {
        if (PlayerStats.Instance != null)
            StatsTracker.Instance.currentHealth = PlayerStats.Instance.currentHealth;
    }
}

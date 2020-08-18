using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public Slider _healthBar;
    private float _maxHealth = 10;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _currentHealth;
    }

    private void Update()
    {
        _healthBar.value = _currentHealth;
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;
    }

    public void Damage(float amount)
    {
        _currentHealth -= amount;
    }
}

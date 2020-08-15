using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public Slider _healthBar;
    private Animator _animator;
    private float _maxHealth = 10;
    private float _currentHealth;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

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
        _animator.SetTrigger("Hurt");
        _currentHealth -= amount;
    }
}

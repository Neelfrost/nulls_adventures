using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public Slider _healthBar;
    private Color _originalColor;
    private SpriteRenderer _renderer;

    private float _maxHealth = 10;
    private float _currentHealth;
    private bool _invulnerable;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _originalColor = _renderer.color;

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
        if (!_invulnerable)
        {
            _currentHealth -= amount;
            StartCoroutine(Flash());
        }
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < 2; i++)
        {
            _invulnerable = true;
            _renderer.color = Color.grey;
            yield return new WaitForSeconds(0.05f);
            _renderer.color = _originalColor;
            yield return new WaitForSeconds(0.05f);
            _invulnerable = false;
        }
    }
}

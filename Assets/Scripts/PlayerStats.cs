using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    private Slider _slider;
    private Color _originalColor;
    private SpriteRenderer _renderer;

    public float maxHealth;
    public float currentHealth;
    private bool _invulnerable;

    private void Start()
    {
        Instance = this;

        _renderer = GetComponent<SpriteRenderer>(); // Find refernce to player
        _slider = GameObject.FindGameObjectWithTag("PlayerStats").GetComponentInChildren<Slider>(); // Get slider component from healthbar

        _originalColor = _renderer.color; // Get a reference to sprite's original color, used later for blink on damage

        maxHealth = StatsTracker.Instance.maxHealth;
        currentHealth = StatsTracker.Instance.currentHealth;

        _slider.maxValue = maxHealth;
        _slider.value = currentHealth;
    }

    private void Update()
    {
        _slider.value = currentHealth;

        if (currentHealth <= 0)
            GameManager.Instance.ReloadScene();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
    }

    public void Damage(float amount)
    {
        if (!_invulnerable)
        {
            currentHealth -= amount;
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

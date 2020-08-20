using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static Transform trigger;

    public GameObject projectile;
    private SpriteRenderer _renderer;
    private Slider _slider;
    private Image[] _healthBar;

    private Color _originalColor;
    private float _maxHealth = 10;
    private float _currentHealth;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        _healthBar = GetComponentsInChildren<Image>();

        trigger = transform.GetChild(0);

        _currentHealth = _maxHealth;
        _slider.maxValue = _maxHealth;
        _slider.value = _currentHealth;

        _renderer = GetComponent<SpriteRenderer>();
        _originalColor = _renderer.color;

    }

    private void Update()
    {
        _slider.value = _currentHealth;
    }

    public void Damage(float amount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= amount;
            StartCoroutine(Flash());
            StartCoroutine(Display());
        }
        else
            Destroy(gameObject);

        GetComponent<Animator>().SetBool("isAttacking", true);
    }

    IEnumerator Display()
    {
        _healthBar[0].enabled = true;
        _healthBar[1].enabled = true;
        yield return new WaitForSeconds(0.5f);
        _healthBar[0].enabled = false;
        _healthBar[1].enabled = false;
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < 2; i++)
        {
            _renderer.color = Color.grey;
            yield return new WaitForSeconds(0.1f);
            _renderer.color = _originalColor;
            yield return new WaitForSeconds(0.1f);
        }
    }

}

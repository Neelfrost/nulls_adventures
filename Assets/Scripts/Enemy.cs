using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform trigger;

    public Animator _animator;
    public GameObject projectile;
    private Slider _slider;
    private Color _originalColor;
    private Animator _animatorEnemy;
    private SpriteRenderer _renderer;

    private float _maxHealth = 10;
    private float _currentHealth;
    private bool _invulnerable = false;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();

        trigger = transform.GetChild(0);

        _currentHealth = _maxHealth;
        _slider.maxValue = _maxHealth;
        _slider.value = _currentHealth;

        _animatorEnemy = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _originalColor = _renderer.color;

    }

    private void Update()
    {
        _slider.value = _currentHealth;

        if (_currentHealth <= 0)
        {
            GameManager.Instance.enemyCount--;
            Destroy(gameObject);
        }

    }

    public void Damage(float amount)
    {
        if (_currentHealth > 0 && !_invulnerable)
        {
            _currentHealth -= amount;
            _animator.SetTrigger("Display");
            StartCoroutine(Flash());
        }

        // Alert the enemy if damaged
        if (!_animatorEnemy.GetCurrentAnimatorStateInfo(0).IsName("Sentry_Attack"))
            _animatorEnemy.SetBool("isAttacking", true);
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

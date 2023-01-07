using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const float MinHealthDifference = 1;
    
    [SerializeField] private float _maxHealth;

    public event Action HealthChanged;
    
    private float _currentHealth;
    private float _minHealth;
    
    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;
    public float MinHealth => _minHealth;

    private void OnValidate()
    {
        if (_maxHealth <= MinHealth)
            _maxHealth = MinHealth + MinHealthDifference;
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
        
        HealthChanged?.Invoke();        
    }

    public void Heal(float health)
    {
        _currentHealth += health;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
        
        HealthChanged?.Invoke();
    }
}

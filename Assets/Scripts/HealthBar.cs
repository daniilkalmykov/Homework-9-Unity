using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _heal;
    
    private event Action HealthReduced;
    private event Action HealthIncreased;
    private Slider _slider;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        HealthReduced += OnHealthReduced;
        HealthIncreased += OnHealthIncreased;
    }

    private void OnDisable()
    {
        HealthReduced -= OnHealthReduced;
        HealthIncreased -= OnHealthIncreased;
    }

    private void Start()
    {
        _slider.maxValue = _health.MaxHealth;
        _slider.minValue = _health.MinHealth;
        _slider.value = _health.CurrentHealth;
    }

    public void StartHealthReducedEvent()
    {
        HealthReduced?.Invoke();
    }

    public void StartHealthIncreasedEvent()
    {
        HealthIncreased?.Invoke();
    }
    
    private void OnHealthReduced()
    {
        _health.TakeDamage(_damage);
        
        _slider.value = _health.CurrentHealth;
    }

    private void OnHealthIncreased()
    {
        _health.Heal(_heal);
        
        _slider.value = _health.CurrentHealth;
    }
}
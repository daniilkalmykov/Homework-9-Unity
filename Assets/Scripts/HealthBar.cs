using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private const float MinSpeed = 1;
    
    [SerializeField] private Health _health;
    [SerializeField] private float _speed;
    
    private Slider _slider;

    private void OnValidate()
    {
        if (_speed < MinSpeed)
            _speed = MinSpeed;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        _slider.maxValue = _health.MaxHealth;
        _slider.minValue = _health.MinHealth;
        _slider.value = _health.MaxHealth;
    }

    private void OnHealthChanged()
    {
        StartCoroutine(ChangeSliderValue());
    }

    private IEnumerator ChangeSliderValue()
    {
        while (_slider.value != _health.CurrentHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.CurrentHealth, Time.deltaTime * _speed);

            yield return 0;
        }
    }
}
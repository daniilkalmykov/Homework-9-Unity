using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private Slider _slider;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.maxValue = _health.MaxHealth;
        _slider.minValue = _health.MinHealth;
        _slider.value = _health.CurrentHealth;
    }

    public void OnHealthChanged()
    {
        _slider.value = _health.CurrentHealth;
    }
}
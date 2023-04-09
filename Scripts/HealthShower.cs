using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class HealthShower : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _duration;
    
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.Health;
        _slider.minValue = _player.MinHealth;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        _slider.DOValue(_player.Health, _duration).SetEase(Ease.Linear);
    }
}

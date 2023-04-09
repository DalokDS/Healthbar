using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event UnityAction HealthChanged
    {
        add => _healthChanged.AddListener(value);
        remove => _healthChanged.RemoveListener(value);
    }

    private UnityEvent _healthChanged = new UnityEvent();

    public float MaxHealth => _maxHealth;
    public float Health { get; private set; }
    public float MinHealth { get; private set; }

    private void Awake()
    {
        Health = _maxHealth;
    }

    public void Heal(float value)
    {
        if (value >= 0)
        {
            Health += value;

            if (Health > MaxHealth)
                Health = MaxHealth;

            _healthChanged.Invoke();
        }  
    }

    public void TakeDamage(float value)
    {
        if (value >= 0)
        {
            Health -= value;

            if (Health < MinHealth)
                Health = MinHealth;

            _healthChanged.Invoke();
        } 
    }
}

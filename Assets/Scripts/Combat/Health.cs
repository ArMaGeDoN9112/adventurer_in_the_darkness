using System;
using UnityEngine;


//компонент, отвечающий за здоровье сущности
public class Health : MonoBehaviour, IDamageable, IHealable
{
    public event Action OnDeath; //событие, вызываемое при смерти
    public event Action<int> OnDamageTaken; //событие, вызываемое при получении урона
    public event Action<int> OnHealed; //событие, вызываемое при восстановлении здоровья

    [SerializeField] private int _maxHealth = 100;

    private int _currentHealth;

    public int CurrentHealth { get { return _currentHealth; } }
    public int MaxHealth { get { return _maxHealth; } }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (amount < 0) //нельзя нанести отрицательный урон
            throw new ArgumentOutOfRangeException($"Damage amount can't be negative!: {gameObject.name}");

        _currentHealth -= amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth); //здоровье не может быть < 0

        OnDamageTaken?.Invoke(amount);
        if (_currentHealth == 0)
            OnDeath?.Invoke();
    }

    public void Heal(int amount)
    {
        if (amount < 0) //нельзя восстановить отрицательное здоровье
            throw new ArgumentOutOfRangeException($"Healing amount can't be negative!: {gameObject.name}");

        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);
        OnHealed?.Invoke(amount);
    }

    public void IncreaseHealth(int amount)
    {
        _maxHealth += amount;
    }
}

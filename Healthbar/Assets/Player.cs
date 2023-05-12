using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private float _maxHealth = 100f;
    private float _minHealth = 0f;

    public event UnityAction ChangingHealth;

    public float Health => _health;

    public void TakeHeal(float heal)
    {
        _health = Mathf.Clamp(_health + heal, _minHealth, _maxHealth);
        ChangingHealth?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth);
        ChangingHealth?.Invoke();
    }
}

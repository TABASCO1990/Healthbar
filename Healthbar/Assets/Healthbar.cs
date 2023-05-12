using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _speed = 50f;

    private Coroutine _barValue;

    private void OnEnable()
    {
        _player.ChangingHealth += MoveValue; 
    }

    private void OnDisable()
    {
        _player.ChangingHealth -= MoveValue;
    }

    private void MoveValue()
    {
        if (_barValue != null)
        {
            StopCoroutine(_barValue);
        }

        _barValue = StartCoroutine(ChangeValue());       
    }

    private IEnumerator ChangeValue()
    {
        while (_healthBar.value != _player.Health)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _player.Health, _speed * Time.deltaTime);
            yield return null;
        }
    }
}

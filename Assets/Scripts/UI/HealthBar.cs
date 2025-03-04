using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _healthComponent;
    [SerializeField] private Image _fillImage;

    private void OnEnable()
    {
        _healthComponent.OnDamageTaken += UpdateHealthBar;
        _healthComponent.OnHealed += UpdateHealthBar;
        _healthComponent.OnDeath += HideHealthBar;
    }

    private void OnDisable()
    {
        _healthComponent.OnDamageTaken -= UpdateHealthBar;
        _healthComponent.OnHealed -= UpdateHealthBar;
        _healthComponent.OnDeath -= HideHealthBar;
    }

    private void UpdateHealthBar(int healthChange)
    {
        SetFill(
            (float)_healthComponent.CurrentHealth /
            _healthComponent.MaxHealth
        );
    }

    private void SetFill(float value)
    {
        _fillImage.fillAmount = Mathf.Clamp01(value);
    }

    private void HideHealthBar()
    {
        gameObject.SetActive(false);
    }
}


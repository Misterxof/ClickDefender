using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image _healthBar;

    public HealthBar(float health, float maxHealth)
    {
        _healthBar = GameObject.FindWithTag("HealthBar").GetComponent<Image>();
        OnHealthtChange(health, maxHealth);
    }

    public void OnHealthtChange(float health, float maxHealth)
    {
        _healthBar.fillAmount = health / maxHealth;
    }
}

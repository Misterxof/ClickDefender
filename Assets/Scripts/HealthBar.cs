using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;

    public HealthBar(float health, float maxHealth)
    {
        healthBar = GameObject.FindWithTag("HealthBar").GetComponent<Image>();
        OnHealthtChange(health, maxHealth);
    }

    public void OnHealthtChange(float health, float maxHealth)
    {
       healthBar.fillAmount = health / maxHealth;
    }
}

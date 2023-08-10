using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    private Image _experiencneBar;

    public ExperienceBar(float experience, float maxExperience)
    {
        _experiencneBar = GameObject.FindWithTag("ExperienceBar").GetComponent<Image>();
        OnExperienceChange(experience, maxExperience);
    }

    public void OnExperienceChange(float experience, float maxExperience)
    {
        _experiencneBar.fillAmount = experience / maxExperience;
    }
}

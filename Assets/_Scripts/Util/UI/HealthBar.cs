using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _fill;
    
    public void SetMaxHealth(int maxHealth)
    {
        _fill.maxValue = maxHealth;
        _fill.value = maxHealth;
    }

    public void SetCurrentHealth(int currentHealth)
    {
        _fill.value = currentHealth;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image health;
    public void UpdateHealth(float currenthealth, float maxHealth)
    {
        health.fillAmount = currenthealth / maxHealth;
    }
}

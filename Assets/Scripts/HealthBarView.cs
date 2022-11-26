using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{ 
    [SerializeField] private Image healthBar;
    [SerializeField] private Health health;

    [SerializeField] private float healthChangingSpeed;
    private float cachedFillAmount;
    private float accumulation;
    private void Start()
    {
        cachedFillAmount = healthBar.fillAmount;
        ChangeColor();
    }
    private void Update()
    {
        ChangeHealthValue();
    }
    public void ChangeHealthValue()
    {
        float healthPercentage = health.hp / health.maxHP;
        if (healthPercentage == cachedFillAmount) 
            return;   
        if (accumulation < 1)
        {
            accumulation += healthChangingSpeed * Time.deltaTime;
            healthBar.fillAmount = Mathf.Lerp(cachedFillAmount, healthPercentage, accumulation);
            ChangeColor();
            return;
        }
        accumulation = 0;
        cachedFillAmount = healthBar.fillAmount;
    }

    public void ChangeColor()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, health.hp / health.maxHP);
        healthBar.color = healthColor;
    }
}
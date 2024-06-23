using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Main : MonoBehaviour
{
    [Header("HealthBar")]
    public Slider healthSlider;

    public float maxHealth;
    public float currentHealth;

    public TextMeshProUGUI healthText;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (healthSlider.value != currentHealth)
        {
            healthSlider.value = currentHealth;
            healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(3);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
            Debug.Log("HP is below 0");
            // lose call func();
        }

    }
}

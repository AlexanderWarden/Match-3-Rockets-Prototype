using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy_Main : MonoBehaviour
{
    private Player_Main Player;

    private Enemy_Abilities EnemyAbilities;

    [Header("HealthBar")]
    public Slider healthSlider;

    public float maxHealth;
    public float currentHealth;

    public TextMeshProUGUI healthText;

    [Header("Status Effect")]

    public bool isFrozen;
    public bool isBurned;
    public int burnedTurns = 0;

    public TextMeshProUGUI statusText;
    public TextMeshProUGUI discordText;
    public TextMeshProUGUI shieldText;

    public TextMeshProUGUI EnemyActionText;

    

    [Header("Minions")]

    public GameObject Minion1;
    public GameObject Minion2;
    public GameObject Minion3;

    public int MinionsNumber;

    [Header("TookDamageText")]

    public TextMeshProUGUI tookDamageText;
    public float tookDamageNumber = 0;

    public float textTimer;
    public float textTime;
    public bool textShown;

    private void Start()
    {
        Player = FindObjectOfType<Player_Main>();
        EnemyAbilities = FindObjectOfType<Enemy_Abilities>();

        currentHealth = maxHealth;

        tookDamageText.text = "";
    }

    private void Update()
    {
        if (healthSlider.value != currentHealth)
        {
            healthSlider.value = currentHealth;
            healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        }

        if (textShown)
        {
            textTimer += Time.deltaTime;

            if (textTimer > textTime)
            {
                textTimer = 0;
                tookDamageText.text = "";
                textShown = false;
            }
        }

        StatusTextFunc();
        DiscordTextFunc();
        ShieldTextFunc();

        MinionsShow();
    }

    public void MinionsShow()
    {
        if(MinionsNumber == 3)
        {
            Minion1.SetActive(true);
            Minion2.SetActive(true);
            Minion3.SetActive(true);
        }
        else if (MinionsNumber == 2)
        {
            Minion1.SetActive(true);
            Minion2.SetActive(true);
            Minion3.SetActive(false);
        }
        else if (MinionsNumber == 1)
        {
            Minion1.SetActive(true);
            Minion2.SetActive(false);
            Minion3.SetActive(false);
        }
        else
        {
            Minion1.SetActive(false);
            Minion2.SetActive(false);
            Minion3.SetActive(false);
        }
    }

    private void StatusTextFunc()
    {
        if(isFrozen)
        {
            statusText.text = "Frozen";
        }
        else if(isBurned)
        {
            statusText.text = "Burned";
        }
        else
        {
            statusText.text = "No";
        }
    }

    private void ShieldTextFunc()
    {
        if (EnemyAbilities.ShieldNumber == 0)
        {
            shieldText.text = "No";
        }
        if (EnemyAbilities.ShieldNumber == 2)
        {
            shieldText.text = "Fire";
        }
        if (EnemyAbilities.ShieldNumber == 3)
        {
            shieldText.text = "Ice";
        }
        if (EnemyAbilities.ShieldNumber == 4)
        {
            shieldText.text = "Electro";
        }  
    }

    private void DiscordTextFunc()
    {
        if (EnemyAbilities.DiscordNumber == 0)
        {
            discordText.text = "No";
        }
        if (EnemyAbilities.DiscordNumber == 2)
        {
            discordText.text = "Fire";
        }
        if (EnemyAbilities.DiscordNumber == 3)
        {
            discordText.text = "Ice";
        }
        if (EnemyAbilities.DiscordNumber == 4)
        {
            discordText.text = "Electro";
        }
    }

    public void TakeDamage(float damage, int type)
    {
        if (EnemyAbilities.ShieldNumber == type)
            return;
        else
        {
            textShown = true;
            tookDamageText.text = damage.ToString();

            if (type == 4)
            {
                if (MinionsNumber > 0)
                    MinionsNumber = 0;

                tookDamageText.color = new Color(128, 0, 255, 255);
            }

            if (MinionsNumber > 0)
            {
                MinionsNumber--;
                return;
            }

            currentHealth -= damage;

            if (type == 2)
            {
                isBurned = true;
                burnedTurns = 2;
                tookDamageText.color = new Color(255, 145, 0, 255);
            }
            if(type == 3)
            {
                isFrozen = true;
                tookDamageText.color = new Color(255, 145, 0, 255);
            }
            
        }
      
    }

}

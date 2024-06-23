using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Attack : MonoBehaviour
{
    private Enemy_Main Enemy;

    public float damageAmount;
    public TextMeshProUGUI damageText;

    public float textTimer;
    public float textTime;
    public bool textShown;

    private void Start()
    {
        Enemy = FindObjectOfType<Enemy_Main>();
        damageText.text = "";
    }

    private void Update()
    {
        if(textShown)
        {
            textTimer += Time.deltaTime;

            if(textTimer > textTime)
            {
                textTimer = 0;
                damageText.text = "";
                textShown = false;
            }
        }
    }

    public void RocketAttack()
    {
        SpawnRocket();
    }

    private void SpawnRocket()
    {
        GameObject rocket = FR_Pool.instance.GetPooledObject();

        if (rocket != null)
        {
            rocket.transform.position = transform.position;
            rocket.SetActive(true);
        }

    }

    public void DoDamage(int type)
    {
        switch (type)
        {
            case 1: // default
                if(Enemy.MinionsNumber > 0)
                {
                    Enemy.MinionsNumber--;
                    return;
                }
                else
                {
                    damageAmount = 3;
                    damageText.color = new Color(255, 255, 255, 255);
                }
                break;
            case 2: // fire
                if (Enemy.MinionsNumber > 0)
                {
                    Enemy.MinionsNumber--;
                    return;
                }
                else
                {
                    damageAmount = 4;
                    Enemy.isBurned = true;
                    Enemy.burnedTurns = 2;
                    damageText.color = new Color(255, 0, 0, 255);
                }
                break;
            case 3: // ice
                if (Enemy.MinionsNumber > 0)
                {
                    Enemy.MinionsNumber--;
                    return;
                }
                else
                {
                    damageAmount = 3;
                    Enemy.isFrozen = true;
                    damageText.color = new Color(0, 0, 255, 255);
                }
                break;
            case 4: // eletro
                if (Enemy.MinionsNumber > 0)
                    Enemy.MinionsNumber = 0;
                damageAmount = 2;
                damageText.color = new Color(128, 0, 255, 255);
                break;
            default:
                break;
        }

        Enemy.TakeDamage(damageAmount, type);

        damageText.text = damageAmount.ToString();
        textShown = true;
    }
}

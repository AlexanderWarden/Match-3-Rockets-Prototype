using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket_Animation : MonoBehaviour
{
    public float FlySpeed;

    public int RocketType;
    public int RocketDamage;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + FlySpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            collision.gameObject.GetComponent<Enemy_Main>().TakeDamage(RocketDamage, RocketType);
            // exp = damage to enemy
        }
        else if(collision.gameObject.CompareTag("Minion"))
        {
            Debug.Log("Minion Killed");
            gameObject.SetActive(false);
            // exp = - 1 minion
        }
    }

    public void SetRocketStats(int type)
    {
        RocketType = type;

        switch (type)
        {
            case 1:
                gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                RocketDamage = 3;
                break;
            case 2:
                gameObject.GetComponent<Image>().color = new Color(255, 145, 0, 255);
                RocketDamage = 4;
                break;
            case 3:
                gameObject.GetComponent<Image>().color = new Color(0, 235, 255, 255);
                RocketDamage = 3;
                break;
            case 4:
                gameObject.GetComponent<Image>().color = new Color(173, 0, 255, 255);
                RocketDamage = 2;
                break;
            default:
                //Debug.Log("Default Exception");
                break;
        }
    }
}

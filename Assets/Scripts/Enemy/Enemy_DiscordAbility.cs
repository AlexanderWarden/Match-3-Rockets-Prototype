using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DiscordAbility : MonoBehaviour
{
    private Rocket_HQ rocketsHQ;
    private Enemy_Abilities EnemyAbiities;

    private void Awake()
    {
        rocketsHQ = FindObjectOfType<Rocket_HQ>();
        EnemyAbiities = FindObjectOfType<Enemy_Abilities>();
    }

    public void DiscordRocketType(int type)
    {
        if (type == 0) return;

        for (int v = 0; v < rocketsHQ.Rockets.GetLength(0); v++)
        {
            for (int h = 0; h < rocketsHQ.Rockets.GetLength(1); h++)
            {
                if (rocketsHQ.Rockets[v, h].GetComponent<Rocket_Type>().RocketType == type)
                {
                    rocketsHQ.Rockets[v, h].GetComponent<Rocket_Type>().TypeIsDicorded = true;
                }
            }
        }
    }

    public void UnDiscordRocketType()
    {
        for (int v = 0; v < rocketsHQ.Rockets.GetLength(0); v++)
        {
            for (int h = 0; h < rocketsHQ.Rockets.GetLength(1); h++)
            {
                rocketsHQ.Rockets[v, h].GetComponent<Rocket_Type>().TypeIsDicorded = false;
            }
        }
    }

}

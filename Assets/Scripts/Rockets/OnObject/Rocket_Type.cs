using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class Rocket_Type : MonoBehaviour
{
    private Rocket_HQ rocketsHQ;
    private Rocket_SpawnType rocketsSpawnType;
    private Rocket_Obj rocketObj;

    private Player_Attack playerAttack;

    public int RocketType;
    public int RocketDamage;
        
    public bool HasType = false;

    public bool TypeIsDicorded = false;

    private void Awake()
    {
        rocketsHQ = FindObjectOfType<Rocket_HQ>();
        rocketsSpawnType = FindObjectOfType<Rocket_SpawnType>();
        rocketObj = GetComponent<Rocket_Obj>();

        playerAttack = FindObjectOfType<Player_Attack>();
    }

    private void Update()
    {

        if(RocketType == 5)
        {
            HasType = false;
        }
        
        if(TypeIsDicorded)
        {
            gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }
        else
        {
            switch (RocketType)
            {
                case 1:
                    gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    RocketDamage = 3;
                    break;
                case 2:
                    gameObject.GetComponent<Image>().color = new Color(255, 0, 0, 255);
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
                case 5:
                    gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 255);
                    break;
                default:
                    //Debug.Log("Default Exception");
                    break;
            }
        }
        
    }

    public void ExchangeTypes(int direction)
    {
        int MyType = RocketType;
        switch(direction)
        {
            case 1:
                if (rocketObj.RocketIndexV == 0)
                    return;
                Debug.Log("Exchanging!");
                RocketType = rocketsHQ.Rockets[rocketObj.RocketIndexV - 1, rocketObj.RocketIndexH].GetComponent<Rocket_Type>().RocketType;
                rocketsHQ.Rockets[rocketObj.RocketIndexV - 1, rocketObj.RocketIndexH].GetComponent<Rocket_Type>().RocketType = MyType;

                rocketsHQ.FullCheckForMatches();
                break;
            case 2:
                if (rocketObj.RocketIndexV == 7)
                    return;
                Debug.Log("Exchanging!");
                RocketType = rocketsHQ.Rockets[rocketObj.RocketIndexV + 1, rocketObj.RocketIndexH].GetComponent<Rocket_Type>().RocketType;
                rocketsHQ.Rockets[rocketObj.RocketIndexV + 1, rocketObj.RocketIndexH].GetComponent<Rocket_Type>().RocketType = MyType;

                rocketsHQ.FullCheckForMatches();
                break;
            case 3:
                if (rocketObj.RocketIndexH == 0)
                    return;
                Debug.Log("Exchanging!");
                RocketType = rocketsHQ.Rockets[rocketObj.RocketIndexV, rocketObj.RocketIndexH - 1].GetComponent<Rocket_Type>().RocketType;
                rocketsHQ.Rockets[rocketObj.RocketIndexV, rocketObj.RocketIndexH - 1].GetComponent<Rocket_Type>().RocketType = MyType;

                rocketsHQ.FullCheckForMatches();
                break;
            case 4:
                if (rocketObj.RocketIndexH == 7)
                    return;
                Debug.Log("Exchanging!");
                RocketType = rocketsHQ.Rockets[rocketObj.RocketIndexV, rocketObj.RocketIndexH + 1].GetComponent<Rocket_Type>().RocketType;
                rocketsHQ.Rockets[rocketObj.RocketIndexV, rocketObj.RocketIndexH + 1].GetComponent<Rocket_Type>().RocketType = MyType;

                rocketsHQ.FullCheckForMatches();
                break;
            default:
                Debug.Log("Exchange default exception");
                break;
        }
        
    }

    public void CheckForMatches()
    {
        if (TypeIsDicorded)
            return;

        if (RocketType == 5)
            return;

        CheckForMatchByV();
        CheckForMatchByH();

        
    }

    public void CheckForMatchByV()
    {
        if (rocketObj.RocketIndexV > 0 && rocketObj.RocketIndexV < 7)
        {
            if ((rocketsHQ.Rockets[rocketObj.RocketIndexV - 1, rocketObj.RocketIndexH].GetComponent<Rocket_Type>().RocketType == RocketType) &&
            (rocketsHQ.Rockets[rocketObj.RocketIndexV + 1, rocketObj.RocketIndexH].GetComponent<Rocket_Type>().RocketType == RocketType))
            {
                Debug.Log("My Index = V:" + rocketObj.RocketIndexV + "/ H:" + rocketObj.RocketIndexH + "! I have MATCH by V");

                SpawnFlyingRocket();

                rocketsHQ.Rockets[rocketObj.RocketIndexV - 1, rocketObj.RocketIndexH].GetComponent<Rocket_Obj>().RocketLaunched();
                rocketsHQ.Rockets[rocketObj.RocketIndexV, rocketObj.RocketIndexH].GetComponent<Rocket_Obj>().RocketLaunched();
                rocketsHQ.Rockets[rocketObj.RocketIndexV + 1, rocketObj.RocketIndexH].GetComponent<Rocket_Obj>().RocketLaunched();
            }
        }
    }

    public void CheckForMatchByH()
    {
        if (rocketObj.RocketIndexH > 0 && rocketObj.RocketIndexH < 7)
        {
            if ((rocketsHQ.Rockets[rocketObj.RocketIndexV, rocketObj.RocketIndexH - 1].GetComponent<Rocket_Type>().RocketType == RocketType) &&
            (rocketsHQ.Rockets[rocketObj.RocketIndexV, rocketObj.RocketIndexH + 1].GetComponent<Rocket_Type>().RocketType == RocketType))
            {
                Debug.Log("My Index = V:" + rocketObj.RocketIndexV + "/ H:" + rocketObj.RocketIndexH + "! I have MATCH by H");

                SpawnFlyingRocket();

                rocketsHQ.Rockets[rocketObj.RocketIndexV, rocketObj.RocketIndexH - 1].GetComponent<Rocket_Obj>().RocketLaunched();
                rocketsHQ.Rockets[rocketObj.RocketIndexV, rocketObj.RocketIndexH].GetComponent<Rocket_Obj>().RocketLaunched();
                rocketsHQ.Rockets[rocketObj.RocketIndexV, rocketObj.RocketIndexH + 1].GetComponent<Rocket_Obj>().RocketLaunched();
            }
            
        }
    }

    private void SpawnFlyingRocket()
    {
        GameObject rocket = FR_Pool.instance.GetPooledObject();

        if (rocket != null)
        {
            rocket.transform.position = transform.position;
            rocket.GetComponent<Rocket_Animation>().SetRocketStats(RocketType);
            rocket.SetActive(true);
        }
    }

    

    
}

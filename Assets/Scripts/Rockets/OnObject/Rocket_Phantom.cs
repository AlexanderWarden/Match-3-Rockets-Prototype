using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Phantom : MonoBehaviour
{

    private Rocket_HQ rocketsHQ;
    private Rocket_SpawnType rocketsSpawnType;
    private Rocket_Obj rocketObj;

    private Rocket_Type rocketType;


    public int RocketType;
    public bool HasType = false;

    public bool HasMatch = false;
    //public bool RealIsSet = false;

    private void Awake()
    {
        rocketsHQ = FindObjectOfType<Rocket_HQ>();
        rocketsSpawnType = FindObjectOfType<Rocket_SpawnType>();
        rocketObj = GetComponent<Rocket_Obj>();
        rocketType = GetComponent<Rocket_Type>();

    }

    public void CheckForMatches()
    {
        CheckForMatchByV();
        CheckForMatchByH();
    }

    public void CheckForMatchByV()
    {
        if (rocketObj.RocketIndexV > 0 && rocketObj.RocketIndexV < 7)
        {
            if ((rocketsHQ.Rockets[rocketObj.RocketIndexV - 1, rocketObj.RocketIndexH].GetComponent<Rocket_Phantom>().RocketType == RocketType) &&
            (rocketsHQ.Rockets[rocketObj.RocketIndexV + 1, rocketObj.RocketIndexH].GetComponent<Rocket_Phantom>().RocketType == RocketType))
            {
                Debug.Log("My Index = V:" + rocketObj.RocketIndexV + "/ H:" + rocketObj.RocketIndexH + "! I have MATCH by V");
                HasMatch = true;
                Debug.Log("Has Match: " + HasMatch);
           
                ChangeRocketType();
            }
            else
            {
                HasMatch = false;
            }
        }
    }

    public void CheckForMatchByH()
    {
        if (rocketObj.RocketIndexH > 0 && rocketObj.RocketIndexH < 7)
        {
            if ((rocketsHQ.Rockets[rocketObj.RocketIndexV, rocketObj.RocketIndexH - 1].GetComponent<Rocket_Phantom>().RocketType == RocketType) &&
            (rocketsHQ.Rockets[rocketObj.RocketIndexV, rocketObj.RocketIndexH + 1].GetComponent<Rocket_Phantom>().RocketType == RocketType))
            {
                Debug.Log("My Index = V:" + rocketObj.RocketIndexV + "/ H:" + rocketObj.RocketIndexH + "! I have MATCH by H");
                HasMatch = true;
                Debug.Log("Has Match: " + HasMatch);
                
                ChangeRocketType();
            }
            else
            {
                HasMatch = false;
            }

        }
    }

    public void ChangeRocketType()
    {
        if(!rocketType.HasType)
        {
            Debug.Log("Changing Rocket Type : " + RocketType);
            if (RocketType < 4)
                RocketType++;
            else if (RocketType > 1)
                RocketType--;
            else
                RocketType = Random.Range(1, 5);

            Debug.Log("Changed Rocket Type: " + RocketType);
        }
        
    }
}

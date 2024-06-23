using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomGrid : MonoBehaviour
{
    public Rocket_HQ rocketsHQ { get; private set; }
    public Rocket_SpawnType rocketsSpawnType { get; private set; }
    public Rocket_Obj rocketObj { get; private set; }
    public Rocket_Type rocketType { get; private set; }
    public Fight_Manager fightManager { get; private set; }

    public int CheckNoMatchesNumber = 0;

    public bool NeedCheck;

    private void Awake()
    {
        rocketsHQ = FindObjectOfType<Rocket_HQ>();
        rocketsSpawnType = FindObjectOfType<Rocket_SpawnType>();
        rocketObj = GetComponent<Rocket_Obj>();
        rocketType = GetComponent<Rocket_Type>();

        fightManager = FindObjectOfType<Fight_Manager>();
    }

    private void Update()
    {
        NeedCheckFunc();
    }

    public void NeedCheckFunc()
    {
        if (NeedCheck)
        {         
            if (CheckNoMatchesNumber < 64)
            {
                PhantomCheckForMatches();
            }
        }
    }

    private void PhantomCheckForMatches()
    {
        //Debug.Log("PhantomCheck");
        for (int v = 0; v < rocketsHQ.Rockets.GetLength(0); v++)
        {
            for (int h = 0; h < rocketsHQ.Rockets.GetLength(1); h++)
            {
                rocketsHQ.Rockets[v, h].GetComponent<Rocket_Phantom>().CheckForMatches();

                if (rocketsHQ.Rockets[v, h].GetComponent<Rocket_Phantom>().HasMatch == false)
                {
                    CheckNoMatchesNumber++;
                    Debug.Log("NoMatches: " + CheckNoMatchesNumber);

                }
                else
                {
                    
                    CheckNoMatchesNumber = 0;
                    return;
                }
            }
        }

        if (CheckNoMatchesNumber == 64)
        {
            SetRealRocketTypes();
        }
        else
        {
            CheckNoMatchesNumber = 0;
        }

    }

    private void SetRealRocketTypes()
    {
        for (int v = 0; v < rocketsHQ.Rockets.GetLength(0); v++)
        {
            for (int h = 0; h < rocketsHQ.Rockets.GetLength(1); h++)
            {
                rocketsHQ.Rockets[v, h].GetComponent<Rocket_Type>().RocketType = rocketsHQ.Rockets[v, h].GetComponent<Rocket_Phantom>().RocketType;
                //rocketsHQ.Rockets[v, h].GetComponent<Rocket_Phantom>().RealIsSet = true;
            }
        }

        fightManager.GameStarted = true;
        rocketsSpawnType.SpawnIsDone = 1;
        NeedCheck = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_SpawnType : MonoBehaviour
{
    public Rocket_HQ rocketsHQ;
    public PhantomGrid phantomGrid;

    public int SpawnIsDone = 0;

    public void Start()
    {
        rocketsHQ = GetComponent<Rocket_HQ>();
        phantomGrid = GetComponent<PhantomGrid>();

        SetRocketsType();
    }

    public void SetRocketsType()
    {
        //Debug.Log("SetRocketsType");
        for (int v = 0; v < rocketsHQ.Rockets.GetLength(0); v++)
        {
            for (int h = 0; h < rocketsHQ.Rockets.GetLength(1); h++)
            {
                int RandomValue = Random.Range(1,5);
                rocketsHQ.Rockets[v, h].GetComponent<Rocket_Phantom>().RocketType = RandomValue;
            }
        }

        phantomGrid.NeedCheck = true;
        phantomGrid.NeedCheckFunc();
        //phantomGrid.PhantomCheckForMatches();
    }

    public void RocketsResetType()
    {
        Debug.Log("Reseting");
        phantomGrid.CheckNoMatchesNumber = 0;
        SpawnIsDone = 0;

        for (int v = 0; v < rocketsHQ.Rockets.GetLength(0); v++)
        {
            for (int h = 0; h < rocketsHQ.Rockets.GetLength(1); h++)
            {
                if(rocketsHQ.Rockets[v, h].GetComponent<Rocket_Obj>().isLaunched)
                {
                    int RandomValue = Random.Range(1, 5);
                    rocketsHQ.Rockets[v, h].GetComponent<Rocket_Phantom>().RocketType = RandomValue;
                    rocketsHQ.Rockets[v, h].GetComponent<Rocket_Obj>().isLaunched = false;
                    //rocketsHQ.Rockets[v, h].GetComponent<Rocket_Type>().HasType = false;
                }
                
            }
        }

        phantomGrid.NeedCheck = true;
        phantomGrid.NeedCheckFunc();
    }

}

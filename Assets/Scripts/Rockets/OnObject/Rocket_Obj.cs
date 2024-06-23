using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Rocket_Obj : MonoBehaviour
{
    public Rocket_HQ rocketsHQ;
    private Rocket_Type rocketType;
    private Rocket_SpawnType rocketSpawnType;

    public int RocketIndexV;
    public int RocketIndexH;

    public bool TypeSpawned;
    public bool isLaunched = false;

    public void Awake()
    {
        rocketsHQ = FindObjectOfType<Rocket_HQ>();
        rocketSpawnType = FindObjectOfType<Rocket_SpawnType>();
        rocketType = GetComponent<Rocket_Type>();
    }

    public void RocketLaunched()
    {
        rocketType.RocketType = 5;
        rocketType.HasType = false;
        isLaunched = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_HQ : MonoBehaviour
{
    //public List<Rocket_Obj> Rockets = new List <Rocket_Obj>();

    public GameObject[,] Rockets;

    public GameObject Rocket11;
    public GameObject Rocket12;
    public GameObject Rocket13;
    public GameObject Rocket14;
    public GameObject Rocket15;
    public GameObject Rocket16;
    public GameObject Rocket17;
    public GameObject Rocket18;

    public GameObject Rocket21;
    public GameObject Rocket22;
    public GameObject Rocket23;
    public GameObject Rocket24;
    public GameObject Rocket25;
    public GameObject Rocket26;
    public GameObject Rocket27;
    public GameObject Rocket28;

    public GameObject Rocket31;
    public GameObject Rocket32;
    public GameObject Rocket33;
    public GameObject Rocket34;
    public GameObject Rocket35;
    public GameObject Rocket36;
    public GameObject Rocket37;
    public GameObject Rocket38;

    public GameObject Rocket41;
    public GameObject Rocket42;
    public GameObject Rocket43;
    public GameObject Rocket44;
    public GameObject Rocket45;
    public GameObject Rocket46;
    public GameObject Rocket47;
    public GameObject Rocket48;

    public GameObject Rocket51;
    public GameObject Rocket52;
    public GameObject Rocket53;
    public GameObject Rocket54;
    public GameObject Rocket55;
    public GameObject Rocket56;
    public GameObject Rocket57;
    public GameObject Rocket58;

    public GameObject Rocket61;
    public GameObject Rocket62;
    public GameObject Rocket63;
    public GameObject Rocket64;
    public GameObject Rocket65;
    public GameObject Rocket66;
    public GameObject Rocket67;
    public GameObject Rocket68;

    public GameObject Rocket71;
    public GameObject Rocket72;
    public GameObject Rocket73;
    public GameObject Rocket74;
    public GameObject Rocket75;
    public GameObject Rocket76;
    public GameObject Rocket77;
    public GameObject Rocket78;

    public GameObject Rocket81;
    public GameObject Rocket82;
    public GameObject Rocket83;
    public GameObject Rocket84;
    public GameObject Rocket85;
    public GameObject Rocket86;
    public GameObject Rocket87;
    public GameObject Rocket88;

    public void Awake()
    {
        Rockets = new GameObject[,] {
        { Rocket11, Rocket12, Rocket13, Rocket14, Rocket15, Rocket16, Rocket17, Rocket18 },
        { Rocket21, Rocket22, Rocket23, Rocket24, Rocket25, Rocket26, Rocket27, Rocket28 },
        { Rocket31, Rocket32, Rocket33, Rocket34, Rocket35, Rocket36, Rocket37, Rocket38 },
        { Rocket41, Rocket42, Rocket43, Rocket44, Rocket45, Rocket46, Rocket47, Rocket48 },
        { Rocket51, Rocket52, Rocket53, Rocket54, Rocket55, Rocket56, Rocket57, Rocket58 },
        { Rocket61, Rocket62, Rocket63, Rocket64, Rocket65, Rocket66, Rocket67, Rocket68 },
        { Rocket71, Rocket72, Rocket73, Rocket74, Rocket75, Rocket76, Rocket77, Rocket78 },
        { Rocket81, Rocket82, Rocket83, Rocket84, Rocket85, Rocket86, Rocket87, Rocket88 },
        };

        SetRocketsIndex();
    }

    public void SetRocketsIndex()
    {
        for (int v = 0; v < Rockets.GetLength(0); v++)
        {
            for (int h = 0; h < Rockets.GetLength(1); h++)
            {
                Rockets[v, h].GetComponent<Rocket_Obj>().RocketIndexV = v;
                Rockets[v, h].GetComponent<Rocket_Obj>().RocketIndexH = h;
            }
        }
    }

    public void FullCheckForMatches()
    {
        for (int v = 0; v < Rockets.GetLength(0); v++)
        {
            for (int h = 0; h < Rockets.GetLength(1); h++)
            {
                Rockets[v, h].GetComponent<Rocket_Type>().CheckForMatches();
            }
        }
    }
}

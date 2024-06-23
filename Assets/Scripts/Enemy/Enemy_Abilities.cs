using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Abilities : MonoBehaviour
{
    private Enemy_Main Enemy;
    private Player_Main Player;
    [HideInInspector] public int AbilityID;

    public float BasicDamage;

    public int ShieldNumber = 0;
    public int DiscordNumber = 0;

    public int ShieldTurns;
    public int DiscordTurns;

    private void Start()
    {
        Enemy = FindObjectOfType<Enemy_Main>();
        Player = FindObjectOfType<Player_Main>();

    }

    public void EnemyUseAbility()
    {
        AbilityID = Random.Range(1, 40);// 1 Basic Attack, 2 - RocketsBlock, 3 - Element Shield, 4 - Elemental Discord, 5 - Minions
        Debug.Log("AbilityID: " + AbilityID);

        if(AbilityID <= 20)
            BasicAttack();
        else if(AbilityID <= 25)
            StrongAttack();
        else if (AbilityID <= 30)
            ElementalShield();
        else if (AbilityID <= 35)
            ElementalDiscord();
        else if (AbilityID <= 40)
            SpawnMinions();
            
    }

    public void BasicAttack()
    {
        Player.TakeDamage(BasicDamage);
        Enemy.EnemyActionText.text = "Attack(" + BasicDamage + ")";
    }

    public void StrongAttack()
    {
        float DoubleDamage = BasicDamage * 2;
        Player.TakeDamage(DoubleDamage);
        Enemy.EnemyActionText.text = "Crit(" + DoubleDamage + ")";
    }

    public void ElementalShield()
    {
        ShieldNumber = Random.Range(2, 5); // чтобы число стакалось с типом ракет
        Enemy.EnemyActionText.text = "Shield";
    }

    public void ElementalDiscord()
    {
        DiscordNumber = Random.Range(2, 5); // чтобы число стакалось с типом ракет
        Enemy.EnemyActionText.text = "Discord";
    }

    public void SpawnMinions()
    {
        Enemy.MinionsNumber = 3;
        Enemy.EnemyActionText.text = "Minions";
    }
}

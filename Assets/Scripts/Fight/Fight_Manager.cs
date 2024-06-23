using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fight_Manager : MonoBehaviour
{
    private Player_Main Player;
    private Enemy_Main Enemy;

    private Enemy_Abilities EnemyAbilities;
    private Enemy_DiscordAbility EnemyDiscord;


    private Rocket_HQ rocketHQ;
    private Rocket_SpawnType rocketSpawnType;
   

    public bool PlayerTurn = true;
    public bool playerMoved = false;

    public bool GameStarted = false;

    public TextMeshProUGUI WhosTurnText;

    public GameObject WinScreen;
    public GameObject LoseScreen;

    private void Start()
    {
        Player = FindObjectOfType<Player_Main>();
        Enemy = FindObjectOfType<Enemy_Main>();
        EnemyAbilities = FindObjectOfType<Enemy_Abilities>();
        EnemyDiscord = FindObjectOfType<Enemy_DiscordAbility>();

        rocketHQ = FindObjectOfType<Rocket_HQ>();
        rocketSpawnType = FindObjectOfType<Rocket_SpawnType>();

        StartCoroutine(TurnFunc());

    }

    #region TurnFunc

    IEnumerator TurnFunc()
    {
        if(PlayerTurn)
        {
            yield return new WaitForSeconds(1.5f);
            WhosTurnText.text = "Player Turn";
            yield return new WaitForSeconds(2);
            WhosTurnText.text = "";

            if (GameStarted)
            {
                rocketSpawnType.RocketsResetType();
                EnemyDiscord.DiscordRocketType(EnemyAbilities.DiscordNumber);

            }

            yield return new WaitForSeconds(1);

            while (!playerMoved)
            {
                yield return new WaitForSeconds(1);
            }
        }
        else
        {
            yield return new WaitForSeconds(1.5f);
            WhosTurnText.text = "Enemy Turn";
            yield return new WaitForSeconds(2);
            WhosTurnText.text = "";

            if (Enemy.isBurned)
            {
                EnemyIsBurned();
            }

            if (Enemy.isFrozen)
            {
                Enemy.isFrozen = false;
            }
            else
            {
                EnemyAbilities.EnemyUseAbility();
                Enemy.EnemyActionText.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(1);
            Enemy.EnemyActionText.gameObject.SetActive(false);

            if (EnemyAbilities.ShieldNumber > 0)
            {
                EnemyIsShielded();
            }
            if(EnemyAbilities.DiscordNumber > 0)
            {
                EnemyUsedDiscord();
            }

            Debug.Log("EnemyMoved");
            yield return new WaitForSeconds(1);
        }

        ChangeTurn();
    }

    public void ChangeTurn()
    {
        StopAllCoroutines();
        if (PlayerTurn)
        {
            PlayerTurn = false;
        }
        else
        {
            PlayerTurn = true;
            playerMoved = false;
        }

        StartCoroutine(TurnFunc());
    }

    #endregion

    #region Enemy_Effects

    private void EnemyIsBurned()
    {
        if(Enemy.isBurned)
        {
            Enemy.TakeDamage(1, 2);
            Enemy.burnedTurns--;

            if (Enemy.burnedTurns <= 0)
            {
                Enemy.isBurned = false;
            }
        }
    }

    private void EnemyIsShielded()
    {
        if(EnemyAbilities.ShieldNumber > 0)
        {
            EnemyAbilities.ShieldTurns--;

            if(EnemyAbilities.ShieldTurns <= 0)
            {
                EnemyAbilities.ShieldNumber= 0;
            }
        }
    }

    private void EnemyUsedDiscord()
    {
        if (EnemyAbilities.DiscordNumber > 0)
        {
            EnemyDiscord.DiscordRocketType(EnemyAbilities.DiscordNumber);

            EnemyAbilities.DiscordTurns--;

            if (EnemyAbilities.DiscordTurns <= 0)
            {
                EnemyDiscord.UnDiscordRocketType();
                EnemyAbilities.DiscordNumber = 0;
            }
        }
    }

    #endregion

    public void HPCheck()
    {
        if(Enemy.currentHealth <= 0)
        {
            WinScreen.SetActive(true);
            GameStarted = false;
            playerMoved = true;
        }
        if(Player.currentHealth <= 0)
        {
            LoseScreen.SetActive(true);
            GameStarted = false;
            playerMoved = true;
        }
    }



}

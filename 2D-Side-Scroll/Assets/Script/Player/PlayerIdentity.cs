using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerIdentity : MonoBehaviour
{
    public static PlayerIdentity Instance{get;private set;}
    private int cherryScore;
    [SerializeField]private int health;
    private const string PLAYER_PREFS_PLAYER_DEAD_HEALTH = "PlayerLastHealth";
    private const string PLAYER_PREFS_PLAYER_CHERRY = "PlayerCherry";

    public event EventHandler OnGameOver;
    private void Awake() {
        Instance = this;
        if(PlayerPrefs.HasKey(PLAYER_PREFS_PLAYER_DEAD_HEALTH)){
            health = PlayerPrefs.GetInt(PLAYER_PREFS_PLAYER_DEAD_HEALTH);
        }
        if(PlayerPrefs.HasKey(PLAYER_PREFS_PLAYER_CHERRY)){
            cherryScore = PlayerPrefs.GetInt(PLAYER_PREFS_PLAYER_CHERRY);
        }
    }
    public int GetCherryScore(){
        return cherryScore;
    }
    public int GetHealth(){
        return health;
    }

    public void changeCherryScore(int changes){
        cherryScore+= changes;
    }
    public void changeHealth(int changes){
        health+= changes;
        if(health <= 0){
            health = 0;
            ScrollGameManager.Instance.gameEnding();
            OnGameOver?.Invoke(this, EventArgs.Empty);
        }
    }

    public void saveIdentity(int health, int cherry){
        PlayerPrefs.SetInt(PLAYER_PREFS_PLAYER_DEAD_HEALTH, health);
        PlayerPrefs.SetInt(PLAYER_PREFS_PLAYER_CHERRY, cherry);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScrollGameManager : MonoBehaviour
{
    public static ScrollGameManager Instance {get; private set;}
    private enum StateGame{
        WaitingToStart, GameStart, GameOver
    }
    private const string PLAYER_PREFS_PLAYER_DEAD_HEALTH = "PlayerLastHealth";
    
    private StateGame state;

    public event EventHandler OnLoadScreen;

    private void Awake() {
        Instance = this;

        state = StateGame.WaitingToStart;
    }
    
    private void Start() {
        if(state == StateGame.WaitingToStart){
            StartCoroutine(LoadScreen());
        }
        
    }

    public void gameEnding(){
        state = StateGame.GameOver;
    }
    public bool isGameStart(){
        return state == StateGame.GameStart;
    }

    private IEnumerator LoadScreen(){
        yield return new WaitForSeconds(0.1f);
        OnLoadScreen?.Invoke(this,EventArgs.Empty);
        state = StateGame.GameStart;
    }
}




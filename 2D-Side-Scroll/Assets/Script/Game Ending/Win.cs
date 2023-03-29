using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private const string PLAYER = "Player";
    private const string PLAYER_PREFS_PLAYER_DEAD_HEALTH = "PlayerLastHealth";
    private const string PLAYER_PREFS_PLAYER_CHERRY = "PlayerCherry";
    public event EventHandler OnEnding;
    [SerializeField]private PlayerMovementController playerMovement;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(PLAYER)){
            if(SceneManager.GetActiveScene().name == "Level1"){
                PlayerIdentity playerIdentity = PlayerIdentity.Instance;
                playerIdentity.saveIdentity(playerIdentity.GetHealth(), playerIdentity.GetCherryScore());
                SceneManager.LoadScene("Level2");
            }
            else if(SceneManager.GetActiveScene().name == "Level2"){
                playerMovement.winning();
                
                ScrollGameManager.Instance.gameEnding();
                PlayerIdentity playerIdentity = PlayerIdentity.Instance;
                playerIdentity.saveIdentity(10, 0);
                
                OnEnding?.Invoke(this,EventArgs.Empty);
            }
            
        }
    }
}

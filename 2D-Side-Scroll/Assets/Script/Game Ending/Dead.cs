using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Dead : MonoBehaviour
{
    private const string PLAYER = "Player";
    private const string PLAYER_PREFS_PLAYER_DEAD_HEALTH = "PlayerLastHealth";
    private const string PLAYER_PREFS_PLAYER_CHERRY = "PlayerCherry";


    private void OnTriggerEnter2D(Collider2D other) {
        if(ScrollGameManager.Instance.isGameStart()){
            if(other.gameObject.CompareTag(PLAYER)){
                
                
                PlayerIdentity playerIdentity = PlayerIdentity.Instance;
                // if(playerIdentity.GetHealth() != 0){
                //     OnFall?.Invoke(this,EventArgs.Empty);
                //     Debug.Log("Jeder");
                // }
                playerIdentity.saveIdentity(playerIdentity.GetHealth(), 0);
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        
    }
}

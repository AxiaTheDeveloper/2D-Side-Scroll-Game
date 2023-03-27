using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInteractController : MonoBehaviour
{
    [SerializeField]private PlayerIdentity playerIdentity;
    [SerializeField]private PlayerMovementController playerMovement;
    private const string COLLECTABLE = "Collectable";
    private const string ENEMY = "Enemy";


    public event EventHandler OnCollectCherry;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(COLLECTABLE)){
            int point = other.GetComponent<CollectableController>().GetCollectablePoint();
            playerIdentity.changeCherryScore(point);
            Destroy(other.gameObject);
            
            OnCollectCherry?.Invoke(this,EventArgs.Empty);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(ENEMY)){
            
            if(!playerMovement.GetIsOnGround()){
                // int point = other.gameObject.GetComponent<CollectableController>().GetCollectablePoint();
                // playerIdentity.changeCherryScore(point);
                playerMovement.GotKillEnemyForce();
                Destroy(other.gameObject);
            }
            else{
                
                EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
                int damage = enemy.GetDamage();
                playerIdentity.changeHealth(-damage);
                float hurtForce = enemy.GetHurtForce();
                
                if(other.gameObject.transform.position.x > transform.position.x){
                    playerMovement.GotHurtForce(-hurtForce);
                }
                else{
                    playerMovement.GotHurtForce(hurtForce);
                }
                
                
                Debug.Log(playerIdentity.GetHealth());
            }
            
        }
    }


}

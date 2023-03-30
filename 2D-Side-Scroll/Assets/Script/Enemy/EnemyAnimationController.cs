using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    protected Animator animatorController;
    private EnemyController enemyController;
    private const string IS_DEATH = "IsDeath";

    private void Awake() {
        animatorController = GetComponent<Animator>();
        
    }
    

    private void Suicide(){
        Destroy(transform.parent.gameObject);
    }

    private void playExplosionSound(){
        SoundEffectManager.Instance.PlayEnemyExplosion();
    }
    protected void enemyController_OnDeath(object sender, System.EventArgs e){
        // Debug.Log("Boom");
        if(animatorController){
            animatorController.SetTrigger(IS_DEATH);
        }
        
    }
}

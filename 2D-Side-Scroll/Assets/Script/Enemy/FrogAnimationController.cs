using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimationController : EnemyAnimationController
{
    [SerializeField]private FrogController frogController;
    // [SerializeField]private EnemyController enemyController;
    
    private const string IS_JUMP = "IsJump";


    
    private void Start() {
        animatorController.SetBool(IS_JUMP, false);
        frogController.OnJump += frogController_OnJump;
        frogController.OnLand += frogController_OnLand;
        frogController.OnDeath += enemyController_OnDeath; // si death ada di enemy animation controller utama
        
        // Debug.Log(player.getIsJalan());
    }

    
    
    private void frogController_OnJump(object sender, System.EventArgs e){
        animatorController.SetBool(IS_JUMP, true);
    }
    private void frogController_OnLand(object sender, System.EventArgs e){
        animatorController.SetBool(IS_JUMP, false);
    }
    private void move(){
        // Debug.Log("Jump");
        frogController.jumpFrog();
    }


    
}

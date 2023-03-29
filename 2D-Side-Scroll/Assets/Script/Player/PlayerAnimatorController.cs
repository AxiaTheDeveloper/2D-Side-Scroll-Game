using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private PlayerMovementController playerMovement;
    private Animator animatorController;
    private const string IS_JALAN = "IsJalan";
    private const string IS_LONCAT = "IsLoncat";
    private const string IS_HURT = "IsHurt";
    private const string IS_CLIMB = "IsClimb";


    private void Awake() {
        animatorController = GetComponent<Animator>();
        
    }
    private void Start() {
        animatorController.SetBool(IS_JALAN, false);
        animatorController.SetBool(IS_LONCAT, false);
        animatorController.SetBool(IS_HURT, false);
        animatorController.SetBool(IS_CLIMB, false);
        playerMovement.OnLoncat += playerMove_OnLoncat;
        playerMovement.OnGround += playerMove_OnGround;
        
        playerMovement.OnHurt += playerMove_OnHurt;
        playerMovement.OnNotHurt += playerMove_OnNotHurt;
        // Debug.Log(player.getIsJalan());

        playerMovement.OnPowerUp += playerMove_OnPowerUp;
        playerMovement.OnPowerOff += playerMove_OnPowerOff;

        playerMovement.OnClimb += playerMove_OnClimb;
        playerMovement.OnNotClimb += playerMove_OnNotClimb;
    }

    private void playerMove_OnClimb(object sender, System.EventArgs e){
        animatorController.SetBool(IS_CLIMB, true);
        // animatorController.speed = 1f;
    }
    private void playerMove_OnNotClimb(object sender, System.EventArgs e){
        animatorController.SetBool(IS_CLIMB, false);
        // animatorController.speed = 1f;
    }

    private void playerMove_OnPowerUp(object sender, System.EventArgs e){
        GetComponent<SpriteRenderer>().color = Color.blue;
    }
    private void playerMove_OnPowerOff(object sender, System.EventArgs e){
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void playerMove_OnLoncat(object sender, System.EventArgs e){
        animatorController.SetBool(IS_LONCAT, true);
    }
    private void playerMove_OnGround(object sender, System.EventArgs e){
        animatorController.SetBool(IS_LONCAT, false);
    }

    private void playerMove_OnHurt(object sender, System.EventArgs e){
        animatorController.SetBool(IS_HURT, true);
    }
    private void playerMove_OnNotHurt(object sender, System.EventArgs e){
        animatorController.SetBool(IS_HURT, false);
    }

    private void Update(){
        // Debug.Log(player.getIsJalan());

        //kalooo climb
        animatorController.SetBool(IS_JALAN, playerMovement.GetIsJalan());
        
    }
}

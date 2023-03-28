using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField]private SoundEffectManager soundEffect;
    [SerializeField]private PlayerMovementController playerMovement;
    [SerializeField]private PlayerInteractController playerInteract;
    // private void Awake() {
    //     soundEffect = SoundEffectManager.Instance;
    // }
    private void Start() {
        playerMovement.OnLoncat += playerMovement_OnLoncat;
        playerInteract.OnCollectCherry += playerInteract_OnCollectCherry;
    }
    private void PlayFootStep(){
        soundEffect.PlayPlayerFootStep();
    }
    private void playerMovement_OnLoncat(object sender, System.EventArgs e){
        soundEffect.PlayJump();
    }
    private void playerInteract_OnCollectCherry(object sender, System.EventArgs e){
        soundEffect.PlayGetCherry();
    }
}

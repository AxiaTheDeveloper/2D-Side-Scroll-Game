using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private const string PLAYER = "Player";
    private PlayerMovementController playerMovement;
    private enum LadderPart {
        full, bottom, top
    };
    [SerializeField]private LadderPart part = LadderPart.full;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(PLAYER)){
            playerMovement = other.gameObject.GetComponent<PlayerMovementController>();
            
            if(part == LadderPart.full){
                playerMovement.ChangeCanClimb(true);
                playerMovement.ladder = this;
            }
            else if(part == LadderPart.bottom){
                playerMovement.ChangeAtBottom(true);
            }
            else if(part == LadderPart.top){
                playerMovement.ChangeAtTop(true);
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag(PLAYER)){
            playerMovement = other.gameObject.GetComponent<PlayerMovementController>();
            
            if(part == LadderPart.full){
                playerMovement.ChangeCanClimb(false);
            }
            else if(part == LadderPart.bottom){
                playerMovement.ChangeAtBottom(false);
            }
            else if(part == LadderPart.top){
                playerMovement.ChangeAtTop(false);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationController : MonoBehaviour
{
    [SerializeField]private PlayerMovementController playerMovement;
    private float arahRotasi;

    private void Update() {
        Berotasi();
    }

    private void Berotasi(){
        arahRotasi = playerMovement.GetKeyInputX();
        if(arahRotasi == 1){
            transform.localScale = new Vector2(1,1);
        }
        else if(arahRotasi == -1){
            transform.localScale = new Vector2(-1,1);
        }
        
        
    }
}

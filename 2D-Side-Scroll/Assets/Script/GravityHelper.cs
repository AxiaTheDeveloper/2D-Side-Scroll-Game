using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHelper : MonoBehaviour
{
    private const string PLAYER = "Player";
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(PLAYER)){
            other.gameObject.GetComponent<PlayerMovementController>().enabled = false;
        }
    }
}

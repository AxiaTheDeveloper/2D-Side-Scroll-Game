using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Win : MonoBehaviour
{
    private const string PLAYER = "Player";
    public event EventHandler OnEnding;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(PLAYER)){
            OnEnding?.Invoke(this,EventArgs.Empty);
        }
    }
}

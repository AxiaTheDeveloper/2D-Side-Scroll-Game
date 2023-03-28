using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FrogController : EnemyController
{
    [SerializeField]private float jarakLoncat, tinggiLoncat;
    private Collider2D coll;
    [SerializeField]private LayerMask layerGround;
    private Rigidbody2D rb;
    private const string FOREGROUND = "Foreground";
    
    public event EventHandler OnJump, OnLand;
    
    private void Awake() {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        // jumpFrog();
        if(isDead){
            rb.bodyType = RigidbodyType2D.Kinematic;
            coll.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(FOREGROUND) && !isDead){
            // isOnGround = true;
            OnLand?.Invoke(this,EventArgs.Empty);
        }
    }

    public void jumpFrog(){
        if(!isDead){
            if(facingLeft){
                if(transform.position.x > pointKiri){
                    
                    if(transform.localScale.x != 1){
                        transform.localScale = new Vector3(1,1,1);
                    }

                    if(coll.IsTouchingLayers(layerGround)){
                        // Debug.Log("yesleft");
                        rb.velocity = new Vector2(-jarakLoncat, tinggiLoncat);
                        OnJump?.Invoke(this, EventArgs.Empty);
                    }
                }
                else{
                    facingLeft = false;
                }
            }
            else{
                if(transform.position.x < pointKanan){
                    // Debug.Log("yesright");
                    if(transform.localScale.x != -1){
                        transform.localScale = new Vector3(-1,1,1);
                    }

                    if(coll.IsTouchingLayers(layerGround)){
                        rb.velocity = new Vector2(jarakLoncat, tinggiLoncat);
                        OnJump?.Invoke(this, EventArgs.Empty);
                    }
                }
                else{
                    facingLeft = true;
                }
            }
        }
    }

}

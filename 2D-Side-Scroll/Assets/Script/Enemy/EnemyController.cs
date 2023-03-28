using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    [SerializeField]private int enemyDamage;
    [SerializeField]private float hurtForce;

    [SerializeField]protected float pointKiri, pointKanan;

    public event EventHandler OnDeath;

    protected bool facingLeft = true;
    protected bool isDead = false;

    public void death(){
        isDead = true;
        // Debug.Log("Poi");
        OnDeath?.Invoke(this,EventArgs.Empty);
    }
    
    
    public int GetDamage(){
        return enemyDamage;
    }
    public float GetHurtForce(){
        return hurtForce;
    }
}

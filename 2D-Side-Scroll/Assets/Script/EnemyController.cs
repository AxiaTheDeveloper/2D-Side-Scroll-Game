using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]private int enemyDamage;
    [SerializeField]private float hurtForce;

    public int GetDamage(){
        return enemyDamage;
    }
    public float GetHurtForce(){
        return hurtForce;
    }
}

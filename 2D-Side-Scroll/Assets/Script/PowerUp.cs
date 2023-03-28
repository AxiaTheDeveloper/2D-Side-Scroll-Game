using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]private float powerUpPower;

    public float GetPowerUpPower(){
        return powerUpPower;
    }
}

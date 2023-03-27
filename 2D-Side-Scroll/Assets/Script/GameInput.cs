using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance {get; private set;}

    private float keyInputX;

    private bool isLoncat = false;

    private void Awake() {
        Instance = this;
    }

    public float GetInputMovement(){
        keyInputX = 0;
        if(Input.GetKey(KeyCode.D)) keyInputX = 1;
        if(Input.GetKey(KeyCode.A)) keyInputX = -1;

        return keyInputX;
    }

    public bool GetInputJump(){
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            isLoncat = true;
        }
        else{
            isLoncat = false;
        }
        
        return isLoncat;
    }
}

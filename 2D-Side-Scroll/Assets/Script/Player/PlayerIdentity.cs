using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdentity : MonoBehaviour
{
    private int cherryScore;
    [SerializeField]private int health;

    public int GetCherryScore(){
        return cherryScore;
    }
    public int GetHealth(){
        return health;
    }



    public void changeCherryScore(int changes){
        cherryScore+= changes;
    }
    public void changeHealth(int changes){
        health+= changes;
    }
}

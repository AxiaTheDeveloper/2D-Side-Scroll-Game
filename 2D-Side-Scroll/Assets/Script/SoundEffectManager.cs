using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager Instance{get; private set;}

    [SerializeField]private AudioSource footstep;
    [SerializeField]private AudioSource explosionEnemy;
    [SerializeField]private AudioSource jump;
    [SerializeField]private AudioSource getCherry;

    private void Awake() {
        Instance = this;
    }


    public void PlayPlayerFootStep(){
        footstep.Play();
    }

    public void PlayEnemyExplosion(){
        explosionEnemy.Play();
    }

    public void PlayJump(){
        jump.Play();
    }

    public void PlayGetCherry(){
        getCherry.Play();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    private const string PLAYER = "Player";
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(PLAYER)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

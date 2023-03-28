using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField]private PlayerMovementController playerMovement;
    [SerializeField]private PlayerIdentity playerIdentity;
    [SerializeField]private TextMeshProUGUI Health;
    private void Start() {
        playerMovement.OnHurt += playerMove_OnHurt;
        UpdateHealthVisual();
    }

    private void UpdateHealthVisual(){
        Health.text = "Health: " + playerIdentity.GetHealth().ToString();
    }

    private void playerMove_OnHurt(object sender, System.EventArgs e){
        UpdateHealthVisual();
    }

}

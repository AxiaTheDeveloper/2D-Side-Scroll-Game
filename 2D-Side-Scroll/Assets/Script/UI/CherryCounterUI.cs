using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CherryCounterUI : MonoBehaviour
{
    [SerializeField]private PlayerInteractController playerInteract;
    [SerializeField]private PlayerIdentity playerIdentity;
    [SerializeField]private TextMeshProUGUI Cherry;
    private void Start() {
        playerInteract.OnCollectCherry += playerScore_OnCollectCherry;
        UpdateCherryScoreVisual();
    }

    private void UpdateCherryScoreVisual(){
        Cherry.text = playerIdentity.GetCherryScore().ToString();
    }

    private void playerScore_OnCollectCherry(object sender, System.EventArgs e){
        UpdateCherryScoreVisual();
    }
}

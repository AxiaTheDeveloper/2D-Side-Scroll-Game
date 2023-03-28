using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Win winEnd;
    void Start()
    {
        hide();
        winEnd.OnEnding += winEnd_OnEnding;
    }
    private void winEnd_OnEnding(object sender, System.EventArgs e){
        show();
    }

    private void show(){
        gameObject.SetActive(true);
    }
    private void hide(){
        gameObject.SetActive(false);
    }
}

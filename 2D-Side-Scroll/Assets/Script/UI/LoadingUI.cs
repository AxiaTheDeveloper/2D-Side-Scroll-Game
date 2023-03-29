using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    // [SerializeField]private ScrollGameManager scrollGame;
    void Start()
    {
        show();
        ScrollGameManager.Instance.OnLoadScreen += scrollGame_OnLoadScreen;
    }
    private void scrollGame_OnLoadScreen(object sender, System.EventArgs e){
        hide();
    }
    private void show(){
        gameObject.SetActive(true);
    }
    private void hide(){
        gameObject.SetActive(false);
    }
}

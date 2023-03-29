using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Win winEnd;
    private CanvasGroup canvas;
    private void Awake() {
        canvas = GetComponent<CanvasGroup>();
    }
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
        canvas.alpha = 0;
        canvas.LeanAlpha(1, 0.5f);
        transform.LeanScale(Vector2.one, 0.8f);
    }
    private void hide(){
        transform.LeanScale(Vector2.zero, 1f);
        gameObject.SetActive(false);
    }
}

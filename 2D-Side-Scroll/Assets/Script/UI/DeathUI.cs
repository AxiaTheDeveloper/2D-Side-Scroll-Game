using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    [SerializeField]private PlayerIdentity playerIdentity;
    [SerializeField]private Button restartButton;
    private const string PLAYER_PREFS_PLAYER_DEAD_HEALTH = "PlayerLastHealth";
    private const string PLAYER_PREFS_PLAYER_CHERRY = "PlayerCherry";
    private CanvasGroup canvas;
    private void Awake() {
        restartButton.onClick.AddListener(() => {
            PlayerIdentity playerIdentity = PlayerIdentity.Instance;
            playerIdentity.saveIdentity(10, 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        
        canvas = GetComponent<CanvasGroup>();
    }
    void Start()
    {
        hide();
        playerIdentity.OnGameOver += playerIdentity_OnGameOver;
    }
    private void playerIdentity_OnGameOver(object sender, System.EventArgs e){
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

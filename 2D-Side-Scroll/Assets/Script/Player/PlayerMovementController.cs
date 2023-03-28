using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]GameInput gameInput;

    [SerializeField]private float kecepatanPlayer, loncatPower;

    private float saveLoncatPower;
    private bool isJalan, isOnGround, isHurt;

    
    private float keyInputX;
    private Vector3 arahGerak = new Vector3(0,0,0);


    private const float PERKALIAN_LONCAT = 100;
    private const string FOREGROUND = "Foreground";


    private Collider2D coll;
    [SerializeField]private LayerMask layerGround;

    //event
    public event EventHandler OnLoncat, OnGround, OnHurt, OnNotHurt, OnPowerUp, OnPowerOff;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }
    private void Start() {
        isOnGround = false;
        isJalan = false;
        isHurt = false;
        
    }
    private void Update()
    {

        if(!isHurt){
            Move();
            Jump();
        }

        if(isHurt){
            if(Mathf.Abs(rb.velocity.x) < 0.1f){
                OnNotHurt?.Invoke(this,EventArgs.Empty);
                isHurt = false;
                // Debug.Log("Phew");
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(FOREGROUND)){
            isOnGround = true;
            OnGround?.Invoke(this,EventArgs.Empty);
        }
    }

    private void Move(){
        keyInputX = gameInput.GetInputMovement();
        arahGerak.Set(keyInputX,0f,0f);
        isJalan = (arahGerak != Vector3.zero);
        transform.position += (arahGerak * kecepatanPlayer * Time.deltaTime);
        // Debug.Log(transform.position);
    }

    private void Jump(){
        if(gameInput.GetInputJump() && coll.IsTouchingLayers(layerGround)){
            // Debug.Log("Yes");
            isOnGround = false;
            
            OnLoncat?.Invoke(this,EventArgs.Empty);
            rb.AddForce(new Vector2(0, 1) * loncatPower * PERKALIAN_LONCAT);
            
        }
    }

    public void GotKillEnemyForce(){
        rb.AddForce(new Vector2(0, 1) * loncatPower * PERKALIAN_LONCAT);
        // Debug.Log("POI");
    }

    public void GotHurtForce(float hurtForce){
        // OnGround?.Invoke(this,EventArgs.Empty);
        isHurt = true;
        OnHurt?.Invoke(this,EventArgs.Empty);
        // OnLoncat?.Invoke(this,EventArgs.Empty);
        rb.velocity = new Vector2(hurtForce, rb.velocity.y);
        // Debug.Log("Ouch");
    }
    

    public Vector3 GetArahGerak(){
        return arahGerak;
    }
    public float GetKeyInputX(){
        return keyInputX;
    }
    public bool GetIsJalan(){
        return isJalan;
    }
    public bool GetIsOnGround(){
        return isOnGround;
    }

    // public void ChangeKecepatan(float change){
    //     saveKecepatanPlayer = kecepatanPlayer;
    //     kecepatanPlayer = change;
    // }
    public void ChangeLoncatPower(float change){
        saveLoncatPower = loncatPower;
        loncatPower += change;
        OnPowerUp?.Invoke(this,EventArgs.Empty);
        StartCoroutine(ResetPower());
    }

    private IEnumerator ResetPower(){
        yield return new WaitForSeconds(10);
        loncatPower = saveLoncatPower;
        OnPowerOff?.Invoke(this,EventArgs.Empty);

    }
}

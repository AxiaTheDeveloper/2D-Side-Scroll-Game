using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]GameInput gameInput;

    [SerializeField]private float kecepatanPlayer, loncatPower, climbSpeed;

    private float saveLoncatPower;
    private bool isJalan, isOnGround, isHurt, canClimb, atBottomLadder, atTopLadder;

    
    private float keyInputX, keyInputY, normalGravity;
    private Vector3 arahGerak = new Vector3(0,0,0);
    private Vector3 arahGerakLadder = new Vector3(0,0,0);


    private const float PERKALIAN_LONCAT = 100;
    private const string FOREGROUND = "Foreground";


    private Collider2D coll;
    [SerializeField]private LayerMask layerGround;

    //event
    public event EventHandler OnLoncat, OnGround, OnHurt, OnNotHurt, OnPowerUp, OnPowerOff, OnClimb, OnNotClimb;

    public Ladder ladder;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }
    private void Start() {
        isOnGround = false;
        isJalan = false;
        isHurt = false;
        canClimb = false;
        atBottomLadder = false;
        atTopLadder = false;
        normalGravity = rb.gravityScale;
    }
    private void Update()
    {
        if(ScrollGameManager.Instance.isGameStart()){
            if(!isHurt){
                Move();
                if(!canClimb){
                    OnNotClimb?.Invoke(this,EventArgs.Empty);
                    Jump();
                    if(atBottomLadder){
                        OnGround?.Invoke(this,EventArgs.Empty);
                    }
                }
                
                if(canClimb){
                    OnClimb?.Invoke(this,EventArgs.Empty);
                    Climb();
                }
            }

            if(isHurt){
                if(Mathf.Abs(rb.velocity.x) < 0.1f){
                    OnNotHurt?.Invoke(this,EventArgs.Empty);
                    isHurt = false;
                    // Debug.Log("Phew");
                }
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

    private void Climb(){
        keyInputY = gameInput.GetInputMovementY();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; 
        rb.gravityScale = 0f;
        arahGerakLadder.Set(0f,keyInputY,0f);
        transform.position = new Vector3(ladder.transform.position.x, rb.position.y);
        
        if((keyInputY == 1 && !atTopLadder) || (keyInputY == -1 && !atBottomLadder)){
            // Debug.Log("Go" + keyInputY);
            transform.position += (arahGerakLadder * climbSpeed * Time.deltaTime);
        }
        else{
            rb.velocity = Vector2.zero;
        }
        if(gameInput.GetInputJump()){
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = normalGravity;
            canClimb = false;
            OnLoncat?.Invoke(this,EventArgs.Empty);
            if(atTopLadder){
                rb.AddForce(new Vector2(0, 1) * loncatPower * PERKALIAN_LONCAT);
            }
        }
        
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
    public bool GetCanClimb(){
        return canClimb;
    }
    public bool GetAtBottom(){
        return atBottomLadder;
    }
    public bool GetAtTop(){
        return atTopLadder;
    }
    public void ChangeCanClimb(bool change){
        canClimb = change;
        
    }
    public void ChangeAtBottom(bool change){
        atBottomLadder = change;
    }
    public void ChangeAtTop(bool change){
        atTopLadder = change;
    }

    public void winning(){
        isJalan = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVC;
    [SerializeField]private float shakeIntensity, shakeTime;

    private CinemachineBasicMultiChannelPerlin _chmcp;
    [SerializeField]private PlayerInteractController playerInteract;
    // [SerializeField]private Dead dead;
    private void Awake() {
        cinemachineVC = GetComponent<CinemachineVirtualCamera>();
    }
    private void Start() {
        playerInteract.OnHit += playerInteract_OnHit;

    }


    private void playerInteract_OnHit(object sender, System.EventArgs e){
        
        ShakeCamera();
        
    }

    private void ShakeCamera(){
        CinemachineBasicMultiChannelPerlin _chmcp = cinemachineVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _chmcp.m_AmplitudeGain = shakeIntensity;
        StartCoroutine(Shakeee());
    }
    private void StopShake(){
        CinemachineBasicMultiChannelPerlin _chmcp = cinemachineVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _chmcp.m_AmplitudeGain = 0f;
    }

    private IEnumerator Shakeee(){
        yield return new WaitForSeconds(shakeTime);
        StopShake();
    }
}

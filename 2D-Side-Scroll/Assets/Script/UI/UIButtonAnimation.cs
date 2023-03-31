using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIButtonAnimation : MonoBehaviour
{
    
    public void OnHoverButton(){
        LeanTween.scale(gameObject, new Vector3(1.5f, 1.5f, 1f), 0.5f).setEase(LeanTweenType.easeOutExpo);
    }
    
    public void OnNotHoverButton(){
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.2f).setEase(LeanTweenType.easeInElastic);
    }

}

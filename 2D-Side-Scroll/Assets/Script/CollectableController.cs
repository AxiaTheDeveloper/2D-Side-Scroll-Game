using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [SerializeField]private int collectablePoint;

    public int GetCollectablePoint(){
        return collectablePoint;
    }
}

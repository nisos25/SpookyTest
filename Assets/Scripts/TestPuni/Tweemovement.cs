using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tweemovement : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        Tween myTween = transform.DOMove(target.position, 1).OnComplete(() => Debug.Log("cosito"));
    }

    
  
}

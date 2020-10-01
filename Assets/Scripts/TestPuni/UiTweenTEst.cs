using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UiTweenTEst : MonoBehaviour
{
    RectTransform rectTransform;

    public Vector2 startPos;

    public float sizePos;
    public GameObject[] elementsUI;

    private bool isAnimating;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Debug.Log(rectTransform.rect.x);
        StartCoroutine(LateStart());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && !isAnimating)
        {
            CerrarCortina();
        }
        if(Input.GetKeyDown(KeyCode.L) && !isAnimating)
        {
            AbrirCortina();
        }
    }

    void CerrarCortina()
    {
        isAnimating = true;
        rectTransform.DOAnchorPos(Vector2.zero, 1).OnComplete(()=>ShowButtons());
    }
    void AbrirCortina()
    {
        isAnimating = true;
        rectTransform.DOAnchorPosX(sizePos * 2, 2).OnPlay(() => HideButtons()).OnComplete(() => isAnimating = false); ;
    }

    void HideButtons()
    {
        foreach(GameObject obj in elementsUI)
        {
            obj.GetComponent<RectTransform>().DOScale(Vector2.zero, 0.2f);
        }
    }

    void ShowButtons()
    {
        foreach(GameObject obj in elementsUI)
        {
            obj.transform.DOScale(Vector2.one, 0.2f);
        }
        isAnimating = false;
    }

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        sizePos = rectTransform.rect.x;
        sizePos = rectTransform.anchorMin.x > 0 ? -sizePos : sizePos;
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PeekView : MonoBehaviour, IDragHandler, IEndDragHandler
{
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().DOAnchorPosY(-500, 0.5f);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().DOAnchorPosY(0, 0.5f);
    }
}

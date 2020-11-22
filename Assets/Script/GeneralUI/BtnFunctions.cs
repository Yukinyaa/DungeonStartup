using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class BtnFunctions : MonoBehaviour
{
    private IEnumerator waitThenCallback(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback();
    }
    public enum BtnType
    {
        None,
        LoadQuickSave,
        QuickSave,
        HideThis,
        ShowThis
    }
    public BtnType function;

    public int arg_int = 0;
    public Transform arg_transform;
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => OnClick());

        /*
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((e) => OnPointerDown());
        trigger.triggers.Add(pointerDown);

        trigger = gameObject.AddComponent<EventTrigger>();
        var pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener((e) => OnPointerUp());
        */

    }
    public void OnClick()
    {
        switch (function)
        {
            case BtnType.HideThis:
                arg_transform.transform.DOLocalMoveX(800, 1);
                break;
            case BtnType.ShowThis:
                arg_transform.transform.DOLocalMoveX(-10, 1)
                    .OnComplete(() => arg_transform.DOLocalMoveX(0, 0.5f));
                break;

        }
    }
}

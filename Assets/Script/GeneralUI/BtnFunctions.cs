using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
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
        ShowThis,
        GoToBattle,
        GoToDelever,
        GoToAssemble
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
        System.Collections.Generic.IReadOnlyList<Item> eq;
        switch (function)
        {
            case BtnType.HideThis:
                arg_transform.transform.DOLocalMoveX(800, 0.5f);
                break;
            case BtnType.ShowThis:
                arg_transform.transform.DOLocalMoveX(-10, 0.5f)
                    .OnComplete(() => arg_transform.DOLocalMoveX(0, 0.5f));
                break;
            case BtnType.GoToAssemble:
                UISupervisor.Instance.ActivateUI(UISupervisor.UIViews.Assemble);
                break;
            case BtnType.GoToBattle:
                eq = InventoryManager.Instance.EquippedItems;
                if (eq.Any(a => a.type == Item.ItemType.body) &&
                    eq.Any(a => a.type == Item.ItemType.head) &&
                    eq.Any(a => a.type == Item.ItemType.leg) &&
                    eq.Any(a => a.type == Item.ItemType.weapon)
                    )

                {
                    //go to battle here
                    UISupervisor.Instance.ActivateUI(UISupervisor.UIViews.Battle);
                    GameManager.Instance.StartBattle();
                }
                
                break;
            case BtnType.GoToDelever:
                eq = InventoryManager.Instance.EquippedItems;
                if (QuestManager.Instance.ActivatedQuest.enemies == null || UISupervisor.Instance.CurrentView == UISupervisor.UIViews.Battle)
                    if (eq.Any(a => a.type == Item.ItemType.body) &&
                    eq.Any(a => a.type == Item.ItemType.head) &&
                    eq.Any(a => a.type == Item.ItemType.leg))
                    {
                        UISupervisor.Instance.ActivateUI(UISupervisor.UIViews.ConfirmDelever);
                        ConfirmDeleverUI.Instance.Refresh();
                    }
                        
                break;

        }
    }
}

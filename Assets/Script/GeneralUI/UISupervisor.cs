using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class UISupervisor : Singleton<UISupervisor>
{

    public enum UIViews {
        Quest, Assemble, Battle, ConfirmDelever
    }
    public UIViews CurrentView { get; private set; }

    [SerializeField]
    RectTransform questUI, assembleUI, battleUI, confirmDeleverUI;
    [SerializeField]
    GameObject bunker;
    [SerializeField]
    float hidePos = 3000;

    RectTransform currentUI;

    private void Start()
    {
        Camera.main.GetComponent<CameraControl>().target = bunker;
        questUI?.DOLocalMoveY(hidePos, 1);
        assembleUI?.DOLocalMoveY(hidePos, 1);
        battleUI?.DOLocalMoveY(hidePos, 1);
        confirmDeleverUI?.DOLocalMoveY(hidePos, 1);
        currentUI = questUI;
        currentUI.DOLocalMoveY(hidePos, 1);
        currentUI.DOLocalMoveY(0, 1);
        CurrentView = UIViews.Quest;
    }

    public RectTransform Enum2Transform(UIViews select)
    {
        switch (select)
        {
            case UIViews.Quest: return questUI;
            case UIViews.Assemble: return assembleUI;
            case UIViews.Battle: return battleUI;
            case UIViews.ConfirmDelever: return confirmDeleverUI;
            default: return null;
        }
    }
    public void ActivateUI(UIViews select)
    {
        if (select != UIViews.Battle)
            Camera.main.GetComponent<CameraControl>().target = bunker;
        currentUI.DOLocalMoveY(hidePos, 1);
        currentUI = Enum2Transform(select);
        currentUI.DOLocalMoveY(0, 1);
        CurrentView = select;
    }
}

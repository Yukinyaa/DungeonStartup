using UnityEngine;
using System.Collections;

public class ShowMeTheMoneyCheat : AbstractCheatCode
{

    protected override void OnActivateCheat()
    {
        InventoryManager.Instance.money += 10000;
        InventoryManager.Instance.ui.RefreshUI();
    }


    void Awake()
    {
        cheatCode = new KeyCode[] {
            KeyCode.S,
    KeyCode.H,
    KeyCode.O,
    KeyCode.W,
    KeyCode.M,
    KeyCode.E,
    KeyCode.T,
    KeyCode.H,
    KeyCode.E,
    KeyCode.M,
    KeyCode.O,
    KeyCode.N,
    KeyCode.E,
    KeyCode.Y,
        };
    }
}

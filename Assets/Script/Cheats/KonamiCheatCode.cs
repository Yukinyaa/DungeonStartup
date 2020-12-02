using UnityEngine;
using System.Collections;

public class KonamiCheatCode : AbstractCheatCode
{

    protected override void OnActivateCheat()
    {
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["광선검"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["광선검"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["역장 생성기"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["역장 생성기"]);
    }


    void Awake()
    {
        cheatCode = new KeyCode[] {
            KeyCode.UpArrow,
            KeyCode.UpArrow,
            KeyCode.DownArrow,
            KeyCode.DownArrow,
            KeyCode.LeftArrow,
            KeyCode.RightArrow,
            KeyCode.LeftArrow,
            KeyCode.RightArrow,
            KeyCode.B,
            KeyCode.A
        };
    }
}

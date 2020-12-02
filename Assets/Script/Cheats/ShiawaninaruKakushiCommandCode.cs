using UnityEngine;
using System.Collections;

public class ShiawaninaruKakushiCommandCode : AbstractCheatCode
{

    protected override void OnActivateCheat()
    {
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["광선검"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["광선검"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["광선검"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["광선검"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["광선검"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["광선검"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["광선검"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["광선검"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["광선검"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["광선검"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["광선검"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["광선검"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["역장 생성기"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["역장 생성기"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["역장 생성기"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["역장 생성기"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["역장 생성기"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["역장 생성기"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["역장 생성기"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["역장 생성기"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["역장 생성기"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["역장 생성기"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["역장 생성기"]);
        InventoryManager.Instance.AddToInventory(ItemDB.ItemDic["역장 생성기"]);
      
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }


    void Awake()
    {
        cheatCode = new KeyCode[] {
            KeyCode.RightArrow,
            KeyCode.DownArrow,
            KeyCode.UpArrow,
            KeyCode.RightArrow,

            KeyCode.RightArrow,
            KeyCode.DownArrow,
            KeyCode.RightArrow,
            KeyCode.RightArrow,

            KeyCode.UpArrow,
            KeyCode.UpArrow,
            KeyCode.DownArrow,
            KeyCode.DownArrow,

            KeyCode.LeftArrow,
            KeyCode.RightArrow,
            KeyCode.LeftArrow,
            KeyCode.RightArrow,



            KeyCode.R,
            KeyCode.E,
            KeyCode.S,
            KeyCode.E,
            KeyCode.T,
        };
    }
}

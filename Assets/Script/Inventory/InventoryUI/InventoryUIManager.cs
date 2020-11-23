using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Debug;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField]
    public InventoryManager invManager;
    [SerializeField]
    GameObject itemSlotPF;
    [SerializeField]
    Transform inventoryContent, activeItemContent;
    [SerializeField]
    TextMeshProUGUI statSumUI;
    [SerializeField]
    TextMeshProUGUI moneyText;

    [SerializeField]
    ItemInfoUI ui;


    Sprite blankSlot;

    // Start is called before the first frame update
    void Start()
    {
        Assert(invManager != null);
        Assert(itemSlotPF != null);
        Assert(inventoryContent != null);
        Assert(activeItemContent != null);

        blankSlot = Resources.Load<Sprite>("Sprites/none");
        

        RefreshUI();
    }


    List<ItemSlot> inventorySlots, equipItemSlots;



    public void RefreshUI()
    {
        inventorySlots = inventorySlots ?? new List<ItemSlot>(inventoryContent.GetComponentsInChildren<ItemSlot>());
        equipItemSlots = equipItemSlots ?? new List<ItemSlot>(activeItemContent.GetComponentsInChildren<ItemSlot>());
        moneyText.text = "보유 재화: " + invManager.money.ToString();
        while (inventorySlots.Count < 10)
        {
            NewSlot();
        }



        foreach (var slot in inventorySlots)
        {
            slot.Init(blankSlot, blankSlot, this, null);
        }
        var inventory = invManager.Inventory;

        
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventorySlots.Count <= i)
                NewSlot();
            SetSlot(inventorySlots[i], inventory[i], false);
        }
        
        var eqItems = invManager.equippedItems;
        for (int i = 0; i < equipItemSlots.Count; i++)
        {
            var itype = equipItemSlots[i].typeRestriction;
            
            SetSlot(equipItemSlots[i], eqItems.FirstOrDefault(a => a.type == itype), true);
        }
        var stats = from eitem in eqItems select eitem.stat;
        var statSum = stats.Aggregate(
                new Stat(),
                (sum, a) =>
                    sum = a + sum
                );
        statSumUI.text = statSum.ToString(true);


    }

    internal void EquipItem(ItemSlot from)
    {
        invManager.EquipItem(from.item);
        RefreshUI();
    }

    ItemSlot shownSlot = null;
    internal void ShowItemText(ItemSlot slot)
    {
        if (slot.item == null) return;
        if (shownSlot == slot)
            return;
        if (shownSlot != slot)
        {
            shownSlot = slot;
            ui.gameObject.SetActive(true);
            ui.UpdateText(
                slot.item.nameText,
                slot.item.tooltipText,
                slot.item.flavorText
                );
        }
    }
    internal void HideItemText(ItemSlot slot)
    {
        if (shownSlot != slot)
            return;
        ui.Hide();
        shownSlot = null;
    }
    internal void UnequipItem(ItemSlot itemSlot)
    {
        if (equipItemSlots.Exists(a => a == itemSlot))
        {
            invManager.UnEquipItem(itemSlot.item);
        }
        RefreshUI();
    }

    ItemSlot NewSlot()
    {
        var slot = Instantiate(itemSlotPF, inventoryContent).
            GetComponent<ItemSlot>();
        inventorySlots.Add(slot);
        return slot;
    }
    void SetSlot(ItemSlot s, Item itemInfo, bool isActiveItemSlot = false)
    {
        if (itemInfo == null)
        {
            s.Init(
                Resources.Load<Sprite>(BackgroundRairity[0]),
                blankSlot,
                this,
                itemInfo,
                isActiveItemSlot
                );
        }
        else
        {
            s.Init(
                Resources.Load<Sprite>(BackgroundRairity[0]),
                Resources.Load<Sprite>("Sprites/Items/" + itemInfo.codeName),
                this,
                itemInfo,
                isActiveItemSlot
            );
        }
        
    }
    public IReadOnlyList<string> BackgroundRairity = new List<string>
    {
        "Sprites/ItemSlot/All"
    };
}

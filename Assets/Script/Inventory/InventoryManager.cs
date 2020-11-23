using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public IReadOnlyList<Item> Inventory { get { return inventory; } }
    public IReadOnlyList<Item> equippedItems { get { return equppedItems; } }
    public List<Item> inventory = new List<Item>();
    public List<Item> equppedItems = new List<Item>();
    public InventoryUIManager ui;
    public float money = 100000;

    public void Start()
    {
        AddToInventory(ItemDB.Items.First(a => a.codeName == "Head1"));
        AddToInventory(ItemDB.Items.First(a => a.codeName == "Body1"));
    }
    public void AddToInventory(Item i)
    {
        inventory.Add(new Item(i));
        ui.RefreshUI();
    }
    public bool EquipItem(Item i)
    {
        if (equppedItems.Any(eqItem => eqItem.type == i.type))
        {
            Debug.LogError("Assertion Failed, Tried to equip same item");
            return false;
        }
        
        if (inventory.Remove(i) == false)
            return false;

        equppedItems.Add(i);
        return true;
    }
    public bool UnEquipItem(Item i)
    {
        if (equppedItems.Remove(i) == false)
            return false;

        inventory.Add(i);
        return true;
    }

}
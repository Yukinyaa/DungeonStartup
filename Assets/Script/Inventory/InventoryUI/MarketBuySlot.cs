using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;



public class MarketBuySlot : MonoBehaviour
{
    [SerializeField] int price;
    [SerializeField] string itemcode;



    [SerializeField] ItemSlot ItemSlot;
    [SerializeField] TMPro.TextMeshProUGUI priceText;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] Button buyButton;


    [HideInInspector] public Item item;

    

    // Use this for initialization
    [ExecuteInEditMode]
    void Start()
    {
        item = ItemDB.Items.FirstOrDefault(a => a.codeName == itemcode);
        ItemSlot.Init(
                Resources.Load<Sprite>("Sprites/ItemSlot/All"), 
                Resources.Load<Sprite>("Sprites/Items/" + itemcode),
                inventoryManager.ui,
                item,
                false
                );
        ItemSlot.isImgOnly = true;
        priceText.text = "가격: " + price.ToString();
        Debug.Assert(item != null);
        buyButton.onClick.AddListener(() => OnClick());
    }
    public void OnClick()
    {
        if (price > inventoryManager.money) return;
        inventoryManager.money -= price;
        inventoryManager.AddToInventory(new Item(item));
    }





}

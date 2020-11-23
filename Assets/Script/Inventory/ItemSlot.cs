using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemSlot : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public Image backgroundImage;
    public Image itemImage;
    public InventoryUIManager parent;
    public Item item;
    public bool isEquipmentSlot = false;
    public Item.ItemType typeRestriction;
    public bool isImgOnly = false;
    
    public void Init(Sprite backgroundSprite, Sprite itemSprite, InventoryUIManager parent, Item ie, bool isActiveSlot = false)
    {
        backgroundImage.sprite = backgroundSprite;
        itemImage.sprite = itemSprite;
        this.parent = parent;
        this.item = ie;
        this.isEquipmentSlot = isActiveSlot;
        //if(isActiveSlot == false)
        //    gameObject.SetActive(ie == null ? false : true);
    }

    public void OnDrag(PointerEventData data)
    {
        if (isImgOnly) return;
        itemImage.transform.parent = parent.transform;
        itemImage.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (isImgOnly) return;
        itemImage.transform.SetParent(this.transform, true);
        itemImage.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        ItemSlot target = RaycastMouse().Select(a => a.gameObject.GetComponent<ItemSlot>()).FirstOrDefault(a => a != null);

        if (target == null || target.isEquipmentSlot == false || target.item != null)
        {
            if (this.isEquipmentSlot == true)
                parent.UnequipItem(this);
            return;
        }

        if (this.isEquipmentSlot == false)
            parent.EquipItem(this);
        if (this.isEquipmentSlot == true)
            parent.UnequipItem(this);
    }

    //from: https://answers.unity.com/questions/1009987/detect-canvas-object-under-mouse-because-only-some.html?_ga=2.85083865.1727764624.1593864048-1629740874.1572570134
    public List<RaycastResult> RaycastMouse()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            pointerId = -1,
        };

        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        //Debug.Log(results.Count);

        return results;
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (isImgOnly) return;
        if (data.button == PointerEventData.InputButton.Right)
        {
            if (this.isEquipmentSlot == true)
                parent.UnequipItem(this);
            else
                parent.EquipItem(this);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        parent.ShowItemText(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        parent.HideItemText(this);
    }
}

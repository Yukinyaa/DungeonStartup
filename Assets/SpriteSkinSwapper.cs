using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSkinSwapper : MonoBehaviour
{
    [SerializeField]
    List<Sprite> skins;
    [SerializeField]
    public Item.ItemType partType;
    public void SwapSkin(int? i)
    {
        if (i != null)
            GetComponent<SpriteRenderer>().sprite = skins[(int)i];
        else
            GetComponent<SpriteRenderer>().sprite = null;
    }
}

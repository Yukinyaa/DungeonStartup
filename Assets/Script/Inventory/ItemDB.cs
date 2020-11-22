using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static  class ItemDB
{

    public static List<Item> Items
        = new List<Item>{
            new Item(Item.Rairity.normal,
                "Head1",
                "하치코볼",
                "이것은 하치코볼입니다",
                Item.ItemType.head,
                new Stat(
                    1, 1, -1, 0, 0, 0, 0
                    )
                )

        };
}

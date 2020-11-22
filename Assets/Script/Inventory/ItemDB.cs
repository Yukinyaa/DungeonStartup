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
                        1, 1, -1, 0, 0, 0, 0, 0
                    )
                ),


            new Item(Item.Rairity.normal,
                "Body1",
                "아무튼 몸통임",
                "이것은 하치코볼입니다",
                Item.ItemType.body,
                new Stat(
                        1, 1, 3, 0, 0, 0, 0, 0
                    )
                )

        };
}

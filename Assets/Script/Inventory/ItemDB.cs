using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public static class ItemDB
{
    static Dictionary<string, Item> itemdic;
    static public IReadOnlyDictionary<string, Item> ItemDic
    {
        get {
            return itemdic = itemdic ?? CreateItemDic();
        }
    }
    static Dictionary<string, Item> CreateItemDic()
    {
        var dic = new Dictionary<string, Item>();
        foreach (Item i in Items)
        {
            dic.Add(i.nameText, i);
        }
        return dic;
    }

    public static List<Item> Items
        = new List<Item>{
            new Item(
                "KnightHead",
                "인간 기사의 머리",
                "신념이 깃든 눈빛.",
                Item.ItemType.head,
                new Stat()
                {
                    atk = 20,
                    def = 30,
                    maxhp = 30,
                    atkrng = 10,
                    beauty = 10
                }

                ),


            new Item(
                "KnightBody",
                "인간 기사의 몸",
                "신념을 두른 갑옷.",
                Item.ItemType.body,
                new Stat()
                {
                    atk = 40,
                    def = 40,
                    maxhp = 40,
                    atkspd = 10,
                    beauty = 10
                }
            ),


            new Item(
                "KnightLeg",
                "인간 기사의 다리",
                "신념을 받드는 다리.",
                Item.ItemType.body,
                new Stat()
                {
                    atk = 20,
                    def = 40,
                    maxhp = 30,
                    mvspd = 10,
                    beauty = 10
                }
            ),
            new Item(
                "OrkHead",
                "오크 전사의 머리",
                "소심하게 드러낸 반항심.",
                Item.ItemType.head,
                new Stat()
                {
                    atk = 20,
                    def = 20,
                    maxhp = 20,
                    atkrng = 10,
                    beauty = -10
                }

                ),


            new Item(
                "OrkBody",
                "오크 전사의 몸",
                "한껏 뽐내는 과시욕.",
                Item.ItemType.body,
                new Stat()
                {
                    atk = 20,
                    def = 20,
                    maxhp = 30,
                    atkspd = 20,
                    beauty = 20
                }
            ),


            new Item(
                "OrkLeg",
                "오크 전사의 다리",
                "간신히 숨겨진 조급함.",
                Item.ItemType.body,
                new Stat()
                {
                    atk = 30,
                    def = 30,
                    maxhp = 30,
                    mvspd = 30,
                    beauty = -20
                }
            ),
            new Item(
                "ElfHead",
                "엘프 탐험가의 머리",
                "도난 당한 세계수의 가지를 찾는 중.",
                Item.ItemType.head,
                new Stat()
                {
                    atk = 10,
                    def = 10,
                    maxhp = 30,
                    atkrng = 40,
                    beauty = 20
                }

                ),


            new Item(
                "ElfBody",
                "엘프 탐험가의 몸",
                "도난 당한 세계수의 가지를 찾는 중.",
                Item.ItemType.body,
                new Stat()
                {
                    atk = 20,
                    def = 10,
                    maxhp = 20,
                    atkspd = 30,
                    beauty = 10
                }
            ),


            new Item(
                "ElfLeg",
                "엘프 탐험가의 다리",
                "도난 당한 세계수의 가지를 찾는 중.",
                Item.ItemType.body,
                new Stat()
                {
                    atk = 10,
                    def = 20,
                    maxhp = 20,
                    mvspd = 30,
                    beauty = 20
                }
            ),
            new Item(
                "SeletonHead",
                "해골 암살자의 머리",
                "복면은 충치를 가리기 위한 용도.",
                Item.ItemType.head,
                new Stat()
                {
                    atk = 40,
                    def = 40,
                    maxhp = 30,
                    atkrng = 20,
                    beauty = 00
                }

                ),


            new Item(
                "SeletonBody",
                "해골 암살자의 몸",
                "달그락.",
                Item.ItemType.body,
                new Stat()
                {
                    atk = 10,
                    def = 10,
                    maxhp = 10,
                    atkspd = 20,
                    beauty = -10
                }
            ),


            new Item(
                "SeletonLeg",
                "해골 암살자의 다리",
                "부들부들.",
                Item.ItemType.body,
                new Stat()
                {
                    atk = 20,
                    def = 10,
                    maxhp = 10,
                    mvspd = 40,
                    beauty = -10
                }
            ),

            /*********************************/
            


            new Item(
                "B_Bat",
                "방망이",
                "방망이 깎는 노인이 서둘러 깎은 방망이.",
                Item.ItemType.weapon,
                new Stat()
                {
                    atk = 20,
                    atkspd = -10,
                    atkrng = 4,
                    beauty = -10
                }
            ),

            new Item(
                "Knife",
                "식칼",
                "백주부가 사용하던 식칼.",
                Item.ItemType.weapon,
                new Stat()
                {
                    atk = 40,
                    atkspd = 50,
                    atkrng = -50,
                    beauty = 1
                }
            ),

            new Item(
                "HolyBranch",
                "세계수의 가지",
                "세계수에서 꺾어 온 나뭇가지.",
                Item.ItemType.weapon,
                new Stat()
                {
                    atk = 80,
                    atkspd = 1,
                    atkrng = 60,
                    beauty = -10
                }
            ),

            new Item(
                "LSaber",
                "광선검",
                "과학기술의 진수.",
                Item.ItemType.weapon,
                new Stat()
                {
                    atk = 60,
                    atkspd = 100,
                    atkrng = 50,
                    beauty = 20
                }
            ),

            /*************************************/

            

            new Item(
                "Kite",
                "연",
                "창고에 버려져 있던 연.",
                Item.ItemType.shield,
                new Stat()
                {
                    def = 5,
                    beauty = 20
                }
            ),
            new Item(
                "IShield",
                "강철방패",
                "장인이 만든 방패.",
                Item.ItemType.shield,
                new Stat()
                {
                    def = 20,
                    beauty = 5
                }
            ),
            new Item(
                "Turtle",
                "거북이",
                "평범한 거북이.",
                Item.ItemType.shield,
                new Stat()
                {
                    def = 40,
                    beauty = -10
                }
            ),
            new Item(
                "FFGenerator",
                "역장 생성기",
                "과학기술의 정수.",
                Item.ItemType.shield,
                new Stat()
                {
                    def = 80,
                    beauty = -20
                }
            ),


        };
}

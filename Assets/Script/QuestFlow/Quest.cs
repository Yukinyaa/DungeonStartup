using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class QuestDB
{
    private static List<Quest> quests;

    public static List<Quest> Quests
    {
        get { if(quests==null) Init(); return quests; }
        set => quests = value;
    }


    public static void Init()
    {
        quests = new List<Quest>() {
            new Quest(){
                title = "정기 납품",
                subtitle = "최대대규모모던던전에 납품",
                desc = "최대 대규모 모던 던전에\n아래 조건을 만족하는 캐릭터를 만들어 납품하자.",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("공격력 10 이상", stat => stat.atk >= 10),
                    new QuestStatCond("아름다움 20 이상", stat => stat.beauty >= 20)
                },
                enemies = null,
                rewardMoney = 500,
                startingbody = new List<Item>
                {
					//none
				},
                thumbnail = Resources.Load<Sprite>("Sprites/QThumbs/S_Sword15")
            },
            new Quest(){
                title = "해골 수확기",
                subtitle = "해골 수확기 검증 및 납품",
                desc = "요즘 마을에 해골 암살자가 자주 등장한다네.\n\n그것들을 물리칠 수 있는 견고하고 빠른 무언가가 필요해.\n해골 병사를 하나 줄테니 개조해서 그것들을 정리할 수 있는걸 만들어 주게나.",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("이동속도 20 이상", stat => stat.mvspd >= 20),
                    new QuestStatCond("방어력 10 이상", stat => stat.def >= 10),
                    new QuestStatCond("공격속도 10 이상", stat => stat.atkspd >= 10),
                    new QuestStatCond("체력 80 이상", stat => stat.maxhp >= 80)
                },
                enemies = new List<EnemyInfo> {
                    new EnemyInfo("해골 방맹이 암살자",
                                                        new List<Item>{
                                                            ItemDB.ItemDic["해골 암살자의 머리" ],
                                                            ItemDB.ItemDic["해골 암살자의 몸"],
                                                            ItemDB.ItemDic["해골 암살자의 다리"],
                                                            ItemDB.ItemDic["방망이"] }
                                            , 3)
                },
                rewardMoney = 1000,
                startingbody = new List<Item>
                {
					ItemDB.ItemDic["해골 암살자의 머리" ],
                    ItemDB.ItemDic["해골 암살자의 몸"],
                    ItemDB.ItemDic["해골 암살자의 다리"],
                    ItemDB.ItemDic["방망이"]
                },
                thumbnail = Resources.Load<Sprite>("Sprites/QThumbs/I_Bone")
            },

            new Quest(){
                title = "이상취향",
                subtitle = "기괴한 의뢰",
                desc = "이상한 취향을 가진 의뢰인이 자신이 사랑하는 하인을 고쳐달라 보내왔다.\n 이런 게 진짜 좋은 걸까?",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("기괴함 50 이상", stat => stat.beauty <= -50),
                    new QuestStatCond("공격력 100 이하", stat => stat.atk <= 100)
                },
                enemies = null,
                rewardMoney = 2000,
                startingbody = new List<Item>
                    {
						ItemDB.ItemDic["엘프 탐험가의 머리"],
                        ItemDB.ItemDic["오크 전사의 몸"],
                    },
                    thumbnail =  Resources.Load<Sprite>("Sprites/QThumbs/I_Scroll")
            },

            new Quest(){
                title = "오크 학살",
                subtitle = "셀라스 오크 척결 연합의 의뢰",
                desc = "하인 원한다. 오크 육억마리 학살. 오크 멍청. 오크 없앤다.\n오크 열마리 죽임. 증명.",
                statConditions = new List<QuestStatCond>
                {
                },
                enemies = new List<EnemyInfo> {
                    new EnemyInfo("오크 전사",
                                                        new List<Item>
                {
                        ItemDB.ItemDic["오크 전사의 머리"],
                        ItemDB.ItemDic["오크 전사의 몸"],
                        ItemDB.ItemDic["오크 전사의 다리"],
                        ItemDB.ItemDic["방망이"]
                }, 10)
                },
                rewardMoney = 5000,
                startingbody = new List<Item>
                {
                        ItemDB.ItemDic["오크 전사의 머리"],
                        ItemDB.ItemDic["오크 전사의 몸"],
                        ItemDB.ItemDic["오크 전사의 다리"],
                        ItemDB.ItemDic["방망이"]
                },
                thumbnail =  Resources.Load<Sprite>("Sprites/QThumbs/I_Torch02")
            },

            new Quest(){
                title = "푸른빌빌라라동동문문지기",
                subtitle = "푸른빌 빌라 라동 동문 문지기 구함",
                desc = "푸른빌 라동에 무서운 문지기가 필요하다.",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("기괴함 60 이상", stat => stat.beauty <= -60),
                    new QuestStatCond("공격력 70 이상", stat => stat.atk >= 70)
                },
                enemies = null,
                rewardMoney = 1000,
                startingbody = new List<Item>
                {
                        ItemDB.ItemDic["오크 전사의 머리"],
                        ItemDB.ItemDic["오크 전사의 몸"],
                        ItemDB.ItemDic["오크 전사의 다리"],
                        ItemDB.ItemDic["방망이"]
                },
                thumbnail =  Resources.Load<Sprite>("Sprites/QThumbs/E_Wood03")
            }
        };
    }
}

/*************************************************************/

public class QuestStatCond
{
    public string Desc { get; private set; }
    public Func<Stat, bool> Cond { get; private set; }

    public QuestStatCond(string desc, Func<Stat, bool> cond)
    {
        Desc = desc; Cond = cond;
    }
}
public class EnemyInfo
{
    public string Name { get; private set; }
    public List<Item> Item { get; private set; }
    public int SpawnCount { get; set; }

    public EnemyInfo(string name, List<Item> item, int spawnCount = 1)
    {
        Name = name;
        Item = item;
        SpawnCount = spawnCount;
    }
    public EnemyInfo(EnemyInfo cpy, int? spawncount = null)
    {
        Name = cpy.Name;
        Item = new List<Item>(cpy.Item);
        SpawnCount = spawncount ?? cpy.SpawnCount;
    }
    public override string ToString()
    {
        return SpawnCount == 1 ?
            Name :
            Name + "<size=60%>x" + SpawnCount + "</size>";
    }
}

/*************************************************************/

public class Quest
{
    public string title;
    public string subtitle;
    public string desc;
    public Sprite thumbnail;


    public List<QuestStatCond> statConditions;
    public List<EnemyInfo> enemies;



    public int rewardMoney;
    public List<Item> startingbody;


    public string CondToString(Stat currentStat, bool showenemy = true)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<size=120%><b>완료 조건</b></size>\n");
        foreach (var cond in statConditions)
        {
            sb.Append(cond.Cond(currentStat) ? "<color=green>Ok</color>" : "<color=red>bad</color>");
            sb.Append(" - ");
            sb.Append(cond.Desc);
            sb.Append("\n");
        }
        if (enemies != null && showenemy)
        {
            foreach (var enemy in enemies)
            {
                sb.Append(enemy.ToString());
                if (enemies.Last() != enemy)
                    sb.Append(", ");
            }

            sb.Append(" 처치");
        }


        return sb.ToString();
    }
}

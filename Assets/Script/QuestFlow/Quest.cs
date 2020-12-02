using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class QuestDB
{
    private static List<Quest> quests;

    public static List<Quest> Quests { get { Init(); return quests; } set => quests = value; }

    public static void Init()
    {
        quests = new List<Quest>() {
            new Quest(){
                title = "평범한 퀘스트",
                subtitle = "이것은 테스트인데수웅",
                desc = "평범하게 긴퀘스트 설명,\n돋고, 위하여서, 것은 커다란 길지 봄바람을 꽃이 힘있다. 대중을 놀이 무엇이 이 이상 풀밭에 인간은 황금시대다.",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("공격력 10 이상", stat => stat.atk >= 10),
                    new QuestStatCond("공격력 0 이상", stat => stat.atk >= 0)
                },
                enemies = null,
                rewardMoney = 500,
                startingbody = new List<Item>
                {
                    ItemDB.Items.FirstOrDefault(i=>i.codeName == "Head1")
                },
                thumbnail = null
            },
            new Quest(){
                title = "더 평범한 퀘스트",
                subtitle = "이것은 테스트인데수웅22",
                desc = "평범하게 짧은 퀘스트 설명",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("기괴함 10 이상", stat => stat.beauty <= -10),
                    new QuestStatCond("공격력 0 이상", stat => stat.atk >= 0)
                },
                enemies = null,
                rewardMoney = 500,
                startingbody = new List<Item>
                {
                    ItemDB.Items.FirstOrDefault(i=>i.codeName == "Head1"),
                    ItemDB.Items.FirstOrDefault(i=>i.codeName == "Body1"),
                },
                thumbnail = null
            },

            new Quest(){
                title = "복붙한 평범한 퀘스트",
                subtitle = "이것은 테스트인데수웅33",
                desc = "평범하게 짧은 퀘스트 설명",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("기괴함 10 이상", stat => stat.beauty <= -10),
                    new QuestStatCond("공격력 0 이상", stat => stat.atk >= 0)
                },
                enemies = null,
                rewardMoney = 500,
                startingbody = new List<Item>
                {
                    ItemDB.Items.FirstOrDefault(i=>i.codeName == "Head1"),
                    ItemDB.Items.FirstOrDefault(i=>i.codeName == "Body1"),
                },
                thumbnail = null
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
            Name + "<size=40%>x" + SpawnCount + "</size>";
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


    public string CondToString(Stat currentStat, bool showenemy = true) {
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
                if(enemies.Last() != enemy)
                    sb.Append(", ");
            }

            sb.Append(" 처치");
        }
        

        return sb.ToString();
    }
}

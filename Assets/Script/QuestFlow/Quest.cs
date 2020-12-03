using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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

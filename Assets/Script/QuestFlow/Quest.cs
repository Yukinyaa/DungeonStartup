using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    new QuestStatCond("공격력 10 이상", stat => stat.atk > 10)
                },
                enemies = null,
                rewardMoney = 500,
                startingbody = new List<Item>
                {
                    ItemDB.Items.FirstOrDefault(i=>i.codeName == "head1")
                }
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

/*************************************************************/

public class Quest
{
    public string title;
    public string subtitle;
    public string desc;
    public List<QuestStatCond> statConditions;
    public List<Tuple<string, List<Item>>> enemies;

    public int rewardMoney;
    public List<Item> startingbody;


    public string CondToString(Stat currentStat) {
        StringBuilder sb = new StringBuilder();
        sb.Append("<size=200%>조건</size>\n");
        foreach (var cond in statConditions)
        {
            sb.Append(cond.Cond(currentStat) ? "<color=green>Ok</color>" : "<color=red>bad</color>");
            sb.Append(" - ");
            sb.Append(cond.Desc);
            sb.Append("\n");
        }
        if (enemies != null)
        {
            foreach (var enemy in enemies)
            {
                sb.Append(enemy.Item1);
                if(enemies.Last() != enemy)
                    sb.Append(", ");
            }

            sb.Append(" 처치");
        }
        

        return sb.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SelectQuestUI : Singleton<SelectQuestUI>
{
    [SerializeField]
    List<QuestListUI> questList;
    [SerializeField]
    TextMeshProUGUI title, subtitle, startunitstat, cond, desc;
    [SerializeField]
    Image thumbnail;
    [SerializeField]
    List<Image> enemyThumb;
    [SerializeField]
    List<TextMeshProUGUI> enemyName;

    [SerializeField]
    Button acceptButton;

    Quest selectedQuest;
    Sprite emptySprite;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(questList.Count == 3);
        emptySprite = Resources.Load<Sprite>("Sprites/none");
        selectedQuest = null;
        UpdateUI();
        acceptButton.onClick.AddListener(
            () => QuestManager.Instance.AcceptQuest(selectedQuest)
            );
    }

    public void SelectQuest(Quest q)
    {
        selectedQuest = q;
        UpdateUI();
    }

    public void UpdateUI()
    {
        var quests = QuestManager.Instance.Quests;
        for (int i = 0; i < 3; i++)
        {
            var quest = quests[i];
            questList[i].Init(
                quest.title, quest.subtitle + "      <align=\"right\"><size=110%><color=yellow>" + quest.rewardMoney + "</color>원", 
                quest.thumbnail);
            questList[i].quest = quest;
        }


        if (selectedQuest != null)
        {
            var startUnitStat = (from item in selectedQuest.startingbody
                                 select item.stat).Aggregate(new Stat(), (a, b) => a + b);
            title.text = selectedQuest.title;
            subtitle.text = selectedQuest.subtitle + "      <align=\"right\"><size=60%><color=yellow>" + selectedQuest.rewardMoney + "</color>원";
            cond.text = selectedQuest.CondToString(startUnitStat);
            startunitstat.text = "시작 능력치: \n"+ startUnitStat.ToString().Replace('\n', ' ');
            desc.text = selectedQuest.desc;
            thumbnail.sprite = selectedQuest.thumbnail;


            var enemies = selectedQuest.enemies;
            for (int i = 0; i < 3; i++)
            {
                if (enemies == null || i >= enemies.Count)
                {
                    enemyName[i].text = "";
                    enemyThumb[i].sprite = emptySprite;
                }
                else
                {
                    enemyName[i].text = enemies[i].Name + "<size=40%>x" + enemies[i].SpawnCount + "\n"+
                        (from item in enemies[i].Item select item.stat).Aggregate(new Stat(), (a, b) => a + b).ToString().Replace('\n',' ');
                    enemyThumb[i].sprite =
                        enemies[i].Item.FirstOrDefault(item => item.type == Item.ItemType.head).Thumbnail
                        ?? emptySprite;
                    enemyThumb[i].preserveAspect = true;
                }
            }
        }
        else
        {
            title.text = "";
            subtitle.text = "";
            cond.text = "";
            desc.text = "";
            startunitstat.text = "";
            thumbnail.sprite = emptySprite;

            for (int i = 0; i < 3; i++)
            {
                enemyName[i].text = "";
                enemyThumb[i].sprite = emptySprite;
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class ConfirmDeleverUI : Singleton<ConfirmDeleverUI>
{
    [SerializeField]
    Button accept;
    [SerializeField]
    TextMeshProUGUI title, sub, cond;
    public void Start()
    {
        accept.onClick.AddListener(Accept);
    }
    public void Accept()
    {
        var quest = QuestManager.Instance.ActivatedQuest;
        InventoryManager.Instance.money += quest.rewardMoney;
        InventoryManager.Instance.equippedItems = new List<Item>();
        InventoryManager.Instance.ui.RefreshUI();
        UISupervisor.Instance.ActivateUI(UISupervisor.UIViews.Quest);
        QuestManager.Instance.Init();
    }
    public void Refresh()
    {
        var stat = (from item in InventoryManager.Instance.equippedItems select item.stat)
                        .Aggregate(new Stat(), (a, b) => a + b);

        var quest = QuestManager.Instance.ActivatedQuest;
        quest.CondToString(stat);
        if (quest.statConditions.Any(q => !(q.Cond(stat))))
            accept.enabled = false;
        else
            accept.enabled = true;

        title.text = quest.title;
        sub.text = quest.subtitle;
        cond.text = quest.CondToString(stat);
        
    }


}

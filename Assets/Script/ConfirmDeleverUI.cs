using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class ConfirmDeleverUI : Singleton<ConfirmDeleverUI>
{
    Button accept, deny;
    TextMeshProUGUI title, sub, cond;
    public void Accept()
    {
        var quest = QuestManager.Instance.ActivatedQuest;
        InventoryManager.Instance.money += quest.rewardMoney;
        
    }
    public void Init()
    {
        var stat = (from item in InventoryManager.Instance.equippedItems select item.stat)
                        .Aggregate(new Stat(), (a, b) => a + b);

        var quest = QuestManager.Instance.ActivatedQuest;
        quest.CondToString(stat);
        if (quest.statConditions.Any(q => !(q.Cond(stat))))
            accept.enabled = false;
        else
            accept.enabled = true;

        
    }


}

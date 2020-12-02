using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    public IReadOnlyList<Quest> Quests { get => quests; }
    List<Quest> quests = new List<Quest>();
    public Quest ActivatedQuest { get; private set; }

    void AddRandomQuestUntil3()
    {
        while (quests.Count < 3)
        {
            var rndQuest = QuestDB.Quests.RandomItem();
            if (!quests.Exists(q=>q==rndQuest)) 
            {
                quests.Add(rndQuest);
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        AddRandomQuestUntil3();
        SelectQuestUI.Instance.UpdateUI();
    }


    public void AcceptQuest(Quest q)
    {
        if (q == null) return;
        ActivatedQuest = q;

        //change "scene"
        InventoryManager.Instance.equippedItems = new List<Item>(q.startingbody);
        InventoryManager.Instance.ui.RefreshUI();

        
        
        

        //activate finish buttons



    }

}

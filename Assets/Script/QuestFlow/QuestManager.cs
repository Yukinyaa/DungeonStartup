﻿using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    public IReadOnlyList<Quest> Quests { get => quests; }
    List<Quest> quests = new List<Quest>();
    public Quest ActivatedQuest { get; private set; }

    public void Init()
    {
        ActivatedQuest = null;
        while (quests.Count < 3)
        {
            Quest rndQuest = QuestDB.Quests.RandomItem();
            if (!quests.Exists(q => q == rndQuest))
            {
                quests.Add(rndQuest);
            }
        }
        SelectQuestUI.Instance.UpdateUI();
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
        SelectQuestUI.Instance.UpdateUI();
    }


    public void AcceptQuest(Quest q)
    {
        if (q == null) return;
        ActivatedQuest = q;
        quests.Remove(q);

        InventoryManager.Instance.equippedItems = new List<Item>(q.startingbody);
        InventoryManager.Instance.ui.RefreshUI();

        UISupervisor.Instance.ActivateUI(UISupervisor.UIViews.Assemble);

        if (q.enemies == null)
            InventoryManager.Instance.ui.EnableBtl(false);
        else
            InventoryManager.Instance.ui.EnableBtl(true);


        //activate finish buttons



    }

}

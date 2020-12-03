using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    List<GameObject> monster;
    Vector3[] positions;

    public PlayerController player;

    // 맵 상 몬스터 수
    public int numOfMonster = 5;
    public int nowMonster;

    bool isClear;             // 몬스터를 모두 잡았는지 여부 (성공)
    bool isFail;            // 플레이어가 죽었는지 여부 (실패)
    bool isEvent;           // 이벤트 처리

    bool t = false;

    // Start is called before the first frame update
    void Start()
    {
        positions = new Vector3[numOfMonster];

        isClear = false;
        isFail = false;
        isEvent = true;

        SetSpawnPoint();


    }

    // Update is called once per frame
    void Update()
    {
        monster?.RemoveAll(a => a == null);
        // 모든 몬스터를 다 잡았다면
        if(monster.Count == 0)
        {
            isClear = true;
        }

        if (Input.GetKey(KeyCode.A) && !t)
        {
            t = true;
            RemoveMonster();
            SpawnMonster();
            t = false;
        }

        // 몬스터를 모두 잡았을 때 이벤트 발생
        if (isClear && !isEvent)
        {
            isEvent = true;
            ClearEvent();
        }
        // 플레이어가 죽었을 때 이벤트 발생
        else if (isFail && !isEvent)
        {
            isEvent = true;
            FailEvent();
        }
    }

    // 몬스터 스폰 초기 설정
    public void SpawnMonster()
    {
        nowMonster = numOfMonster;

        for (int i = 0; i < numOfMonster; i++)
        {
            monster.Add(Instantiate(Resources.Load<GameObject>("Enemy/Monster_" + Random.Range(1,4)), positions[i], Quaternion.identity));
        }
    }
    public void StartBattle()
    {
        RemoveMonster();
        if(player != null)
            Destroy(player.gameObject);
        monster = new List<GameObject>();

        //Spawn Monsters
        foreach (EnemyInfo m in QuestManager.Instance.ActivatedQuest.enemies)  //<<spawn these
        {
            for (int i=0; i < m.SpawnCount; i++)
            {
                //todo: spawn properly
                monster.Add(Instantiate(Resources.Load<GameObject>("Enemy/Monster_" + UnityEngine.Random.Range(1, 4)), positions[UnityEngine.Random.Range(0, 4)], Quaternion.identity));
            }
        }


        Stat s = (from Item i in InventoryManager.Instance.EquippedItems select i.stat).Aggregate(new Stat(), (a, b) => a + b);
        
        // Spawn Player and use `playerstat` as stat
        player = Instantiate(Resources.Load<GameObject>("Player/Player"), new Vector3(-4.12f, -4f), Quaternion.identity).GetComponent<PlayerController>();
        player.InitStatus(s.maxhp, (int)s.atk, s.atkspd, s.mvspd, 7.5f, (int)s.def, (int)s.atkrng);

        List<SpriteSkinSwapper> playerSprites = player.GetComponentsInChildren<SpriteSkinSwapper>().ToList();
        //swap sprites in character
        foreach (Item.ItemType itype in new List<Item.ItemType> { Item.ItemType.body, Item.ItemType.head, Item.ItemType.leg, Item.ItemType.shield, Item.ItemType.weapon })
        {
            var itempart = InventoryManager.Instance.EquippedItems.FirstOrDefault(i => i.type == itype);
            var targetParts = playerSprites.Where(a => a.partType == itype);
            foreach (var part in targetParts)
                part.SwapSkin(itempart?.serial);
        }
        isClear = false;
        isFail = false;
        isEvent = false;
    }
    public void CleanupBattle()
    {
        RemoveMonster();
        Destroy(player.gameObject);
    }

    // 몬스터 스폰 좌표 설정
    public void SetSpawnPoint()
    {
        positions[0] = new Vector3(5.6f, -4.9f, -0.1f);
        positions[1] = new Vector3(-6.4f, -4.9f, -0.1f);
        positions[2] = new Vector3(-17.5f, -4.9f, -0.1f);
        positions[3] = new Vector3(20.35f, -4.9f, -0.1f);
        positions[4] = new Vector3(11.35f, -2.51f, -0.1f);
    }

    // 몬스터 제거
    public void RemoveMonster()
    {
        if (monster == null) return;
        for (int i = 0; i < monster.Count; i++)
        {
            Destroy(monster[i]);
        }
    }

    // 몬스터를 모두 잡았을 때 실행할 것
    public void ClearEvent()
    {
        //창 띄워서 가는게 어떨까
        UISupervisor.Instance.ActivateUI(UISupervisor.UIViews.ConfirmDelever);
        CleanupBattle();
        
        Debug.Log("퀘스트 완료");
    }

    // 플레이어가 죽었을 때 실행할 것
    public void FailEvent()
    {
        //창 띄워서 가는게 어떨까
        Debug.Log("퀘스트 실패");
        UISupervisor.Instance.ActivateUI(UISupervisor.UIViews.Assemble);
        CleanupBattle();
        // 플레이어 살려보기 (retry)?

    }

    // 플레이어 죽음 설정
    public void SetPlayerDie()
    {
        isFail = true;
    }

    internal void MobDie(GameObject gameObject)
    {
        monster.Remove(gameObject);
    }
}

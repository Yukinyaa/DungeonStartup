using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject [] monster;
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
        monster = new GameObject[numOfMonster];
        positions = new Vector3[numOfMonster];

        isClear = false;
        isFail = false;
        isEvent = false;

        SetSpawnPoint();
        SpawnMonster();
    }

    // Update is called once per frame
    void Update()
    {
        // 모든 몬스터를 다 잡았다면
        if(nowMonster == 0)
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
            monster[i] = Instantiate(Resources.Load<GameObject>("Enemy/Monster_" + Random.Range(1,4)), positions[i], Quaternion.identity);
        }
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
        for (int i = 0; i < numOfMonster; i++)
        {
            Destroy(monster[i]);
        }
    }

    // 몬스터를 모두 잡았을 때 실행할 것
    public void ClearEvent()
    {
        isClear = false;
        isEvent = false;
        Debug.Log("퀘스트 완료");
    }

    // 플레이어가 죽었을 때 실행할 것
    public void FailEvent()
    {
        isFail = false;
        isEvent = false;
        Debug.Log("퀘스트 실패");

        // 플레이어 살려보기 (retry)?

    }

    // 플레이어 죽음 설정
    public void SetPlayerDie()
    {
        isFail = true;
    }
}

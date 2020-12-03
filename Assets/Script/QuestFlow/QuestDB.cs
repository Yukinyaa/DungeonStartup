using System.Collections.Generic;
using UnityEngine;

public class QuestDB
{
    private static List<Quest> quests;

    public static List<Quest> Quests
    {
        get { if(quests==null) Init(); return quests; }
        set => quests = value;
    }

    
    public static void Init()
    {
        quests = new List<Quest>() {
            new Quest(){
                title = "정기 납품",
                subtitle = "최대대규모모던던전에 납품",
                desc = "최대 대규모 모던 던전에\n아래 조건을 만족하는 캐릭터를 만들어 납품하자.",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("공격력 10 이상", stat => stat.atk >= 10),
                    new QuestStatCond("아름다움 20 이상", stat => stat.beauty >= 20)
                },
                enemies = null,
                rewardMoney = 2500,
                startingbody = new List<Item>
                {
               //none
            },
                thumbnail = Resources.Load<Sprite>("Sprites/QThumbs/I_Scroll")
            },
            new Quest(){
                title = "해골 수확기",
                subtitle = "해골 수확기 검증 및 납품",
                desc = "요즘 마을에 해골 암살자가 자주 등장한다네.\n\n그것들을 물리칠 수 있는 견고하고 빠른 무언가가 필요해.\n해골 병사를 하나 줄테니 개조해서 그것들을 정리할 수 있는걸 만들어 주게나.",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("이동속도 20 이상", stat => stat.mvspd >= 20),
                    new QuestStatCond("방어력 10 이상", stat => stat.def >= 10),
                    new QuestStatCond("공격속도 10 이상", stat => stat.atkspd >= 10),
                    new QuestStatCond("체력 80 이상", stat => stat.maxhp >= 80)
                },
                enemies = new List<EnemyInfo> {
                    new EnemyInfo("해골 방맹이 암살자",
                                                        new List<Item>{
                                                            ItemDB.ItemDic["해골 암살자의 머리" ],
                                                            ItemDB.ItemDic["해골 암살자의 몸"],
                                                            ItemDB.ItemDic["해골 암살자의 다리"],
                                                            ItemDB.ItemDic["방망이"] }
                                            , 3)
                },
                rewardMoney = 1000,
                startingbody = new List<Item>
                {
               ItemDB.ItemDic["해골 암살자의 머리" ],
                    ItemDB.ItemDic["해골 암살자의 몸"],
                    ItemDB.ItemDic["해골 암살자의 다리"],
                    ItemDB.ItemDic["방망이"]
                },
                thumbnail = Resources.Load<Sprite>("Sprites/QThumbs/I_Bone")
            },

            new Quest(){
                title = "이상취향",
                subtitle = "기괴한 의뢰",
                desc = "이상한 취향을 가진 의뢰인이 자신이 사랑하는 하인을 고쳐달라 보내왔다.\n 이런 게 진짜 좋은 걸까?",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("기괴함 50 이상", stat => stat.beauty <= -50),
                    new QuestStatCond("공격력 100 이하", stat => stat.atk <= 100)
                },
                enemies = null,
                rewardMoney = 2000,
                startingbody = new List<Item>
                    {
                  ItemDB.ItemDic["엘프 탐험가의 머리"],
                        ItemDB.ItemDic["오크 전사의 몸"],
                    },
                    thumbnail =  Resources.Load<Sprite>("Sprites/QThumbs/heart")
            },

            new Quest(){
                title = "오크 학살",
                subtitle = "셀라스 오크 척결 연합의 의뢰",
                desc = "하인 원한다. 오크 육억마리 학살. 오크 멍청. 오크 없앤다.\n오크 열마리 죽임. 증명.",
                statConditions = new List<QuestStatCond>
                {
                },
                enemies = new List<EnemyInfo> {
                    new EnemyInfo("오크 전사",
                                                        new List<Item>
                {
                        ItemDB.ItemDic["오크 전사의 머리"],
                        ItemDB.ItemDic["오크 전사의 몸"],
                        ItemDB.ItemDic["오크 전사의 다리"],
                        ItemDB.ItemDic["방망이"]
                }, 10)
                },
                rewardMoney = 5000,
                startingbody = new List<Item>
                {
                        ItemDB.ItemDic["오크 전사의 머리"],
                        ItemDB.ItemDic["오크 전사의 몸"],
                        ItemDB.ItemDic["오크 전사의 다리"],
                        ItemDB.ItemDic["방망이"]
                },
                thumbnail =  Resources.Load<Sprite>("Sprites/QThumbs/I_Torch02")
            },

            new Quest(){
                title = "푸른빌빌라라동동문문지기",
                subtitle = "푸른빌 빌라 라동 동문 문지기 구함",
                desc = "푸른빌 라동에 무서운 문지기가 필요하다.",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("기괴함 60 이상", stat => stat.beauty <= -60),
                    new QuestStatCond("공격력 70 이상", stat => stat.atk >= 70)
                },
                enemies = null,
                rewardMoney = 1000,
                startingbody = new List<Item>
                {
                        ItemDB.ItemDic["오크 전사의 머리"],
                        ItemDB.ItemDic["오크 전사의 몸"],
                        ItemDB.ItemDic["오크 전사의 다리"],
                        ItemDB.ItemDic["방망이"]
                },
                thumbnail =  Resources.Load<Sprite>("Sprites/QThumbs/E_Wood03")
            },

            new Quest(){
                title = "습격",
                subtitle = "셀라스 습격 의뢰",
                desc = "많은 오크, 죽었다. 더 많은 인간 죽는다.",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("기괴함 40 이상", stat => stat.beauty <= -40),
                    new QuestStatCond("공격력 80 이상", stat => stat.atk >= 80)
                },
                enemies= new List<EnemyInfo> {
                    new EnemyInfo("인간 기사", new List<Item>
                {
                    ItemDB.ItemDic["인간 기사의 머리"],
                    ItemDB.ItemDic["인간 기사의 몸"],
                    ItemDB.ItemDic["인간 기사의 다리"],
                    ItemDB.ItemDic["방망이"],
                    ItemDB.ItemDic["강철방패"],
                }, 10)},
                rewardMoney = 8000,
                startingbody = new List<Item>
                {
                        ItemDB.ItemDic["오크 전사의 머리"],
                        ItemDB.ItemDic["오크 전사의 몸"],
                        ItemDB.ItemDic["오크 전사의 다리"],
                        ItemDB.ItemDic["광선검"],
                        ItemDB.ItemDic["강철방패"]
                },
	//// 인간 기사 다수
	//// 최고 난이도 급 퀘스트
                    thumbnail =  Resources.Load<Sprite>("Sprites/Items/OrkHead")
            },

            new Quest(){
                title = "퇴마",
                subtitle = "언데드 기사 처치",
                desc = "무덤에서 사이한 괴물들이 나타났다고 합니다. 사람을 보내 그 악령들을 퇴마해주십시오.",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("아름다움 80 이상", stat => stat.beauty >= 80)
                },
                enemies= new List<EnemyInfo> {
                    new EnemyInfo("언데드 기사",
                                                        new List<Item>
                {
                        ItemDB.ItemDic["인간 기사의 머리"],
                        ItemDB.ItemDic["해골 암살자의 몸"],
                        ItemDB.ItemDic["해골 암살자의 다리"],
                        ItemDB.ItemDic["방망이"]
                }, 10)},
                rewardMoney = 7000,
                startingbody = new List<Item>
                {
                    ItemDB.ItemDic["해골 암살자의 머리"],
                    ItemDB.ItemDic["인간 기사의 몸"],
                    ItemDB.ItemDic["인간 기사의 다리"],
                    ItemDB.ItemDic["식칼"]
                },
	///// 언데드 기사 다수
                    thumbnail =  Resources.Load<Sprite>("Sprites/QThumbs/P_Blue08")
            },

            new Quest(){
                title = "복수",
                subtitle = "피의 복수",
                desc = "내... 연인을 죽인 원수... 자, 내 몸을 가져가서 그 녀석에게 복수할 힘을 줘.",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("공격속도 40 이상", stat => stat.atkspd >= 40)
                },
                enemies =  new List<EnemyInfo> {
                    new EnemyInfo("사린자",
                                                        new List<Item>
                {
                    ItemDB.ItemDic["엘프 탐험가의 머리"],
                    ItemDB.ItemDic["해골 암살자의 몸"],
                    ItemDB.ItemDic["인간 기사의 다리"],
                    ItemDB.ItemDic["거북이"]
                }, 1)
                },
                rewardMoney = 2000,
                startingbody = new List<Item>
                {
                    ItemDB.ItemDic["인간 기사의 머리"],
                    ItemDB.ItemDic["해골 암살자의 몸"],
                    ItemDB.ItemDic["인간 기사의 다리"]
                },
                thumbnail =  Resources.Load<Sprite>("Sprites/QThumbs/S_Sword05")
            },

            new Quest(){
                title = "트레이닝",
                subtitle = "몸짱이 되고싶어",
                desc = "내 허약한 몸을 튼튼하게 만들어줘!",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("체력 70 이상", stat => stat.maxhp >= 70),
                    new QuestStatCond("방어력 50 이상", stat => stat.def >= 50)
                },
                enemies = null,
                rewardMoney = 1500,
                startingbody = new List<Item>
                {
                    //none
                },
                thumbnail =  Resources.Load<Sprite>("Sprites/QThumbs/S_Buff08")
            },

            new Quest(){
                title = "호들갑",
                subtitle = "노예를 아끼는 호들갑쟁이의 의뢰",
                desc = "난 내 노예가 상하는 꼴은 절대 못봐. 전투 노예라도 말이야. 멀리서 때릴 수 있는 녀석으로 내놔봐.",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("사거리 30 이상", stat => stat.atkrng >= 30)
                },
                enemies = null,
                rewardMoney = 3000,
                startingbody = new List<Item>
                    {
                        ItemDB.ItemDic["인간 기사의 머리"],
                        ItemDB.ItemDic["엘프 탐험가의 몸"],
                        ItemDB.ItemDic["해골 암살자의 다리"],
                        ItemDB.ItemDic["연"],
                    },
                    thumbnail =  Resources.Load<Sprite>("Sprites/QThumbs/heart")
            },

            new Quest(){
                title = "버르장머리 고치기",
                subtitle = "불량스러운 견습 기사 혼쭐내기",
                desc = "에잉... 나 때는 말이야? 부모님이 주신 몸에 구멍을 뚫고 그림을 그리는 일은 있을 수가 없었어! 심부름꾼을 시켜서 그 애송이를 혼내주려무나.",
                statConditions = new List<QuestStatCond>
                {
                    new QuestStatCond("방어력 20이상", stat => stat.def >= 20 ),
                },
                enemies = null,
                rewardMoney = 600,
                startingbody = new List<Item>
                    {
                        ItemDB.ItemDic["오크 전사의 머리"],
                        ItemDB.ItemDic["인간 기사의 몸"],
                        ItemDB.ItemDic["엘프 탐험가의 다리"]
                    },
                    thumbnail =  Resources.Load<Sprite>("Sprites/Items/B_Bat")
            }
        };
    }
}

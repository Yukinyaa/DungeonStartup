using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(Button))]
public class QuestListUI : MonoBehaviour
{
    [SerializeField]
    Image thumbnail;
    [SerializeField]
    TextMeshProUGUI title, subtitle;
    
    public Quest quest;
    // Use this for initialization
    public void Init(string title, string subtitle, Sprite sprite)
    {
        this.title.text = title;
        this.subtitle.text = subtitle;
        this.thumbnail.sprite = sprite;

        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(() => SelectQuestUI.Instance.SelectQuest(quest));
    }

}

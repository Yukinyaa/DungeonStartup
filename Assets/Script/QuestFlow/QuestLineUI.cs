using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestLineUI : MonoBehaviour
{
    [SerializeField]
    Image thumbnail;
    [SerializeField]
    TextMeshProUGUI title, subtitle;
    
    public Quest quest;
    // Use this for initialization
    void Init(string title, string subtitle, Sprite sprite)
    {
        this.title.text = title;
        this.subtitle.text = subtitle;
        this.thumbnail.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

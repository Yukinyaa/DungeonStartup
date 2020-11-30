using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoUI : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI nameText, tooltipText, flavorText;

    [SerializeField]
    GameObject flavorObject;

    [SerializeField]
    RectTransform trapTextBox;

    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        flavorTimer += Time.deltaTime;

        var piv = new Vector2(-0.05f, 1.05f);

        this.rectTransform.pivot = piv;
        this.transform.position = Input.mousePosition;

        Vector3[] myCorners = new Vector3[4];
        Vector3[] trapCorners = new Vector3[4];
        rectTransform.GetWorldCorners(myCorners);
        trapTextBox.GetWorldCorners(trapCorners);
        // It starts bottom left and rotates to top left, then top right, and finally bottom right.
        if (myCorners[2].x > trapCorners[2].x)
            piv.x = 1.05f;
        if (myCorners[3].y < trapCorners[3].y)
            piv.y = -0.05f;

        this.rectTransform.pivot = piv;
        this.transform.position = Input.mousePosition;
        flavorObject.SetActive(flavorTimer > 2f);

        return;
    }
    float flavorTimer = 0;
    public void Hide()
    {
        flavorTimer = 0;
        gameObject.SetActive(false);
    }
    public void UpdateText(string name, string toolTip, string flavor)
    {
        nameText.text = name;
        tooltipText.text = toolTip;
        flavorText.text = flavor;
        flavorTimer = 0f;
    }
}

using UnityEngine;
using System.Collections;

public abstract class AbstractCheatCode : MonoBehaviour
{
    protected KeyCode[] cheatCode;
    abstract protected void OnActivateCheat();



    private int index = 0;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(cheatCode[index]))
            {
                Debug.Log(index);
                index++;
            }
            
            else
                index = 0;
        }
        
        if (index == cheatCode.Length)
        {
            index = 0;
            OnActivateCheat();
        }
    }
}

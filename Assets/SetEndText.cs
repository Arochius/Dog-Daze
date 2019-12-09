using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetEndText : MonoBehaviour
{

    public Text endText;
    // Start is called before the first frame update
    void Start()
    {
        if (Score.didWin)
        {
            endText.text = "MISSION SUCCESS";
        }
        else
        {
            endText.text = "MISSION FAILED";
            endText.color = Color.red;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text pissText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool yes = ThirdPersonCharacter.canPiss;
        if (yes)
        {
            pissText.text = "READY TO PISS!";
            pissText.color = Color.green;
        }
        else
        {
            pissText.text = "NOT READY!";
            pissText.color = Color.red;
        }
    }
}

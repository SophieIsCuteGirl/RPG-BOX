using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonHandler : MonoBehaviour
{
    public GameObject GM;
    public void Press(string buttonID)
    {
        if (buttonID == "loadButton")
        {
            print("worked");
            exampleLoadAndSave LaS = GM.GetComponent<exampleLoadAndSave>();
            LaS.loadGame();
        }
    }
}

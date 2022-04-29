using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool checkIfSame(GameObject button1, GameObject button2)
    {
        if (button1.SpriteRenderer = button2.SpriteRenderer)
        {
            return true;
        }
        return false;
    }

    public void ifSame()
    {
        if (checkIfSame(button1,button2))
        {
            score+=1
            button1.setActive = false;
            button2.setActive = false;
        }
    }

    //Keep track of which cards have been clicked on, needs to know card 1 and card 2 clicked
    //Once both are clicked it needs to be able to check if they are the same
    //And if they are cards need to be hidden and points need to increase
    //If not, the two cards need to be reset to how they were at the beginning
}

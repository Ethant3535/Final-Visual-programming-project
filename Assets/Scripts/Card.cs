using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SpriteRenderer seePic(GameObject button)
    {
        return button.SpriteRenderer;
    }
    //What pic it is
    //Needs to know whether it is flipped
}

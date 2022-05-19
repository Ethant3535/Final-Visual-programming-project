using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite DefaultSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite seePic(GameObject button)
    {
        return SpriteRenderer.sprite;
    }

    public bool seeIfFlipped(GameObject button)
    {
        if (SpriteRenderer.sprite == DefaultSprite)
        {
            return false;
        }
        return true;
    }
    //What pic it is
    //Needs to know whether it is flipped
    //Still need to do on click method so we can know what button/s were clicked on and then be able to pass them into different methods 
}

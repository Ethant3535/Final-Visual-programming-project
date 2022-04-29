using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Randomizer : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;
    public List<Sprite> dogList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //create something to keep track of which sprites are in which slots
    // create list of 1-8 sprites
    // goes through cards and picks random sprite from the list
    // if 2 of those sprites exist after, reomove that sprite from the list
    //continue till all slots are filled
    //reset list for next shuffle


    public void randomizeSprite()
    {
        //gonna get help from Jon doing office hrs
        for (int i = 0; i <= dogList.Count; i++)
        {
            // assign 
        }
    }
}
    




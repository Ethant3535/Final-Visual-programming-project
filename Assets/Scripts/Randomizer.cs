using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Randomizer : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    public GameObject Button6;
    public GameObject Button7;
    public GameObject Button8;
    public GameObject Button9;
    public GameObject Button10;
    public GameObject Button11;
    public GameObject Button12;
    public GameObject Button13;
    public GameObject Button14;
    public GameObject Button15;
    public GameObject Button16;
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
    public List<Sprite> dogList = new List<Sprite>(new Sprite[16]);




    public void randomizeSprite()
    {
        for (int i = 0; i <= dogList.Count; i++)
        {
            dogList[i] = Button1.SpriteRenderer;
        }
    }
}
    




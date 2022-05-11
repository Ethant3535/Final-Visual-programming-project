using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public List<Image> ImagesOnButtons;

    private int numberOfCardsClicked = 0;
    private Sprite firstCardSprite;
    private Sprite secondCardSprite;
    private int score = 0;
    public Readouts ReadOuts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCardClicked(int buttonNumber)
    {
        if (numberOfCardsClicked == 0)
        {
            numberOfCardsClicked = 1;
            firstCardSprite = ImagesOnButtons[buttonNumber].sprite;
        }
        else if (numberOfCardsClicked == 1)
        {
            secondCardSprite = ImagesOnButtons[buttonNumber].sprite;

            if (firstCardSprite == secondCardSprite)
            {
                print("match!");
                UpdateMatches(score + 1);
            }
            else
            {
                print("no match!");
            }
            numberOfCardsClicked = 0;
        }
    }

    private void UpdateMatches(int newScore)
    {
        score = newScore;
        ReadOuts.ShowMatches(score);
   
    }


}
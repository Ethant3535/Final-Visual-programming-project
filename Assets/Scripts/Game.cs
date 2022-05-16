using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Game : MonoBehaviour
{
    private List<Card> flippedCards;
    public int matchCounter;
    public bool isOkToFlip;
    public Dealer dealer;


    public void addToFlippedCards(Card card)
    {
        flippedCards.Add(card);
        if (flippedCards.Count == 2)
        {
            isOkToFlip = false;
            bool isMatch = checkForMatch();
            if (isMatch)
            {
                matchCounter += 1;
                flippedCards.Clear();
                isOkToFlip = true;
            }

            else
            {
                StartCoroutine(waitToFlipBack());
            }

        }

    }

    IEnumerator delayedFlip()
    {
        List<Card> allCards = GameObject.FindObjectsOfType<Card>().ToList();
        allCards.Reverse();
        for (int i = 0; i < allCards.Count; i++)
        {
            allCards[i].reveal();
            yield return new WaitForSeconds(.25f);
        }
    }

    IEnumerator delayedHide()
    {
        List<Card> allCards = GameObject.FindObjectsOfType<Card>().ToList();
        allCards.Reverse();
        for (int i = 0; i < allCards.Count; i++)
        {
            allCards[i].hide();
            yield return new WaitForSeconds(.25f);
        }
        isOkToFlip = true;
    }

    public void revealAllCards()
    {
        isOkToFlip = false;
        StartCoroutine(delayedFlip());
    }

    public void hideAllCards()
    {
        isOkToFlip = false;
        StartCoroutine(delayedHide());
    }

    IEnumerator waitToFlipBack()
    {
        yield return new WaitForSeconds(2);
        flippedCards[0].flipToBack();
        flippedCards[1].flipToBack();
        flippedCards.Clear();
        isOkToFlip = true;
    }

    public bool checkForMatch()
    {
        if (flippedCards[0].frontImage == flippedCards[1].frontImage)
        {
            print("Match");
            return true;
        }
        print("No Match");
        return false;
    }

    public void Reset()
    {
        matchCounter = 0;
        isOkToFlip = true;
    }

    public bool hasWon()
    {
        if (matchCounter == 8)
        {
            return true;
        }

        return false;
    }

    public void clicked()
    {
        dealer.deal();
    }

}

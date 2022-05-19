using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Game : MonoBehaviour
{
    public List<Card> flippedCards;
    public int matchCounter;
    public bool isOkToFlip;
    public Dealer dealer;
    public Sounds Sounds;
    public Countdown Countdown;
    public UI UI;
    private bool isWaitingToRestart = false;
    public Readouts readouts;
    public GameObject EffectPrefab;

    public void Update()
    {
        if (Countdown.IsGameOver() && !isWaitingToRestart)
        {
            dealer.reset();
            UI.ShowGameOver();
            isWaitingToRestart = true;
            StartCoroutine(WaitToRestartGame());
        }
    }

    IEnumerator WaitToRestartGame()
    {
        yield return new WaitForSeconds(3);
        Reset();
        isWaitingToRestart = false;
    }

    public void Start()
    {
        flippedCards = new List<Card>();
        Sounds.PlayMusic();
        Reset();
    }


    public void addToFlippedCards(Card card)
    {
        Sounds.PlayWooshSound();
        flippedCards.Add(card);
        if (flippedCards.Count == 2)
        {
            isOkToFlip = false;
            bool isMatch = checkForMatch();
            if (isMatch)
            {
                matchCounter += 1;
                readouts.ShowMatches(matchCounter);
                foreach (Card c in flippedCards)
                {
                    Instantiate(EffectPrefab, c.GetWorldPosition() + new Vector3(0, 0, -100), Quaternion.identity);
                }
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
        yield return new WaitForSeconds(1);
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
            Sounds.PlayMatchSound();
            return true;
        }
        print("No Match");
        return false;
    }

    public void Reset()
    {
        matchCounter = 0;
        isOkToFlip = true;
        flippedCards = new List<Card>();
        Countdown.Reset();
        UI.HideGameOver();
        UI.HideReadouts();
        UI.ShowTitleScreen();
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
        UI.HideTitleScreen();
        UI.ShowReadouts();
    }

}

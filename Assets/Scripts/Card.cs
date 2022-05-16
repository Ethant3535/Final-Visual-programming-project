using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Sprite frontImage;
    public Sprite backImage;
    private bool isFlipped;
    private bool isFlipping;
    private Game game;

    private void Start()
    {
        game = GameObject.FindObjectOfType<Game>();
    }
    public void flipToFront()
    {
        if (isFlipping || isFlipped)
        {
            return;
        }

        game.addToFlippedCards(this);
        reveal();

        //Tell the game to add it to the list of flipped cards
        //Turn it over
    }

    public void flipToBack()
    {
        //Turn card back over
        if (isFlipping || !isFlipped)
        {
            return;
        }

        hide();

    }


    public void reveal()
    {
        //Turn over all cards
        isFlipping = true;
        StartCoroutine(flipToFrontCoroutine());

    }

    public void hide()
    {
        isFlipping = true;
        StartCoroutine(flipToBackCoroutine());

    }

    IEnumerator flipToBackCoroutine()
    {
        while (gameObject.transform.rotation.eulerAngles.y > 90)
        {
            rotateOneClick(-1, 90);
            yield return null;
        }
        showBackSprite();
        while (gameObject.transform.rotation.eulerAngles.y > 0)
        {
            rotateOneClick(-1, 0);
            yield return null;
        }
        isFlipping = false;
        isFlipped = true;
    }

    public void reset()
    {
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        isFlipped = false;
        isFlipping = false;
        showBackSprite();
    }

    IEnumerator flipToFrontCoroutine()
    {
        //Rotate 90 degrees
        //When it is 90 degrees, swap sprite
        //Keep rotating until 180 degrees
        while (gameObject.transform.rotation.eulerAngles.y < 90)
        {
            rotateOneClick(1,90);
            yield return null;
        }
        showFrontSprite();
        while (gameObject.transform.rotation.eulerAngles.y < 180)
        {
            rotateOneClick(1, 180);
            yield return null;
        }
        isFlipping = false;
        isFlipped = true;
    }

    public void rotateOneClick(int direction, float targetAngle)
    {
        float newRotation = gameObject.transform.eulerAngles.y+(1*(float) direction);
        newRotation = keepWithinAngle(targetAngle, newRotation, direction);
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, newRotation, gameObject.transform.eulerAngles.z);
        
    }

    private float keepWithinAngle(float targetAngle, float currentRotation, int direction)
    {
        if (direction == 1)
        {
            if (currentRotation > targetAngle)
            {
                currentRotation = targetAngle;
            }
        }

        else if (direction == -1)
        {
            if (currentRotation < targetAngle)
            {
                currentRotation = targetAngle;
            }
        }
        return currentRotation;
    }

    private void showFrontSprite()
    {
        gameObject.GetComponent<Image>().sprite = frontImage;
        gameObject.GetComponent<Image>().transform.localScale = new Vector3(-1, 1, 1);
    }

    private void showBackSprite()
    {
        gameObject.GetComponent<Image>().sprite = backImage;
        gameObject.GetComponent<Image>().transform.localScale = new Vector3(1, 1, 1);
    }


}

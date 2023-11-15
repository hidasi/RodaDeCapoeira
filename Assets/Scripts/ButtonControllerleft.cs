using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerleft : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public int buttoncode;
    public bool left, right, up, down;
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttoncode == 1)
        {
            if (left)
            {
                theSR.sprite = pressedImage;
            }
            else
            {
                theSR.sprite = defaultImage;
            }
        }

        if (buttoncode == 2)
        {
            if (right)
            {
                theSR.sprite = pressedImage;
            }
            else
            {
                theSR.sprite = defaultImage;
            }
        }

        if (buttoncode == 3)
        {
            if (up)
            {
                theSR.sprite = pressedImage;
            }
            else
            {
                theSR.sprite = defaultImage;
            }
        }

        if (buttoncode == 4)
        {
            if (down)
            {
                theSR.sprite = pressedImage;
            }
            else
            {
                theSR.sprite = defaultImage;
            }
        }


    }
}

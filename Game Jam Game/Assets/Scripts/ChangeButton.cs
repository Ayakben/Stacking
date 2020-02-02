using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButton : MonoBehaviour
{
    //sprites for the buttons
    public Sprite OffSprite;
    public Sprite OnSprite;
    public Button but;
    //change the sprites for the button
    public void ChangeImage()
    {
        if (but.image.sprite == OnSprite)
            but.image.sprite = OffSprite;
        else
        {
            but.image.sprite = OnSprite;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{

    public Toggle toggle;

    public Image toggleBackgroundGraphic;

    public Sprite onBackgroundSprite;
    public Sprite offBackgroundSprite;

    private void Start()
    {
        if (toggle.isOn)
            toggleBackgroundGraphic.sprite = onBackgroundSprite;
        else
            toggleBackgroundGraphic.sprite = offBackgroundSprite;

    }

    public void SetToggleGraphic()
    {
        toggleBackgroundGraphic.sprite = toggle.isOn ? onBackgroundSprite : offBackgroundSprite;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    public GameObject fish;
    public GameObject obj;

    private int settingsWindowState;

    public GameObject playingCanvas;
    public GameObject losingCanvas;
    public GameObject winningCanvas;
    public GameObject settingsCanvas;

    public void Start()
    {
        settingsWindowState = 0;
    }

    public void setSmallFish()
    {
        if (controller.numberOfCoins < controller.priceSmallFishBought) return;
        controller.numberOfCoins -= controller.priceSmallFishBought;
        controller.fishBoughtCode = 1;
        obj = Instantiate(fish);
        obj.tag = "fish";
    }

    public void setBigFish()
    {
        if (controller.numberOfCoins < controller.priceBigFishBought) return;
        controller.numberOfCoins -= controller.priceBigFishBought;
        controller.fishBoughtCode = 2;
        obj = Instantiate(fish);
        obj.tag = "fish";
    }

    public void openSettings()
    {
        if (settingsWindowState == 0)
        {
            Time.timeScale = 0;
            settingsCanvas.SetActive(true);
            settingsWindowState = 1;
        }
        else
        {
            Time.timeScale = 1;
            settingsCanvas.SetActive(false);
            settingsWindowState = 0;
        }
    }
}

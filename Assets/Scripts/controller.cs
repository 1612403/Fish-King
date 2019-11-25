using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public static int numberOfFish, targetCoins, numberOfCoins;
    public static int priceSmallFishBought, priceBigFishBought;
    public static int priceSmallFishSold, priceBigFishSold, priceOldFishSold;
    public static int level;
    public static float timer;
    public static int fishBoughtCode;
    //public static int gameState; // 1 - is being played, 2 - has been finished, 0 - haven't started

    public GameObject playingCanvas;
    public GameObject losingCanvas;
    public GameObject winningCanvas;
    public GameObject settingsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        numberOfFish = 3;

        fishBoughtCode = -1;
    }

    // Update is called once per frame
    void Update()
    {
        init();
        if (manager.interactState != 3)
            startGame();
    }

    private void init()
    {
        if (manager.interactState == 2 || manager.interactState == 3) return;
        playingCanvas.SetActive(false);
        losingCanvas.SetActive(false);
        winningCanvas.SetActive(false);
        settingsCanvas.SetActive(false);

        if (manager.interactState == 0)
        {
            killAllFishes();
            numberOfCoins = 0;
            targetCoins = 500;

            priceSmallFishBought = 200;
            priceBigFishBought = 500;
            priceSmallFishSold = 100;
            priceBigFishSold = 300;
            priceOldFishSold = 200;

            level = 1;

            manager.interactState = 2;
            test.generateStatus = 1;
        }
        else if (manager.interactState == 1)
        {
            killAllFishes();
            targetCoins = (int)(numberOfCoins * 1.3744);
            priceSmallFishBought = (int)(priceSmallFishBought * 1.1);
            priceBigFishBought = (int)(priceBigFishBought * 1.1);
            priceSmallFishSold = (int)(priceSmallFishSold * 1.1);
            priceBigFishSold = (int)(priceBigFishSold * 1.1);
            priceOldFishSold = (int)(priceOldFishSold * 1.1);

            level++;

            manager.interactState = 2;
            test.generateStatus = 1;
        }
        
        timer = 60f;
    }
    
    private void startGame()
    {
        playingCanvas.SetActive(true);
        countdown();
    }

    private void countdown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            playingCanvas.SetActive(false);
            if (numberOfCoins < targetCoins)
                losingCanvas.SetActive(true);
            else
                winningCanvas.SetActive(true);
            killAllFishes();
        }
    }
    private void killAllFishes()
    {
        GameObject[] fishList = GameObject.FindGameObjectsWithTag("fish");
        foreach(GameObject fish in fishList)
        {
            Destroy(fish);
        }
    }
}

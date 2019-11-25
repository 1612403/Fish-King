using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishMovement : MonoBehaviour
{
    Vector3 position, currentPosition;
    public GameObject addedFish;
    public float speed = 0.001f;
    private Vector2 screenSize;
    private float livingTime;
    private Vector2 child = new Vector2(1f, 1f);
    private Vector2 mature = new Vector2(2f, 2f);
    private bool checkM = false, checkO = false, gaveBirth_1 = false;
    private Color oldFish = new Color(0, 255, 15), fishColor;


    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag != "MainFish")
            init();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "MainFish")
        {
            swim(0);
            countDown();
        }
    }

    private void countDown()
    {
        livingTime -= Time.deltaTime;
        if (livingTime <= 30 && !checkM)
        {
            GetComponent<Transform>().localScale = mature;
            checkM = true;
        }

        if (livingTime <= 20 && gaveBirth_1 == false)
        {
            Instantiate(addedFish);
            gaveBirth_1 = true;
        }

        if (livingTime <= 10)
        {
            if ((int)livingTime % 2 == 0 && !checkO)
            {
                GetComponent<SpriteRenderer>().color = oldFish;
                checkO = true;
            }
            else
                if ((int)livingTime % 2 == 0)
            {
                GetComponent<SpriteRenderer>().color = fishColor;
                checkO = false;
            }
        }

        if (livingTime <= 0) Destroy(gameObject);
    }

    private void init()
    {
        if (controller.fishBoughtCode == 2)
        {
            livingTime = 30f;
            GetComponent<Transform>().localScale = mature;
            controller.fishBoughtCode = -1;
        }
        else
        {
            livingTime = 40f;
            GetComponent<Transform>().localScale = child;
            controller.fishBoughtCode = -1;
        }
        fishColor = GetComponent<SpriteRenderer>().color;
        position = currentPosition = GetComponent<Transform>().position;
        screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    private void swim(int code)
    {
        if (GetComponent<Transform>().position == position || code == 1)
            position = new Vector3(Random.Range(-screenSize.x, screenSize.x), Random.Range(-screenSize.y, screenSize.y - 2f), -1f);

        if (GetComponent<Transform>().position.x <= position.x)
            GetComponent<SpriteRenderer>().flipX = false;
        else
            GetComponent<SpriteRenderer>().flipX = true;
        currentPosition = Vector3.MoveTowards(currentPosition, position, speed * Time.deltaTime);
        GetComponent<Transform>().position = currentPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        swim(1);
    }

    private void OnMouseDown()
    {
        if (livingTime < 10)
            controller.numberOfCoins += controller.priceOldFishSold;
        else if (livingTime < 30)
            controller.numberOfCoins += controller.priceBigFishSold;
        else
            controller.numberOfCoins += controller.priceSmallFishSold;
        Debug.Log("Destroy");
        Destroy(gameObject);
    }
}

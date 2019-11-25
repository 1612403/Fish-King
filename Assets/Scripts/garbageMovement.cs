using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageMovement : MonoBehaviour
{
    private Vector3 position, currentPosition;
    private Vector2 screenSize;
    public float speed = 0.5f;

    public float timer = 12f;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "garbage")
            GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f);
        position = currentPosition = GetComponent<Transform>().position;
        screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Monster") countdown();
        swim();
    }

    private void countdown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 12f;
            if (manager.interactState == 2)
            {
                GameObject obj = Instantiate(gameObject);
                obj.tag = "garbage";
            }
        }
    }

    private void swim()
    {
        if (GetComponent<Transform>().position == position)
            position = new Vector3(Random.Range(-screenSize.x, screenSize.x), Random.Range(-screenSize.y, screenSize.y - 2f), -1f);

        if (GetComponent<Transform>().position.x <= position.x)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;
        currentPosition = Vector3.MoveTowards(currentPosition, position, speed * Time.deltaTime);
        GetComponent<Transform>().position = currentPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        controller.numberOfCoins += 50;
    }
}

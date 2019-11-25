using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisherman : MonoBehaviour
{
    private Vector3 initialPosition, currentPosition;
    public float maxUpDown = 1f;
    public float level = 0.02f;
    private int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = currentPosition = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            if (currentPosition.y < initialPosition.y + maxUpDown)
            {
                currentPosition.y += level;
                GetComponent<Transform>().position = currentPosition;
            }
            else state = 1;
        }
        else if (state == 1)
        {
            if (currentPosition.y > initialPosition.y - maxUpDown)
            {
                currentPosition.y -= level;
                GetComponent<Transform>().position = currentPosition;
            }
            else state = 0;
        }
    }
}

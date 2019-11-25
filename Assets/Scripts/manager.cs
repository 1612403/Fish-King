using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    // 0 - New Game, 1 - Next Level, 2 - Play Game, 3 - Don't need to change
    public static int interactState;

    // Start is called before the first frame update
    void Start()
    {
        interactState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

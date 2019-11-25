using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject fish;
    private GameObject obj;
    public int numberOfFish;
    public static int generateStatus; // 1 - generate, 0 - no generate
    // Start is called before the first frame update
    void Start()
    {
        generateStatus = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (generateStatus == 1)
        {
            numberOfFish = controller.numberOfFish;
            fish.SetActive(true);
            for (int i = 0; i < numberOfFish; i++)
            {
                obj = Instantiate(fish);
                obj.tag = "fish";
            }
            generateStatus = 0;
        }
    }
}

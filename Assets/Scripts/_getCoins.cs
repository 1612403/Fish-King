using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _getCoins : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = controller.numberOfCoins.ToString();
        if (controller.numberOfCoins > PlayerPrefs.GetInt("HIGHSCORE"))
            PlayerPrefs.SetInt("HIGHSCORE", controller.numberOfCoins);
    }
}

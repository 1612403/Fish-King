using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public void toMainScr()
    {
        SceneManager.LoadScene(0);
    }

    public void playAgain()
    {
        manager.interactState = 0;
    }

    public void playNextLevel()
    {
        manager.interactState = 1;
    }


}

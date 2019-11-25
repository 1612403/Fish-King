using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickToDestroy : MonoBehaviour
{
    private void OnMouseDown()
    {
        //fishMovement.sell();
        Destroy(gameObject);
    }
    /*private void OnMouseUp()
    {
        Destroy(gameObject);
    }*/
}

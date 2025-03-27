using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public bool isTouch = false;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Plate"))
        {
            isTouch = true;
        }
        else
        {
            isTouch = false;
        }
    }
}

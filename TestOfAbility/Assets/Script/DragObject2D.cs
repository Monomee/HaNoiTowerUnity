using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject2D : MonoBehaviour
{
    //public static DragObject2D Instance; 
    //private void OnEnable()
    //{
    //    Instance = this;
    //}
    //private void OnDisable()
    //{
    //    Instance = null;
    //}

    private bool dragging = false;
    private Vector3 offset;

    
    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            //Nove object, taking into account original offset.
            this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }

    }
    private void OnMouseDown()
    {
        // Record the difference between the objects centre, and the clicked point on the camera plane. offset transform.position Canera.main. ScreenToWorldPoint(Input.mousePosition);
        offset = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(!this.gameObject.GetComponent<Plate>().isTouch) dragging = true;
    }

    private void OnMouseUp()
    {
        //Stop dragging
        dragging = false;
    }

   
}

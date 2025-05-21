using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;
using System.Linq;
public class PlateManager : MonoBehaviour
{
  
    public Stack<GameObject> stack = new Stack<GameObject>();

    bool isDrop = false;
    bool isPick = false;

    public GameObject pickObj;
    public GameObject dropObj;

    public void checkStack()
    {
        Debug.Log("Stack: " +  stack.Count);
    }

    GameObject plate;
    public void pick()
    {
        if (GameManager2.Instance.movePlate.Count == 1) isPick = false;
        else if (stack.Count != 0)
        {
            isPick = true;
        }
        if (isPick)
        {
            //Debug.Log("Pick");
            //Debug.Log("Before: " + GameManager.Instance.movePlate.Count);
            plate = stack.Pop();
            GameManager2.Instance.movePlate.Push(plate);
            plate.GetComponent<Rigidbody2D>().gravityScale = 0;
            plate.GetComponent<BoxCollider2D>().enabled = false;
            plate.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 4, this.transform.position.z);
            //Debug.Log("After: " + GameManager.Instance.movePlate.Count);
        }
    }
    public void drop()
    {
         if (stack.Count == 0) isDrop = true; 
        else if (GameManager2.Instance.movePlate.Count != 0 && GameManager2.Instance.movePlate.Peek().transform.localScale.x < stack.Peek().transform.localScale.x)
        {
            isDrop = true;
        }else 
        { 
            isDrop=false;
        }
        if (isDrop)
        {
            //Debug.Log("Drop");
            plate = GameManager2.Instance.movePlate.Pop();
            stack.Push(plate);
            plate.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 4, this.transform.position.z);
            plate.GetComponent<Rigidbody2D>().gravityScale = 1;
            plate.GetComponent<BoxCollider2D>().enabled = true;
            GameManager2.Instance.count++;
            GameManager2.Instance.updateCount();
        }
        if (this.tag.CompareTo("C3") == 0)
        {
            if (stack.SequenceEqual(GameManager2.Instance.firstOne))
            {
                GameManager2.Instance.win.SetActive(true);
            }
        }
    }
}

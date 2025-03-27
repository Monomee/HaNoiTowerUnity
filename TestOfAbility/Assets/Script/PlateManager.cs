using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlateManager : MonoBehaviour
{
  
    public Stack<GameObject> stack = new Stack<GameObject>();
    public HashSet<GameObject> set = new HashSet<GameObject>();

    bool isAdd;
    bool isRemove;

    public Transform curTransform;

    // Start is called before the first frame update
    void Awake()
    {
        isAdd = true;
        isRemove = true;
    }
 
    public Transform getCurTrans()
    {
        curTransform = stack.Peek().transform;
        return curTransform;
    }

    public void checkStackAndSet()
    {
        Debug.Log("Stack: " +  stack.Count);
        Debug.Log("Set: " +  set.Count);
    }

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (PlateManager.instance.stack.Count == 0)
    //    {
    //        if (other.CompareTag("Plate")) PlateManager.instance.isAdd = true;
    //    }
    //    else
    //    {
    //        if(other.gameObject.transform.localScale.x > PlateManager.instance.stack.Peek().transform.localScale.x)
    //        {
    //            PlateManager.instance.isAdd = false;
    //        }
    //        else
    //        {
    //            if (other.CompareTag("Plate")) PlateManager.instance.isAdd = true;
    //        }
    //    }
    //    if (PlateManager.instance.isAdd)
    //    {
    //        if (!PlateManager.instance.set.Contains(other.gameObject)) // Kiểm tra nếu object chưa có trong stack
    //        {
    //            other.transform.position = new Vector3(this.transform.position.x, other.transform.position.y, other.transform.position.z);
    //            PlateManager.instance.stack.Push(other.gameObject);
    //            PlateManager.instance.set.Add(other.gameObject);
    //        }
    //    }
    //    else
    //    {
    //        //other.transform.position = PlateManager.instance.getCurTrans().position;
    //    }
    //}
    GameObject plate;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Enter");
            if (this.gameObject.GetComponent<PlateManager>().stack.Count != 0)
            {
                Debug.Log("Pick");
                plate = this.gameObject.GetComponent<PlateManager>().stack.Pop();
                this.gameObject.GetComponent<PlateManager>().set.Remove(plate);
                plate.GetComponent<Rigidbody2D>().gravityScale = 0;
                plate.GetComponent<BoxCollider2D>().enabled = false;
                plate.transform.SetParent(other.transform);
                plate.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 1, other.transform.position.z);
            }
        }
    }
}

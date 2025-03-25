using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlateManager : MonoBehaviour
{
    public List<GameObject> plateList;
    public Stack<GameObject> plateStack = new Stack<GameObject>();
    int numberOfPlate = 3;

    public TextMeshProUGUI textNum;
    public TextMeshProUGUI textCount;

    public GameObject platePrefab;
    GameObject newPlate;
    Transform newPos;
    float scaleX;

    bool isAdd;
    bool isRemove;

    // Start is called before the first frame update
    void Awake()
    {
        isAdd = true;
        isRemove = true;
        textNum.text = ("Number of Plate: "+ numberOfPlate.ToString());
        scaleX = platePrefab.transform.localScale.x;       
        for (int i = 0; i < numberOfPlate; i++)
        {
            plateStack.Push(plateList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPlate()
    {
        numberOfPlate++;
        if (numberOfPlate > 8)
        {
            numberOfPlate = 8;
            isAdd = false;
        }
        else
        {
            isAdd = true;
        }
        textNum.text = ("Number of Plate: " + numberOfPlate.ToString());
        if (isAdd)
        {
            newPlate = Instantiate(platePrefab, this.transform);
            newPlate.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 3, this.transform.position.z);
            newPlate.transform.localScale = new Vector3(scaleX - 2 * (numberOfPlate - 4), newPlate.transform.localScale.y, newPlate.transform.localScale.z);
            plateStack.Push(newPlate);
            Debug.Log(plateStack.Count);
        }
        
    }

    public void removePlate()
    {
        numberOfPlate--;
        if (numberOfPlate < 3)
        {
            numberOfPlate = 3;
            isRemove = false;
        }
        else
        {
            isRemove = true;
        }
        textNum.text = ("Number of Plate: " + numberOfPlate.ToString());
        if (isRemove)
        {
            newPlate = plateStack.Pop();
            Destroy(newPlate);
            Debug.Log(plateStack.Count);
        }
    }
}

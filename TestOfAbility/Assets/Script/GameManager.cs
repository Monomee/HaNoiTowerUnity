using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void OnEnable()
    {
        Instance = this;
    }
    private void OnDisable()
    {
        Instance = null;
    }

    public TextMeshProUGUI textNum;
    public TextMeshProUGUI textCount;
    public int count=0;
    
    int numberOfPlate = 0;
    public GameObject platePrefab;
    GameObject newPlate;
    Transform newPos;
    float scaleX;
    bool isAdd;
    bool isRemove;

    public GameObject column1;
    public GameObject column2;
    public GameObject column3;

    public Stack<GameObject> firstOne = new Stack<GameObject>();
    public Stack<GameObject> movePlate = new Stack<GameObject>();

    public GameObject win;
    // Start is called before the first frame update
    void Start()
    {
        isAdd = true;
        isRemove = true;
        scaleX = platePrefab.transform.localScale.x;
        add(column1);
        add(column1);
        add(column1);
        updatePlateCount();
        updateCount();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void addPlateButton()
    {
        if (numberOfPlate >= 8)
        {
            numberOfPlate = 8;
            isAdd = false;
        }
        else
        {
            isAdd = true;
        }

        if (isAdd)
        {
            add(column1);
        }
        updatePlateCount();
    }

    public void removePlateButton()
    {
        if (numberOfPlate <= 3)
        {
            numberOfPlate = 3;
            isRemove = false;
        }
        else
        {
            isRemove = true;
        }
        
        if (isRemove)
        {
            remove(column1);
        }
        updatePlateCount();
    }

    public void add(GameObject column)
    {
        newPlate = Instantiate(platePrefab, column.transform);
        column.GetComponent<PlateManager>().stack.Push(newPlate);
        newPlate.transform.position = new Vector3(column.transform.position.x, column.transform.position.y + numberOfPlate - 2, column.transform.position.z);
        newPlate.transform.localScale = new Vector3(scaleX - 2 * numberOfPlate, newPlate.transform.localScale.y, newPlate.transform.localScale.z);
        numberOfPlate++;
        firstOne.Push(newPlate);
        Debug.Log("Ban đầu: "+firstOne.Count);
    }

    public void remove(GameObject column)
    {
        newPlate = column.GetComponent<PlateManager>().stack.Pop();
        Destroy(newPlate);
        numberOfPlate--;
        firstOne.Pop();
        Debug.Log("Ban đầu: " + firstOne.Count);
    }
    public void updateCount()
    {
        textCount.text = ("Count: " + count.ToString());
    }
    public void updatePlateCount()
    {
        textNum.text = ("Number of Plate: " + numberOfPlate.ToString());
    }
}

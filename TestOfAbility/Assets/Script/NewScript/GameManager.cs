using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

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

    //Plate
    int numberOfPlate = 3;
    GameObject plate;
    float timer;
    const float TIMEBETWEENPRESS = 0.8f;
    bool canPress = true;
    bool isAdd = true;

    //Rod
    public GameObject rod1;
    public List<GameObject> temp = new List<GameObject>();

    //Player
    public Transform player;
    public Animator _animatorController;
    public const string WALK = "isWalking";
    const string HASPLATE = "hasPlate";
    public bool isWalking = false;
    public Vector3 target;
    public float speed;
    bool isRotate = false;

    // Start is called before the first frame update
    void Start()
    {
        ObjectPooling.Instance.Init();
        SpawnPlate(numberOfPlate);      
    }

    // Update is called once per frame
    void Update()
    {
        if (!canPress)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                canPress = true;
            }
        }
        if (isWalking)
        {
            ChangePlayerPosition();
            RotatePlayer(Vector3.Dot((isRotate ? Vector3.left : Vector3.right), (target - player.position)));
        }
    }

    //Plate
    void SpawnPlate(int numOfPlateSpawn)
    {
        for (int i = 0; i < numOfPlateSpawn; i++)
        {
            plate = ObjectPooling.Instance.GetPooledObject(numOfPlateSpawn);
            if (plate != null)
            {
                plate.SetActive(true);
                rod1.GetComponent<Rod>().stackOfPlate.Push(plate);
                if (isAdd) 
                {
                    temp.Add(plate);
                }
                else
                {
                    temp.Insert(0, plate);
                }
                plate = null;
            }           
        }
    }
    public void AddPlate()
    {
        if (canPress)
        {
            numberOfPlate++;
            if (numberOfPlate > 8)
            {
                numberOfPlate = 8;
                return;
            }
            rod1.GetComponent<Rod>().stackOfPlate.Clear();
            isAdd = false;
            SpawnPlate(numberOfPlate);
            for (int i = 1; i < temp.Count; i++)
            {
                rod1.GetComponent<Rod>().stackOfPlate.Push(temp[i]);
            }
            canPress = false;
            timer = TIMEBETWEENPRESS;
        }
    }
    public void RemovePlate()
    {
        if (canPress)
        {
            numberOfPlate--;
            if (numberOfPlate < 3)
            {
                numberOfPlate = 3;
                return;
            }
            rod1.GetComponent<Rod>().stackOfPlate.Clear();

            plate = ObjectPooling.Instance.GetLastPooledObjectThatActive();
            if (plate != null)
            {
                plate.SetActive(false);
                plate = null;
            }

            for (int i = 1; i < temp.Count; i++)
            {
                rod1.GetComponent<Rod>().stackOfPlate.Push(temp[i]);
            }
            temp.RemoveAt(0);
            canPress = false;
            timer = TIMEBETWEENPRESS;
        }
    }
    public void ResetPlate()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Player
    void ChangePlayerPosition()
    {
        if (Mathf.Abs(player.position.x - target.x) < 0.01f)
        {
            isWalking = false;
            _animatorController.SetBool(WALK, isWalking);
        }
        else
        {
            player.position = Vector3.MoveTowards(player.position, new Vector3(target.x, player.position.y, player.position.z), speed * Time.deltaTime);
        }
    }
    void RotatePlayer(float dot)
    {
        if (dot < 0)
        {
            isRotate = !isRotate;
            player.Rotate(Vector3.up, 180);
        }
    }
}

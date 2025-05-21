using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Test : MonoBehaviour
{
    public static Test Instance;
    private void OnEnable()
    {
        Instance = this;
    }
    private void OnDisable()
    {
        Instance = null;
    }

    public Animator _animatorController;
    public const string WALK = "isWalking";
    const string HASPLATE = "hasPlate";
    public bool isWalking = false;
    public Vector3 target;
    public float speed;
    bool isRotate = false;
    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            ChangePlayerPosition();
            RotatePlayer(Vector3.Dot((isRotate?Vector3.left:Vector3.right), (target - this.transform.position)));
        }
    }

    void ChangePlayerPosition()
    {
        if (Mathf.Abs(this.transform.position.x - target.x) < 0.01f)
        {
            isWalking = false;
            _animatorController.SetBool(WALK, isWalking);
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(target.x, this.transform.position.y, this.transform.position.z), speed*Time.deltaTime);
        }
    }
    void RotatePlayer(float dot)
    {
        if (dot < 0)
        {
            isRotate = !isRotate;
            this.transform.Rotate(Vector3.up, 180);
        }
    }
}

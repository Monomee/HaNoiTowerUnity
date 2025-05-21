using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    float dirX;
    [SerializeField]float speed;

    [SerializeField] GameObject animObj;
    const string STR_IS_WALK = "isWalking";
    const string STR_IS_HOLD = "isHolding";
    public Animator animatorController;
    int y;

    Button pick;
    Button drop;

    public Button pickC1;
    public Button dropC1;
    public Button pickC2;
    public Button dropC2;
    public Button pickC3;
    public Button dropC3;
    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        MoveAnimationActive();
        HoldAnimationActive();
        pickPlate();
        dropPlate();
        if(GameManager2.Instance.movePlate.Count != 0) GameManager2.Instance.movePlate.Peek().transform.position = new Vector3(this.transform.position.x, this.transform.position.y+1);
    }
    void MoveAnimationActive()
    {
        //animation
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("Walk");
            animatorController.SetBool(STR_IS_WALK, true);
        }
        else
        {
            animatorController.SetBool(STR_IS_WALK, false);
        }
        //direction

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            y = 0;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            y = 180;
        }
        animObj.transform.rotation = new Quaternion(0, y, 0, 0);
    }
    public void HoldAnimationActive()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log("Walk");
            animatorController.SetBool(STR_IS_HOLD, true);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animatorController.SetBool(STR_IS_HOLD, false);
        }
    }
    void pickPlate()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            pick.onClick.Invoke();
        }
    }
    void dropPlate()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            drop.onClick.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("C1"))
        {
            pick = pickC1;
            drop = dropC1;
        }else if (other.CompareTag("C2"))
        {
            pick = pickC2;
            drop = dropC2;
        }
        else if(other.CompareTag("C3"))
        {
            pick = pickC3;
            drop = dropC3;
        }
    }
}


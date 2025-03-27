using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    float dirX;
    [SerializeField]float speed;

    [SerializeField] GameObject animObj;
    const string STR_IS_WALK = "isWalking";
    const string STR_IS_HOLD = "isHolding";
    public Animator animatorController;
    int y;
    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        MoveAnimationActive();
        HoldAnimationActive();
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
            //this.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            y = 180;
            //this.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        animObj.transform.rotation = new Quaternion(0, y, 0, 0);
    }
    public void HoldAnimationActive()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animatorController.SetTrigger(STR_IS_HOLD);
        }
    }

}


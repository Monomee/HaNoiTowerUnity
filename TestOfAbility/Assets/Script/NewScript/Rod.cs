using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Rod : MonoBehaviour
{
    public Stack<GameObject> stackOfPlate = new Stack<GameObject>();
    public LayerMask layerMask;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, 100f, layerMask);

            if (hit.collider != null)
            {
                GameManager.Instance.target = hit.transform.position;
                Debug.Log(hit.collider.gameObject.name + " and " + GameManager.Instance.target);
                GameManager.Instance.isWalking = true;
                GameManager.Instance._animatorController.SetBool(GameManager.WALK, GameManager.Instance.isWalking);
                Debug.Log(GameManager.Instance.isWalking);
            }
        }
    }

    public void CheckDebug()
    {
        Debug.Log("Numbers: " + stackOfPlate.Count);
        Debug.Log("Top: " + stackOfPlate.Peek().gameObject.transform.localScale);
    }
}

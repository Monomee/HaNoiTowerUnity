using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private StateMachine currentState;

    public GameObject player;
    public Transform plate;
    public Transform rod;

    public Animator _animatorController;
    public const string WALK = "isWalking";
    const string HASPLATE = "hasPlate";

    // Start is called before the first frame update
    void Start()
    {
        currentState = new HasNoPlate(player, plate, rod);
        currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }
    public void ChangeState(StateMachine newState)
    {
        currentState.ExitState();

        currentState = newState;
        currentState.EnterState();
    }

}

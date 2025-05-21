using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private GameObject player;
    private Transform? plate;
    private Transform rod;

    public StateMachine(GameObject player, Transform plate, Transform rod)
    {
        this.player = player;
        this.plate = plate;
        this.rod = rod;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();

}

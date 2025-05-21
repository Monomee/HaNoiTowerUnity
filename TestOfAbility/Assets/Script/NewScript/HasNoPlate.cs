using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasNoPlate : StateMachine
{
    public HasNoPlate(GameObject player, Transform plate, Transform rod) : base(player, plate, rod) { }

    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}

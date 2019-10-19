using AI;
using UnityEngine;

public class FleeFromTaggedActor : Node
{
    public override void Execute()
    {
        transform.LookAt(GetComponent<AIController>().Target.transform.position);
        GetComponent<AIController>().GoToLocation(-transform.forward * 10);
        Debug.DrawLine(transform.position, -transform.forward * 10);
    }
}
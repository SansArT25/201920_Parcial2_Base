using AI;
using UnityEngine;

[RequireComponent(typeof(BehaviourRunner))]
public class AIController : PlayerController
{
    private GameObject target;

    public GameObject Target { get => target; set => target = value; }

    protected override Vector3 GetLocation()
    {
        throw new System.NotImplementedException();
    }
}
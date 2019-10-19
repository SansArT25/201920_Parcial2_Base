using AI;
using UnityEngine;

public class IsTaggedActorNear : SelectWithOption
{
    private bool near = false;

    public override bool Check()
    {
        GetComponent<SphereCollider>().enabled = true;
        return near;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameController.Instance.TaggedPlayer)
        {
            near = true;
            GetComponent<AIController>().Target = other.gameObject;
            GetComponent<SphereCollider>().enabled = false;
        }
    }
}
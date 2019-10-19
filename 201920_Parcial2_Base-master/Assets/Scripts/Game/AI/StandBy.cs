using AI;
using UnityEngine;

public class StandBy : Node
{
    public override void Execute()
    {
        GetComponent<SphereCollider>().enabled = true;

        for (int i = 1; i < 51; i++)
        {
            GetComponent<SphereCollider>().radius = (float)i;
        }

        GetComponent<SphereCollider>().radius = 25;

        GetComponent<AIController>().GoToLocation(GetComponent<AIController>().Target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {  
        if (other.tag == "PowInv")
        {
            GetComponent<AIController>().Target = other.gameObject;
            GetComponent<SphereCollider>().enabled = false;
        }
    }
}
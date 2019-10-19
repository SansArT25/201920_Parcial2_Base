using AI;
using UnityEngine;

public class GetNearestTarget : Node
{
    public override void Execute()
    {
        GetComponent<SphereCollider>().enabled = true;

        for (int i = 1; i < 51; i++)
        {
            GetComponent<SphereCollider>().radius = (float)i;
        }

        GetComponent<SphereCollider>().radius = 25;

        Debug.Log("GetNearestTarget");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.gameObject.GetComponent<PlayerController>().Visible)
        {
            GetComponent<AIController>().Target = other.gameObject;
            GetComponent<SphereCollider>().enabled = false;
            Debug.Log("GotNearestTarget");
        } 
        else if (other.tag == "Player" && !other.gameObject.GetComponent<PlayerController>().Visible)
        {
            GetComponent<SphereCollider>().enabled = true;

            for (int i = 1; i < 51; i++)
            {
                GetComponent<SphereCollider>().radius = (float)i;
            }

            GetComponent<SphereCollider>().radius = 25;

            Debug.Log("GetNearestTarget");
        }
    }
}
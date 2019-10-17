using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public abstract class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float stopTime = 3F;

    protected NavMeshAgent agent { get; set; }

    public bool IsTagged { get; protected set; }

    public void SwitchRoles()
    {
        IsTagged = !IsTagged;

        // Pause all logic and restart after
    }

    public void GoToLocation(Vector3 location)
    {
        agent.SetDestination(location);
    }

    public virtual IEnumerator StopLogic()
    {
        // Stop BT runner if AI player, else stop movement.

        yield return new WaitForSeconds(stopTime);
        
        // Restart stuff.
    }

    protected abstract Vector3 GetLocation();

    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        SwitchRoles();

        if (IsTagged)
        {
            StopLogic(); 
        }
    }
}
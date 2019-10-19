using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public abstract class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float stopTime = 3F;

    private bool active = true;

    protected NavMeshAgent agent { get; set; }

    private bool isTagged = false;
    private bool visible = true;

    public bool IsTagged { get => isTagged; set => isTagged = value; }
    public bool Visible { get => visible; set => visible = value; }

    public void SwitchRoles()
    {
        IsTagged = !IsTagged;

        if(IsTagged)
        {
            visible = true;
            StartCoroutine("StopLogic");
        }
    }

    public void GoToLocation(Vector3 location)
    {
        if(active)
        {
            agent.SetDestination(location);
        }
    }

    public virtual IEnumerator StopLogic()
    {
        // Stop BT runner if AI player, else stop movement.
        active = false;

        yield return new WaitForSeconds(stopTime);

        active = true;
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
        if(collision.gameObject.tag == "Player" && !IsTagged && active && collision.gameObject == GameController.Instance.TaggedPlayer)
        {
            SwitchRoles();

            GameController.Instance.Tag(gameObject);
        }
        else if(collision.gameObject.tag == "Player" && IsTagged)
        {
            SwitchRoles();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PowRush : MonoBehaviour
{
    private GameObject affectedPlayer;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerController>().IsTagged)
        {
            affectedPlayer = other.gameObject;
            affectedPlayer.GetComponent<NavMeshAgent>().speed = 10;
            transform.position = new Vector3(transform.position.x, transform.position.y, 15);
            StartCoroutine("ReturnState");
        }
    }

    IEnumerator ReturnState()
    {
        yield return new WaitForSecondsRealtime(5);

        affectedPlayer.GetComponent<NavMeshAgent>().speed = 5;

        yield return new WaitForSecondsRealtime(5);

        transform.position = new Vector3(Random.Range(-16, 16), 0.371875f, Random.Range(-8, 8));

        StopCoroutine("ReturnState");
    }
}

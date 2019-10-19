using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowInv : MonoBehaviour
{
    private GameObject affectedPlayer;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" && other.gameObject != GameController.Instance.TaggedPlayer)
        {
            affectedPlayer = other.gameObject;
            other.gameObject.GetComponent<Renderer>().material = GameController.Instance.Invisible;
            affectedPlayer.GetComponent<PlayerController>().Visible = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, 15);
            StartCoroutine("ReturnState");
        }
    }

    IEnumerator ReturnState()
    {
        yield return new WaitForSecondsRealtime(5);

        if(affectedPlayer != GameController.Instance.TaggedPlayer)
        {
            affectedPlayer.GetComponent<Renderer>().material = GameController.Instance.Untagged;
            affectedPlayer.GetComponent<PlayerController>().Visible = true;
        }
        
        yield return new WaitForSecondsRealtime(5);

        transform.position = new Vector3(Random.Range(-16, 16), 0.371875f, Random.Range(-8, 8));

        StopCoroutine("ReturnState");
    }
}

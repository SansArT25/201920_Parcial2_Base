using UnityEngine;

public class HumanController : PlayerController
{
    [SerializeField]
    private LayerMask walkable;

    protected override Vector3 GetLocation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        return Physics.Raycast(ray, out hit, walkable) ? hit.point : transform.position;
    }
}
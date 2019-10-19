using UnityEngine;

public class HumanController : PlayerController
{
    [SerializeField]
    private LayerMask walkable;
    private Vector3 fate;

    protected override Vector3 GetLocation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return Physics.Raycast(ray, out hit, walkable) ? hit.point : transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fate = GetLocation();
            GoToLocation(new Vector3(fate.x, -0.5f, fate.z));
            Debug.Log(fate.x.ToString() + "," + fate.y.ToString() + "," + fate.z.ToString());
        }
    }
}
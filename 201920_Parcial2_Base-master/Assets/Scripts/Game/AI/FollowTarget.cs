using AI;

public class FollowTarget : Node
{
    public override void Execute()
    {
        GetComponent<AIController>().GoToLocation(GetComponent<AIController>().Target.transform.position);
    }
}
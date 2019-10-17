using AI;

public class IsActorTagged : SelectWithOption
{
    public override bool Check()
    {
        return GetComponent<AIController>().IsTagged;
    }
}
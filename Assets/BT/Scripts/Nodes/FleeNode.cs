using UnityEngine;

public class FleeNode : Node
{
    private Transform safeLocation;
    private AIController aiController;

    public FleeNode(Transform safeLocation, AIController aiController)
    {
        this.safeLocation = safeLocation;
        this.aiController = aiController;
    }

    public override State Evaluate()
    {
        if (Vector3.Distance(aiController.transform.position, safeLocation.position) > 0.5f)
        {
            aiController.MoveTo(safeLocation.position, aiController.patrolSpeed);
            state = State.RUNNING;
            return state;
        }
        state = State.SUCCESS;
        return state;
    }
}

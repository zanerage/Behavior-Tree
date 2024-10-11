using UnityEngine;

public class ChaseNode : Node
{
    private Transform player;
    private float detectionRange;
    private AIController aiController;

    public ChaseNode(Transform player, float detectionRange, AIController aiController)
    {
        this.player = player;
        this.detectionRange = detectionRange;
        this.aiController = aiController;
    }

    public override State Evaluate()
    {
        if (Vector3.Distance(aiController.transform.position, player.position) <= detectionRange)
        {
            aiController.MoveTo(player.position, aiController.chaseSpeed);
            state = State.RUNNING;
            return state;
        }
        state = State.FAILURE;
        return state;
    }
}

using UnityEngine;

public class AttackNode : Node
{
    private Transform player;
    private AIController aiController;
    private float attackRange;
    private float attackInterval;
    private float lastAttackTime;

    public AttackNode(Transform player, float attackRange, float attackInterval, AIController aiController)
    {
        this.player = player;
        this.attackRange = attackRange;
        this.attackInterval = attackInterval;
        this.aiController = aiController;
    }

    public override State Evaluate()
    {
        if (Vector3.Distance(aiController.transform.position, player.position) > attackRange)
        {
            state = State.FAILURE;
            return state;
        }

        if (Time.time - lastAttackTime > attackInterval)
        {
            // Attack logic here
            lastAttackTime = Time.time;
        }

        state = State.RUNNING;
        return state;
    }
}

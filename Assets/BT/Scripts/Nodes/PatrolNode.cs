using UnityEngine;

public class PatrolNode : Node
{
    private Transform[] waypoints;
    private AIController aiController;
    private int currentWaypointIndex = 0;

    public PatrolNode(Transform[] waypoints, AIController aiController)
    {
        this.waypoints = waypoints;
        this.aiController = aiController;
    }

    public override State Evaluate()
    {
        if (Vector3.Distance(aiController.transform.position, waypoints[currentWaypointIndex].position) < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        aiController.MoveTo(waypoints[currentWaypointIndex].position, aiController.patrolSpeed);
        state = State.RUNNING;
        return state;
    }
}
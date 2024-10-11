using UnityEngine;
using System.Collections.Generic;

public class AIController : MonoBehaviour
{
    public Transform[] waypoints;
    public float detectionRange = 5f;
    public Transform player;
    public float chaseSpeed = 3.5f;
    public float patrolSpeed = 2f;

    private int currentWaypointIndex = 0;
    private Node topNode;

    private void Start()
    {
        ConstructBehaviorTree();
    }

    private void Update()
    {
        topNode.Evaluate();
        if (topNode.NodeState == Node.State.RUNNING)
        {
            // Handle running state
        }
    }

    private void ConstructBehaviorTree()
    {
        PatrolNode patrolNode = new PatrolNode(waypoints, this);
        ChaseNode chaseNode = new ChaseNode(player, detectionRange, this);

        Selector patrolOrChase = new Selector(new List<Node> { chaseNode, patrolNode });
        topNode = patrolOrChase;
    }

    public void MoveTo(Vector3 destination, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}

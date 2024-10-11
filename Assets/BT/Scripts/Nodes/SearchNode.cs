using UnityEngine;

public class SearchNode : Node
{
    private AIController aiController;
    private Vector3 searchPosition;
    private float searchDuration;
    private float searchStartTime;

    public SearchNode(Vector3 searchPosition, float searchDuration, AIController aiController)
    {
        this.searchPosition = searchPosition;
        this.searchDuration = searchDuration;
        this.aiController = aiController;
    }

    public override State Evaluate()
    {
        if (Vector3.Distance(aiController.transform.position, searchPosition) > 0.5f)
        {
            aiController.MoveTo(searchPosition, aiController.patrolSpeed);
            state = State.RUNNING;
            return state;
        }

        if (Time.time - searchStartTime > searchDuration)
        {
            state = State.FAILURE;
            return state;
        }
        state = State.RUNNING;
        return state;
    }

    public void StartSearch()
    {
        searchStartTime = Time.time;
    }
}

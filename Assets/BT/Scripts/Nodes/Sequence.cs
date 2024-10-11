using System.Collections.Generic;

public class Sequence : Node
{
    protected List<Node> nodes = new List<Node>();

    public Sequence(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    public override State Evaluate()
    {
        bool anyNodeRunning = false;

        foreach (Node node in nodes)
        {
            switch (node.Evaluate())
            {
                case State.FAILURE:
                    state = State.FAILURE;
                    return state;
                case State.SUCCESS:
                    continue;
                case State.RUNNING:
                    anyNodeRunning = true;
                    continue;
                default:
                    state = State.SUCCESS;
                    return state;
            }
        }
        state = anyNodeRunning ? State.RUNNING : State.SUCCESS;
        return state;
    }
}

using System.Collections.Generic;

public class Selector : Node
{
    protected List<Node> nodes = new List<Node>();

    public Selector(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    public override State Evaluate()
    {
        foreach (Node node in nodes)
        {
            switch (node.Evaluate())
            {
                case State.SUCCESS:
                    state = State.SUCCESS;
                    return state;
                case State.RUNNING:
                    state = State.RUNNING;
                    return state;
                case State.FAILURE:
                    continue;
                default:
                    continue;
            }
        }
        state = State.FAILURE;
        return state;
    }
}


using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
    public enum State { RUNNING, SUCCESS, FAILURE }
    protected State state;

    public State NodeState => state;

    public abstract State Evaluate();
}




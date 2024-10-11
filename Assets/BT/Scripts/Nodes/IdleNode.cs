using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleNode : Node
{
    private float idleDuration;
    private float idleStartTime;
    private AIController aiController;

    public IdleNode(float idleDuration, AIController aiController)
    {
        this.idleDuration = idleDuration;
        this.aiController = aiController;
    }

    public override State Evaluate()
    {
        if (Time.time - idleStartTime > idleDuration)
        {
            state = State.SUCCESS;
            return state;
        }
        state = State.RUNNING;
        return state;
    }

    public void StartIdle()
    {
        idleStartTime = Time.time;
    }
}

using UnityEngine;
using System.Collections;

using AI.BehaviorTree;

public class RandCondition : Task {

    protected override string GetTaskName()
    {
        return "RandCondition";
    }

    protected override TaskStatus OnUpdate()
    {
        if (Random.Range(0,2) == 1)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}

using UnityEngine;
using System.Collections;

using AI.BehaviorTree;

public class GoSomewhere : Task
{
    private NavMeshAgent agent;
    private Vector3 target;

    protected override string GetTaskName()
    {
        return "GoSomewhere";
    }

    protected override void OnEnter()
    {
        base.OnEnter();

        if (agent == null)
            agent = board.gameObject.GetComponent<NavMeshAgent>();

        target = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
        agent.SetDestination(target);
    }

    protected override TaskStatus OnUpdate()
    {
        if (!agent.pathPending && Vector3.SqrMagnitude(board.gameObject.transform.position - target) < 1.5f)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }
}

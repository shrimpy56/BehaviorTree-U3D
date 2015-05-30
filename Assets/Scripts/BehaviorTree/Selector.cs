using UnityEngine;
using System.Collections;

namespace AI.BehaviorTree
{
    public class Selector : Composite
    {
        public Selector(params Task[] children) : base(children) { }

        protected override string GetTaskName()
        {
            return "Selector";
        }

        protected override TaskStatus OnUpdate()
        {
            if (currIdx >= children.Length)
                return TaskStatus.Failure;

            TaskStatus result = children[currIdx].Execute();
            if (result == TaskStatus.Failure)
            {
                ++currIdx;
                return TaskStatus.Running;
            }

            return result;
        }
    }
}

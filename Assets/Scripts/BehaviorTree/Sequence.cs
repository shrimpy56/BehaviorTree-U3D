using UnityEngine;
using System.Collections;

namespace AI.BehaviorTree
{
    public class Sequence : Composite
    {
        public Sequence(params Task[] children) : base(children) { }

        protected override string GetTaskName()
        {
            return "Sequence";
        }

        protected override TaskStatus OnUpdate()
        {
            if (currIdx >= children.Length)
                return TaskStatus.Success;

            TaskStatus result = children[currIdx].Execute();
            if (result == TaskStatus.Success)
            {
                ++currIdx;
                return TaskStatus.Running;
            }

            return result;
        }
    }
}
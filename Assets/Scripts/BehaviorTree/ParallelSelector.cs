using UnityEngine;
using System.Collections;

namespace AI.BehaviorTree
{
    public class ParallelSelector : Composite
    {
        private bool[] hasFinish;

        public ParallelSelector(params Task[] children)
            : base(children)
        {
            hasFinish = new bool[children.Length];
        }

        protected override string GetTaskName()
        {
            return "ParallelSelector";
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            for (int i = 0; i < hasFinish.Length; ++i)
                hasFinish[i] = false;
        }

        protected override TaskStatus OnUpdate()
        {
            bool flag = false;
            for (int i = 0; i < children.Length; ++i)
                if (!hasFinish[i])
                {
                    flag = true;
                    TaskStatus result = children[i].Execute();
                    if (result == TaskStatus.Success)
                        return TaskStatus.Success;
                    if (result == TaskStatus.Failure)
                        hasFinish[i] = true;
                }
            if (!flag) return TaskStatus.Failure;
            return TaskStatus.Running;
        }
    }
}
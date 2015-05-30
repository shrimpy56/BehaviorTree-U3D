using UnityEngine;
using System.Collections;

namespace AI.BehaviorTree
{
    public abstract class Composite : Task
    {
        protected Task[] children;
        protected int currIdx;

        public Composite(params Task[] children)
        {
            this.children = children;
        }

        public override void SetBlackboard(Blackboard board)
        {
            for (int i = 0; i < children.Length; ++i)
                children[i].SetBlackboard(board);
        }

        protected override string GetTaskName()
        {
            return "Composite";
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            currIdx = 0;
        }

        protected override void OnExit()
        {
            base.OnExit();
        }

        public override void ForceEnd()
        {
            for (int i = 0; i < children.Length; ++i)
            {
                children[i].ForceEnd();
            }
        }
    }
}
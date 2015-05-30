using UnityEngine;
using System.Collections;

namespace AI.BehaviorTree
{
    public abstract class Decorator : Task
    {
        protected Task child;

        public Decorator(Task child)
        {
            this.child = child;
        }

        protected override string GetTaskName()
        {
            return "Decorator";
        }
        
        public override void SetBlackboard(Blackboard board)
        {
            child.SetBlackboard(board);
        }
    }
}
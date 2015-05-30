using UnityEngine;
using System.Collections;

namespace AI.BehaviorTree
{
    public class BehaviorTree
    {
        public static bool isDebugMode = true;

        private Task root;

        public BehaviorTree(Blackboard board, Task root)
        {
            this.root = root;
            root.SetBlackboard(board);
        }

        public void Execute()
        {
            if (root.Execute() != TaskStatus.Running && isDebugMode)
                Debug.LogWarning("Finish Behavior Tree");
        }
    }
}
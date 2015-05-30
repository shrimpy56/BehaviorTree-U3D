using UnityEngine;
using System.Collections;

namespace AI.BehaviorTree
{
    public enum TaskStatus
    {
        Failure,
        Running,
        Success,
    }
    public abstract class Task
    {
        private bool isEntered;
        protected Blackboard board;

        public virtual void SetBlackboard(Blackboard board)
        {
            this.board = board;
        }

        public TaskStatus Execute()
        {
            if (!isEntered)
            {
                isEntered = true;
                if (BehaviorTree.isDebugMode)
                    Debug.Log("Enter "+GetTaskName());
                OnEnter();
            }
            TaskStatus result = OnUpdate();
            if (result != TaskStatus.Running)
            {
                isEntered = false;
                if (BehaviorTree.isDebugMode)
                    Debug.Log("Exit "+GetTaskName()+":"+result);
                OnExit();
            }
            return result;
        }

        protected virtual string GetTaskName()
        {
            return "Task";
        }

        public virtual void ForceEnd()
        {
            isEntered = false;
            OnExit();
        }

        protected virtual void OnEnter()
        {
        }

        protected virtual void OnExit()
        {
        }

        protected virtual TaskStatus OnUpdate()
        {
            return TaskStatus.Success;
        }
    }
}
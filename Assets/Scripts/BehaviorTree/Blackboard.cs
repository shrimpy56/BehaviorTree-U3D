using UnityEngine;
using System.Collections;

namespace AI.BehaviorTree
{
    public class Blackboard
    {
        public GameObject gameObject { get; private set; }

        public Blackboard(GameObject go)
        {
            gameObject = go;
        }
    }
}

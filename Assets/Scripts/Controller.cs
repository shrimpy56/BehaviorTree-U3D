using UnityEngine;
using System.Collections;

using AI.BehaviorTree;

public class Controller : MonoBehaviour {

    BehaviorTree bt;

	// Use this for initialization
	void Start () {
        bt = new BehaviorTree(new Blackboard(gameObject),
            new Selector(new RandCondition(), new GoSomewhere()));
	}
	
	// Update is called once per frame
	void Update () {
        bt.Execute();
	}
}

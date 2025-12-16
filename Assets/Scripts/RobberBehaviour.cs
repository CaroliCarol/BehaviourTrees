using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class RobberBehaviour : MonoBehaviour
{

    BehaviourTree tree;
    public GameObject diamond;
    public GameObject van;
    NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        tree = new BehaviourTree();
        Node steal = new Node("Steal Something");
        Leaf goToDiamond = new Leaf("Go To Diamond", GoToDiamond);
        Leaf goToVan = new Leaf("Go To Van", GoToVan);

        steal.AddChild(goToDiamond);
        steal.AddChild(goToVan);
        tree.AddChild(steal);

        tree.PrintTree();

        tree.Process();
    }

    public Node.Status GoToDiamond()
    {
        agent.SetDestination(diamond.transform.position);
        return Node.Status.SUCESS;
    }

    public Node.Status GoToVan()
    {
        agent.SetDestination(van.transform.position);
        return Node.Status.SUCESS;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Node
{
    public Node parent;
    public float cost;
    public Dictionary<string, int> state;
    public GAction action;

    public Node(Node parent, float cost, Dictionary<string, int> allstate, GAction action)
    {
        this.parent = parent;
        this.cost = cost;
        this.state = new Dictionary<string, int>(allstate);
        this.action = action;
    }

    public Node(Node parent, float cost, Dictionary<string, int> allstate, Dictionary<string, int> beliefState, GAction action)
    {
        this.parent = parent;
        this.cost = cost;
        this.state = new Dictionary<string, int>(allstate);
        foreach (KeyValuePair<string, int> b in beliefState)
        {
            if (!this.state.ContainsKey(b.Key))
            {
                this.state.Add(b.Key, b.Value);
            }
        }
        this.action = action;
    }
}



public class Gplanner
{
    public Queue<GAction> plan(List<GAction> actions, Dictionary<string, int> goal, WorldStates beliefStates)
    {
        List<GAction> usableActions = new List<GAction>();

        foreach (GAction a in actions) // Put all the action in
        {
            if (a.IsAchevable())
            {
                usableActions.Add(a);
            }
        }

        List<Node> leaves = new List<Node>();

        Node start = new Node(null, 0, GWorld.Instance.GetWorld().Getstates(), beliefStates.Getstates(), null);


        bool success = BuildGraph(start, leaves, usableActions, goal); //  add to the leaves

        if (!success)
        {
            return null;
        }

        Node cheapest = null;

        foreach (Node leaf in leaves)  // find next node in the leavs
        {
            if (cheapest == null)
                cheapest = leaf;
            else
            {
                //find the lowsest cost
                if (leaf.cost < cheapest.cost)
                    cheapest = leaf;
            }
        }

        List<GAction> result = new List<GAction>();

        Node n = cheapest;

        while (n != null)   // if it is chepaest
        {
            if (n.action != null)
            {
                result.Insert(0, n.action);
            }
            n = n.parent;
        }

        Queue<GAction> queue = new Queue<GAction>();

        foreach (GAction a in result)
        {
            queue.Enqueue(a);
        }

        foreach (GAction a in queue)
        {
            //Debug.Log("Q" + a.actionName); //DebugPurpose
        }
        return queue;
    }


    private bool BuildGraph(Node parent, List<Node> leaves, List<GAction> usableActions, Dictionary<string, int> goal)
    {
        bool foundpath = false;
        foreach (GAction action in usableActions) //Settled all
        {
            if (action.IsAchievableGiven(parent.state))
            {
                Dictionary<string, int> currentState = new Dictionary<string, int>(parent.state);

                foreach (KeyValuePair<string, int> eff in action.effects)
                {
                    if (!currentState.ContainsKey(eff.Key))
                    {
                        currentState.Add(eff.Key, eff.Value);
                    }


                    Node node = new Node(parent, parent.cost + action.cost, currentState, action);

                    if (GoalAchieved(goal, currentState))
                    {
                        leaves.Add(node);
                        foundpath = true;
                    }

                    else
                    {
                        List<GAction> subset = ActionSubset(usableActions, action);
                        bool found = BuildGraph(node, leaves, subset, goal);

                        if (found)
                        {
                            foundpath = true;
                        }
                    }
                }
            }
        }
        return foundpath;
    }

    private bool GoalAchieved(Dictionary<string, int> goal, Dictionary<string, int> state)
    {
        foreach (KeyValuePair<string, int> g in goal)
        {
            if (!state.ContainsKey(g.Key))
            {
                return false;
            }
        }
        return true;
    }

    private List<GAction> ActionSubset(List<GAction> actions, GAction removeMe)
    {
        List<GAction> subset = new List<GAction>();
        foreach (GAction a in actions)
        {
            if (!a.Equals(removeMe))
            {
                subset.Add(a);
            }
        }
        return subset;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaningAround : GAction
{
    [SerializeField] List<GameObject> locationTarget;

    public override bool PrePerform()
    {
        target = locationTarget[Random.Range(0, locationTarget.Count + 1)];

        return true;
    }
    public override bool PostPerform()
    {
        beliefs.Removestate("boring");

        return true;
    }
}

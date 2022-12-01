using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janitor : GAgent
{
    new private void Start()
    {
        base.Start();

        SubGoal sub1 = new SubGoal("HaningAround", 1, false);
        goals.Add(sub1, 1);

        SubGoal sub2 = new SubGoal("CleanPuddle", 1, false);
        goals.Add(sub2, 2);

        Invoke(nameof(NothingToDo), 1f);

        // ### Test purpose ###
        //  SubGoal s3 = new SubGoal("pee", 1, false);
        //  goals.Add(s3, 5);
    }

    void NothingToDo()
    {
        beliefs.ModifyState("boring", 0);
        Invoke(nameof(NothingToDo), Random.Range(1, 5));
    }

    void GetToToilet()
    {
        beliefs.ModifyState("WantToPee", 0);
        Invoke(nameof(GetToToilet), Random.Range(20, 40));
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : GAgent
{
    new private void Start()
    {
        base.Start();

        SubGoal sub1 = new SubGoal("Research", 1, false);
        goals.Add(sub1, 1);

        SubGoal sub2 = new SubGoal("rest", 1, false);
        goals.Add(sub2, 3);

        SubGoal sub3 = new SubGoal("pee", 1, false);
        goals.Add(sub3, 5);



        Invoke("GetTired", Random.Range(2, 20));
        Invoke(nameof(GetToToilet), Random.Range(20, 30));

    }

    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
        Invoke(nameof(GetTired), Random.Range(1, 5));
    }

    void GetToToilet()
    {
        beliefs.ModifyState("WantToPee", 0);
        Invoke(nameof(GetToToilet), Random.Range(20, 40));
    }

}


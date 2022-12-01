using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : GAgent
{
    new private void Start()
    {
        base.Start();
        SubGoal sub1 = new SubGoal("treatPatient", 1, false);// *false* the subtgoall will not able to be remove
        goals.Add(sub1, 3);

        SubGoal sub2 = new SubGoal("rested", 1, false);
        goals.Add(sub2, 1);

        SubGoal sub3 = new SubGoal("pee", 1, false);
        goals.Add(sub3, 5);

        Invoke("GetTired", Random.Range(10, 20));
        Invoke(nameof(GetToToilet), Random.Range(20, 30));


    }

    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
        Invoke(nameof(GetTired), Random.Range(10, 20));
    }
    void GetToToilet()
    {
        beliefs.ModifyState("WantToPee", 0);
        Invoke(nameof(GetToToilet), Random.Range(20, 40));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : GAgent
{
    [HideInInspector]
    public MoneySystem moneySystem;
    public int moneyToPay;

    new private void Start()
    {
        base.Start();
        SubGoal sub1 = new SubGoal("isWaiting", 1, true);
        goals.Add(sub1, 1);

        SubGoal sub2 = new SubGoal("isTreated", 1, true);
        goals.Add(sub2, 4);

        SubGoal sub3 = new SubGoal("isHome", 1, true);
        goals.Add(sub3, 2);

        SubGoal sub4 = new SubGoal("pee", 1, false);
        goals.Add(sub4, 3);

        Invoke(nameof(GetToToilet), Random.Range(5, 10));

    }

    public void SetUp(MoneySystem system)
    {
        moneySystem = system;
    }

    void GetToToilet()
    {
        beliefs.ModifyState("WantToPee", 0);
        Invoke(nameof(GetToToilet), Random.Range(20, 40));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHome : GAction
{
    Patient patient;
    private void Start()
    {
        patient = GetComponent<Patient>();
    }
    public override bool PrePerform()
    {
        beliefs.Removestate("atHospital");
        return true;
    }

    public override bool PostPerform()
    {
        MoneySystem money = patient.moneySystem;
        money.GotMoney(patient.moneyToPay);
        Destroy(this.gameObject);
        return true;
    }
}

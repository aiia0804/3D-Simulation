using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreated : GAction
{
        public override bool PrePerform()
    {
        target=inventory.FindItemWithTag("Cubicle");
        if(target==null)
        {
            return false;
        }
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Treated",1);//只是為了記錄用，不可以與GAgent的SGOAL 一樣
        beliefs.ModifyState("isCued",1);
        inventory.RemoveItem(target);
        return true;
    }
}

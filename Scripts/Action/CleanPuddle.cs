using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanPuddle : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("puddles").RemoveResource();
        if (target == null)
        {
            return false;
        }
        inventory.Additem(target);
        GWorld.Instance.GetWorld().ModifyState("PuddleLeft", -1);
        return true;
    }

    public override bool PostPerform()
    {
        inventory.RemoveItem(target);
        Destroy(target.gameObject);

        return true;


    }


}

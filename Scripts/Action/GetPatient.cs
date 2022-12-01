using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPatient : GAction
{
    GameObject resource;

    public override bool PrePerform()
    {

        target = GWorld.Instance.GetQueue("patients").RemoveResource();
        if (target == null)
        {
            return false;
        }

        resource = GWorld.Instance.GetQueue("cubicles").RemoveResource();

        if (resource != null)
        {
            inventory.Additem(resource);
        }

        else  // Cubicle no more space
        {
            GWorld.Instance.GetQueue("patients").AddResource(target);
            target = null;
            return false;
        }


        GWorld.Instance.GetWorld().ModifyState("FreeCubicle", -1);

        return true;
    }
    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Waiting", -1);
        if (target)  // 把Cubicle加入此TARGET的INVETORY 裡, 可以讓二人一起有標過去
        {
            target.GetComponent<GAgent>().inventory.Additem(resource);
        }
        return true;
    }
}

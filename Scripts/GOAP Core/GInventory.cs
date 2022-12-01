using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GInventory 
{
    public List<GameObject> items = new List<GameObject>();

    public void Additem(GameObject i)
    {
        items.Add(i);
    }

    public GameObject FindItemWithTag(string tag)
    {
        foreach(GameObject item in items)
        {
            if(item==null)break;
            if(item.tag==tag)
            {
                return item;
            }
        }
        return null;
    }

    public void RemoveItem(GameObject itemPassIn)
    {
        int indexToRemove=-1;
        foreach(GameObject item in items)
        {
            indexToRemove++;
            if(item==itemPassIn)
            {
                break;
            }
        }

        if(indexToRemove>=-1)
        {
            items.RemoveAt(indexToRemove);
        }
    }
}

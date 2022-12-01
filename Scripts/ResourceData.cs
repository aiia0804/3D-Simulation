using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="resourcedata",menuName="resource Data",order=51)]
public class ResourceData : ScriptableObject
{
    public string resourcesTag;
    public string resourceQueue;
    public string resourceState;
}

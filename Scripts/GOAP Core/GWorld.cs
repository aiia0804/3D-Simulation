using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ResourceQueue
{
    public Queue<GameObject> que = new Queue<GameObject>();
    public string tag;
    public string modState;

    public ResourceQueue(string t, string ms, WorldStates w)
    {
        tag = t;
        modState = ms;
        if (tag != "")
        {
            GameObject[] resources = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject r in resources)
            {
                que.Enqueue(r);
            }
        }
        if (modState != "")
        {
            w.ModifyState(modState, que.Count);
        }

    }
    public void AddResource(GameObject g)
    {
        que.Enqueue(g);
    }
    public void RemoveResource(GameObject r) //For removing all the sourse in the scene
    {
        que = new Queue<GameObject>(que.Where(p => p != r));
    }
    public GameObject RemoveResource()
    {
        if (que.Count == 0) { return null; }
        return que.Dequeue();
    }
}

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;
    private static ResourceQueue patients;
    private static ResourceQueue cubicles;
    private static ResourceQueue offices;
    private static ResourceQueue toilets;
    private static ResourceQueue puddles;

    private static Dictionary<string, ResourceQueue> resources = new Dictionary<string, ResourceQueue>();




    static GWorld()
    {
        world = new WorldStates();

        //第一個STRING 是為了RESOURCES 這個DICTIONARY 辦識用

        patients = new ResourceQueue("", "", world);
        resources.Add("patients", patients);

        cubicles = new ResourceQueue("Cubicle", "FreeCubicle", world);
        resources.Add("cubicles", cubicles);

        offices = new ResourceQueue("Office", "FreeOffice", world);
        resources.Add("offices", offices);

        toilets = new ResourceQueue("Toilet", "FreeToilet", world);
        resources.Add("toilets", toilets);

        puddles = new ResourceQueue("Puddle", "PuddleLeft", world);
        resources.Add("puddles", puddles);


    }

    private GWorld()
    {
    }

    public ResourceQueue GetQueue(string type)
    {
        return resources[type];
    }


    public static GWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }

}


//### For test purpose

// var cubes = GameObject.FindGameObjectsWithTag("Cubicle");
// foreach(var cubicle in cubes)
// {
//     cubicles.Enqueue(cubicle);
// }

// if(cubes.Length>0)
// {
//     world.ModifyState("FreeCubicle",cubes.Length);
// }

//     public void AddCubicle(GameObject q)
//     {
//         cubicles.Enqueue(q);
//     }
//    public GameObject RemoveCubicle()
//    {
//        if(cubicles.Count==0) {return null;}
//        return cubicles.Dequeue();
//    }

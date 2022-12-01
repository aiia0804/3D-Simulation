using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GStartMonitor : MonoBehaviour
{
    public string state;
    public float stateStrgenth;  // how long can we hold on for some state
    public float stateDecayRate; // the rate of count down
    public WorldStates beliefs; // to monintor the praticularu beliefs states
    public GameObject resourePrefab;
    public string queueName;
    public string worldState;
    public GAction action;

    bool stateFound = false;
    float initalStrength; // back to normal state

    void Start()
    {
        beliefs = this.GetComponent<GAgent>().beliefs;
        initalStrength = stateStrgenth;
    }

    void Update()
    {
        if (action.running)   
        {
            stateFound = false;         
            stateStrgenth = initalStrength;  
        }

        if (!stateFound && beliefs.HasState(state))   
        {
            stateFound = true;
        }

        if (stateFound)
        {
            stateStrgenth -= stateDecayRate * Time.deltaTime;
            if (stateStrgenth <= 0)
            {
                Vector3 location = new Vector3(this.transform.position.x, resourePrefab.transform.position.y, this.transform.position.z);

                GameObject resourceInstance = Instantiate(resourePrefab, location, resourePrefab.transform.rotation);
                stateFound = false;
                stateStrgenth = initalStrength;
                beliefs.Removestate(state);

                GWorld.Instance.GetQueue(queueName).AddResource(resourceInstance);
                GWorld.Instance.GetWorld().ModifyState(worldState, 1);
            }
        }
    }
}

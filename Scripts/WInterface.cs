using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class WInterface : MonoBehaviour
{
    GameObject focusObj;
    ResourceData foData;
    GameObject newResourcePrefab;
    public GameObject[] allResources;

    Vector3 goalPos;
    public NavMeshSurface surface;
    public GameObject hospital;
    Vector3 clickOffset = Vector3.zero;
    bool offsetCalc = false;
    bool deleteResource = false;


    public void MouseOnHoverTrash()
    {
        deleteResource = true;
    }

    public void MOuseOutHoverTrash()
    {
        deleteResource = false;
    }

    public void ActivateToilet()
    {
        newResourcePrefab = allResources[0];
    }
    public void ActivateCubicle()
    {
        newResourcePrefab = allResources[1];
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))   // Drop
        {
            if (EventSystem.current.IsPointerOverGameObject()) { return; }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit)) { return; }

            offsetCalc = false;
            clickOffset = Vector3.zero;

            Resource r = hit.transform.gameObject.GetComponent<Resource>();

            if (r != null)
            {
                focusObj = hit.transform.gameObject;
                foData = r.data;
            }

            else if (newResourcePrefab != null)
            {
                goalPos = hit.point;

                focusObj = Instantiate(newResourcePrefab, goalPos, newResourcePrefab.transform.rotation);
                foData = focusObj.GetComponent<Resource>().data;
                newResourcePrefab = null;
            }

            if (focusObj)
            {
                focusObj.GetComponent<Collider>().enabled = false;
            }
        }

        else if (focusObj && Input.GetMouseButtonUp(0))
        {
            if (deleteResource)
            {
                GWorld.Instance.GetQueue(foData.resourceQueue).RemoveResource(focusObj);
                GWorld.Instance.GetWorld().ModifyState(foData.resourceState, -1);
                Destroy(focusObj);
            }
            else
            {
                focusObj.transform.parent = hospital.transform;
                GWorld.Instance.GetQueue(foData.resourceQueue).AddResource(focusObj);
                GWorld.Instance.GetWorld().ModifyState(foData.resourceState, 1);
                focusObj.GetComponent<Collider>().enabled = true;

            }
            surface.BuildNavMesh();
            focusObj = null;
        }

        else if (focusObj && Input.GetMouseButton(0))   // Drag(Move)
        {
            int layerMask = 1 << 6;
            RaycastHit hitMove;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hitMove, Mathf.Infinity, layerMask)) { return; }

            if (!offsetCalc)
            {
                clickOffset = hitMove.point - focusObj.transform.position;
                offsetCalc = true;
            }

            goalPos = hitMove.point - clickOffset;
            //focusObj.transform.position=goalPos;
            focusObj.transform.position = new Vector3(goalPos.x, hitMove.transform.position.y, goalPos.z);
        }

        if (focusObj && Input.GetKeyDown(KeyCode.Alpha1))
        {
            focusObj.transform.Rotate(0, 90, 0);
        }

        else if (focusObj && Input.GetKeyDown(KeyCode.Alpha2))
        {
            focusObj.transform.Rotate(0, -90, 0);
        }
    }
}

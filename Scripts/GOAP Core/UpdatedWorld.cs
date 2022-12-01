using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatedWorld : MonoBehaviour
{
    public Text states;
    [SerializeField] float timeSpeed = 1f;

    private void LateUpdate()
    {
        Dictionary<string, int> worldstates = GWorld.Instance.GetWorld().Getstates();
        states.text = "";
        //print(worldstates.Count);
        foreach (KeyValuePair<string, int> s in worldstates)
        {
            states.text += s.Key + ", " + s.Value + "\n";
        }

        Time.timeScale = timeSpeed;

    }
}

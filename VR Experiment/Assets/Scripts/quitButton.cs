using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitButton : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.5f)
        {
            Debug.Log("Quitting game...");
            Application.Quit();
        }
    }
}

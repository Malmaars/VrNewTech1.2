using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCheck : MonoBehaviour
{
    public Transform night;
    public Transform day;
    public Material skyboxNoon;
    public Material skyboxNight;

    public bool checkCheck;

    private void Update()
    {
        if(night.position.y > day.position.y)
        {
            RenderSettings.skybox = skyboxNight;
        }

        else
        {
            RenderSettings.skybox = skyboxNoon;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<KeyAndLock>() != null)
        {
            checkCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<KeyAndLock>() != null)
        {
            checkCheck = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCheck : MonoBehaviour
{
    public GameObject telescope;

    public Transform night;
    public Transform day;
    
    public Material skyboxNoon;
    public Material skyboxNight;
    public Material teleDay;
    public Material teleNight;

    public bool checkCheck;

    private void Update()
    {
        if(night.position.y > day.position.y)
        {
            RenderSettings.skybox = skyboxNight;
            telescope.GetComponent<MeshRenderer>().material = teleNight;
        }

        else
        {
            RenderSettings.skybox = skyboxNoon;
            telescope.GetComponent<MeshRenderer>().material = teleDay;
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

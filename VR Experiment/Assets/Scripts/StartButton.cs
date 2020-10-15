using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject StartUI;
    public GameObject InfoUI;

    public Transform playerController;

    private bool started;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        if (StartUI)
            StartUI.SetActive(true);
        if (InfoUI)
            InfoUI.SetActive(false);

        playerController.transform.SetPositionAndRotation(new Vector3(
            this.transform.position.x, 0, this.transform.position.z - 1), playerController.transform.rotation);
        playerController.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ);
    }

    private void DoStart()
    {
        playerController.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        StartUI.SetActive(false);
        InfoUI.SetActive(true);
        started = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.5f)
        {
            if(!started)
                DoStart();
        }
    }
}

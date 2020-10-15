﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    private Transform prevParent;
    private GameObject grabbedObject;

    Resizer resizer;

    private Vector3 currentObjectLoc;
    private Vector3 lastObjectLoc;

    private Vector3 rotationOfGrab;

    private bool firstGrab;

    public bool LeftHand;
    public bool RightHand;

    // Start is called before the first frame update
    void Start()
    {
        resizer = FindObjectOfType<Resizer>();
    }

    // Update is called once per frame
    void Update()
    {
        releaseObject();
    }

    public void releaseObject()
    {
        if ((LeftHand == true && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) < 0.75f) || (RightHand == true && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) < 0.75f))
        {
            if (grabbedObject != null)
            {
                //release object

                grabbedObject.transform.SetParent(null);

                if (grabbedObject.GetComponent<Rigidbody>() != null)
                {
                    grabbedObject.GetComponent<Rigidbody>().isKinematic = false;

                    if (LeftHand == true)
                        grabbedObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);

                    if (RightHand == true)
                        grabbedObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);

                }

                grabbedObject = null;
            }

            firstGrab = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() 
            && ((LeftHand == true && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 0.75f) || (RightHand == true && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.75f))
            && other.GetComponent<Rigidbody>().isKinematic == false)
        {
            if ((other.gameObject.tag == "SmallObject" && resizer.playerSize == false) || (other.gameObject.tag == "LargeObject" && resizer.playerSize == true))
            {
                if (other.GetComponent<KeyAndLock>())
                {
                    if (firstGrab == false)
                    {
                        rotationOfGrab = this.transform.rotation.eulerAngles;
                        firstGrab = true;
                    }

                    Vector3 rotationDiff = rotationOfGrab + this.transform.rotation.eulerAngles;
                    other.transform.rotation = Quaternion.Euler(new Vector3(rotationDiff.x, 90, 0));
                }

                else
                {
                    //grab object
                    grabbedObject = other.gameObject;

                    if (firstGrab == false)
                    {
                        if (grabbedObject.transform.parent != null)
                            prevParent = grabbedObject.transform.parent;

                        grabbedObject.transform.SetParent(this.transform);

                        firstGrab = true;
                    }

                    grabbedObject.transform.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }
}

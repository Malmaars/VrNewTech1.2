using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAndLock : MonoBehaviour
{
    private GameObject target;
    private bool moveBool;

    // Start is called before the first frame update
    void Awake()
    {
        target = FindObjectOfType<LockCheck>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveBool)
        {
            if (Vector3.Distance(this.transform.position, target.transform.position) <= 0.01f)
            {
                this.transform.position = target.transform.position;
            }

            else
                this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, Time.deltaTime * 5);
        }

        if(this.transform.position == target.transform.position)
        {
            target.transform.SetParent(this.transform);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<LockCheck>() != null && other.GetComponent<LockCheck>().checkCheck)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(90, 90, 0));
            moveBool = true;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}

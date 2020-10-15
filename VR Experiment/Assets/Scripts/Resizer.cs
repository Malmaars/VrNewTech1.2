using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    public Transform smallPlayer;
    public Transform largePlayer;
    public Transform PlayerController;

    public bool playerSize; //false is small, big is true
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
        {
            SwitchSize();
        }
    }

    public void SwitchSize()
    {
        playerSize = !playerSize;

        if (!playerSize)
        {
            PlayerController.SetParent(smallPlayer);
        }

        else
        {
            PlayerController.SetParent(largePlayer);
        }

        PlayerController.localPosition = Vector3.zero;
        PlayerController.localScale = Vector3.one;
    }
}

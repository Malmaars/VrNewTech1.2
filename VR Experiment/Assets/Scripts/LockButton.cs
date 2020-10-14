using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockButton : MonoBehaviour
{
    public GameObject NumberWheel;

    public int currentValue { get; private set; }
    private bool canIncrement = true;

    private void OnTriggerStay(Collider other)
    {
        //als de knop ingedrukt wordt en de knop ook echt gebruikt kan worden
        if(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.7f && canIncrement)
        {
            //verhoog de value maar blijf binnen 0-9
            currentValue += 1;
            if (currentValue == 10)
                currentValue = 0;

            //draai het getalwiel om visueel aan te geven wat het getal is
            NumberWheel.transform.Rotate(new Vector3(0, 36f, 0));

            //om te voorkomen dat de waarde 60x per sec ofzo gedaan wordt
            canIncrement = false;
        }

        //loslaten voor je het weer kan indrukken
        if(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) < 0.2f)
            canIncrement = true;
    }
}

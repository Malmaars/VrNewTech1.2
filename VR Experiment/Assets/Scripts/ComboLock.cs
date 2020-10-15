using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboLock : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;
    public LockButton top, middle, bottom;      //de knoppen (voor toegang tot hun value)
    public int[] solution;                      //de solution waarmee het slot open gaat

    private bool locked = true;

    void Start()
    {
        if (solution.Length == 0)
        {
            Debug.LogError("Lock has no solution assigned!");
            solution = new int[] { 0, 0, 0 };
        }
    }

    void Update()
    {
        if (locked)
        {
            if (top.currentValue == solution[0] && middle.currentValue == solution[1] && bottom.currentValue == solution[2])
                Unlock();
        }
    }

    private void Unlock()
    {
        //do unlock stuff here
        locked = false;
        Debug.Log("Lock opened!");
        this.gameObject.SetActive(false);

        doorLeft.transform.rotation = Quaternion.Euler(doorLeft.transform.rotation.eulerAngles.x, 135, doorLeft.transform.rotation.eulerAngles.z);
        doorRight.transform.rotation = Quaternion.Euler(doorRight.transform.rotation.eulerAngles.x, -135, doorRight.transform.rotation.eulerAngles.z);

    }
}

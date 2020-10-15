using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTransformer : MonoBehaviour
{
    public List<GameObject> keyParts;
    public GameObject wholeKey;
    public GameObject keyPartMiddle;
    public int Keycount; //If it's 6, assemble key

    public void AssembleKey()
    {
        Instantiate(wholeKey, keyPartMiddle.transform.position, keyPartMiddle.transform.rotation);

        for (int i = 0; i < keyParts.Count; i++)
        {
            Destroy(keyParts[i].gameObject);
        }
    }
}

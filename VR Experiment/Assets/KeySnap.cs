using UnityEngine;

public class KeySnap : MonoBehaviour
{
    KeyTransformer keyTransformer;
    public bool mergeAbility;

    public GameObject targetKeyPart;

    private void Start()
    {
        keyTransformer = FindObjectOfType<KeyTransformer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<KeySnap>() != null && targetKeyPart == other.gameObject)
        {
            mergeAbility = true;
            keyTransformer.Keycount += 1;

            if(keyTransformer.Keycount == 6)
            {
                keyTransformer.AssembleKey();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInChildren<KeySnap>() != null && targetKeyPart == other.gameObject)
        {
            mergeAbility = false;
            keyTransformer.Keycount -= 1;
        }
    }
}

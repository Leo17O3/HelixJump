using UnityEngine;

public class TriggerPlatformPart : MonoBehaviour, ITriggerPlatform
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<BasePlatform>().Break();
        }
    }
}

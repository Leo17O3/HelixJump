using UnityEngine;

public class TriggerPlatformPart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<BasePlatform>().Break();
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public static event UnityAction Jump;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out BasePlatform basePlatform))
        {
            Jump?.Invoke();
        }
    }
}

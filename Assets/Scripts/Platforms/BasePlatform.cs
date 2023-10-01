using UnityEngine;

public abstract class BasePlatform : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            Debug.Log("Added!");
        }
    }
}

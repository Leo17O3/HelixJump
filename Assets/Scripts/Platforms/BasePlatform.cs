using System.Threading.Tasks;
using UnityEngine;

public abstract class BasePlatform : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;

    public async void Break()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out Rigidbody rigidbody))
            {
                continue;
            }

            rigidbody = transform.GetChild(i).gameObject.AddComponent<Rigidbody>();

            while (rigidbody == null)
                await Task.Yield();

            transform.parent = null;
            rigidbody.AddExplosionForce(_force, this.transform.position, _radius);
            Destroy(gameObject, 2f);
        }
    }
}

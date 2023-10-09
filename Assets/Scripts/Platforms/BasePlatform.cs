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

            Rigidbody rigidbody = transform.GetChild(i).gameObject.AddComponent<Rigidbody>();

            while (rigidbody == null)
                await Task.Yield();

            rigidbody.AddExplosionForce(_force, this.transform.position, _radius);

        }
    }
}

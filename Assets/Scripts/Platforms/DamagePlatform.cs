using UnityEngine;

[RequireComponent(typeof(DamagePlayer))]
public class DamagePlatform : MonoBehaviour, ITriggerPlatform
{
    [SerializeField] private float _waitTime;
    [SerializeField] private DamagePlayer _damagePlayer;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _damagePlayer.Damage(other.gameObject, _waitTime);
        }
    }
}

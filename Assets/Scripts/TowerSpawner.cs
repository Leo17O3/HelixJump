using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additiveScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private FinishPlatform _finishPlatform;

    private void Start()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1f, _levelCount / 2, 1f);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y + _additiveScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, Quaternion.identity, beam.transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), beam.transform);
        }

        beam.transform.localScale = new Vector3(1f, beam.transform.localScale.y + _additiveScale, 1f);

        Vector3 beamScale = new Vector3(0f, -beam.transform.localScale.y, 0f);

        SpawnPlatform(_finishPlatform, ref beamScale, Quaternion.identity, beam.transform);

        //beam.transform.localScale = new Vector3(1f, beam.transform.localScale.y + _additiveScale, 1f);
        SpawnAdditiveGameObject(beam.transform.position.y + beam.transform.localScale.y + _additiveScale, beam.transform);
        SpawnAdditiveGameObject(-beam.transform.position.y - beam.transform.localScale.y - _additiveScale, beam.transform);
    }

    private void SpawnPlatform(BasePlatform platform, ref Vector3 spawnPosition, Quaternion rotation, Transform parent)
    {
        Instantiate(platform, spawnPosition, rotation, parent);
        spawnPosition.y -= 1;
    }

    private void SpawnAdditiveGameObject(float positionY, Transform parent)
    {
        Transform additiveTransform = GameObject.CreatePrimitive(PrimitiveType.Cylinder).transform;
        additiveTransform.localScale = new Vector3(1f, _additiveScale, 1f);
        additiveTransform.position = new Vector3(0f, positionY, 0f);
        additiveTransform.parent = parent;
    }
}

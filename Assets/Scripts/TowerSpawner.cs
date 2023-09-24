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
        spawnPosition.y += beam.transform.localScale.y;

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition, beam.transform);
        }

        beam.transform.localScale = new Vector3(1f, beam.transform.localScale.y + _additiveScale, 1f);
        spawnPosition.y = beam.transform.localScale.y;

        SpawnPlatform(_spawnPlatform.gameObject, ref spawnPosition, beam.transform);
        SpawnPlatform(_finishPlatform.gameObject, ref spawnPosition, beam.transform);

        beam.transform.localScale = new Vector3(1f, beam.transform.localScale.y + _additiveScale, 1f);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1;
    }

    private void SpawnPlatform(GameObject platformToSpawn, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platformToSpawn, spawnPosition, Quaternion.identity, parent);
        spawnPosition.y *= -1;
    }
}

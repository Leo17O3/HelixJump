using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    private int _levelCount => PlayerData.Instance.LevelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private FinishPlatform _finishPlatform;
    private float _startAndFinishAdditionalScale = 0.5f;

    private float _beamScaleY => _additionalScale / 2f + _startAndFinishAdditionalScale + _levelCount / 2f;

    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1f, _beamScaleY, 1f);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, Quaternion.Euler(0, 30f, 0), beam.transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), beam.transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, Quaternion.identity, beam.transform);
    }

    private void SpawnPlatform(BasePlatform platform, ref Vector3 spawnPosition, Quaternion rotation, Transform parent)
    {
        Instantiate(platform, spawnPosition, rotation, parent);
        spawnPosition.y -= 1;
    }
}

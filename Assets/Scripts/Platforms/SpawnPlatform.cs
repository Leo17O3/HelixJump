using UnityEngine;

public class SpawnPlatform : BasePlatform
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Vector3 _spawnPoint;

    private void Awake()
    {
        SpawnBall();
    }

    private void SpawnBall()
    {
        Instantiate(_ball, _spawnPoint, Quaternion.identity);
    }
}

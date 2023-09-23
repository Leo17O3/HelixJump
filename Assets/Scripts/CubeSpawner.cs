using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private Vector3 _position = new Vector3(0, 0, 0);
    private int _currentCubeIndex = 1;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
            CreateCube();
    }

    private void CreateCube()
    {
        GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<CheckClick>().SetPosition(_position);
        _position = new Vector3(_position.x + 1f, _position.y + 0.5f, 0);
    }
}

using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    public int LevelCount = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

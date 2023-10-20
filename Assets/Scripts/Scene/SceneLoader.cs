using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void Load(int index) => SceneManager.LoadScene(index);
    public static void Load(string name) => SceneManager.LoadScene(name);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneButton : MonoBehaviour
{
    public void Win(int additiveLevelCount)
    {
        PlayerData.Instance.LevelCount += additiveLevelCount;
        Time.timeScale = 1f;
        SceneLoader.Load("GameScene");
    }
}

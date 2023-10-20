using System.Collections;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public void Damage(GameObject player, float waitTime)
    {
        StartCoroutine(DamagePlayerCoroutine(player, waitTime));
    }

    private IEnumerator DamagePlayerCoroutine(GameObject player, float waitTime)
    {
        player.SetActive(false);
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(waitTime);

        Time.timeScale = 1f;
        SceneLoader.Load("GameScene");
    }
}

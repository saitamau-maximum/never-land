using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpDoor : MonoBehaviour // ← ここをファイル名と同じにする
{
    public string nextSceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}

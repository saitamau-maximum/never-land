using UnityEngine;
using UnityEngine.SceneManagement;

public class あなたのスクリプト名 : MonoBehaviour
{
    public string nextSceneName;
    private bool isTransitioning = false; // ★クラスの「中」に書く

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isTransitioning) return; // ★すでに移動中なら何もしない

        if (other.CompareTag("Player"))
        {
            isTransitioning = true; // ★移動中フラグをONにする
            SceneFader.Instance.FadeToScene(nextSceneName);
        }
    }
} // ← この一番最後の「}」より下にコードを書かない！

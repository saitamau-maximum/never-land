using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance;
    public Image blackPanel; // インスペクターでBlackPanelをセット
    public float fadeDuration = 0.5f; // 暗転にかかる時間（秒）

    void Awake()
    {
        // シーンをまたいでも消えないようにする（重複防止付き）
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

    // 外部（青い四角など）からこの関数を呼ぶ
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOutAndIn(sceneName));
    }

    IEnumerator FadeOutAndIn(string sceneName)
    {
        // 1. 徐々に暗くする（Alpha 0 -> 1）
        float timer = 0f;
        Color color = blackPanel.color;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Clamp01(timer / fadeDuration);
            blackPanel.color = color;
            yield return null; // 1フレーム待つ
        }

        // 2. シーンを切り替える（今の仕組みをそのまま利用）
        SceneManager.LoadScene(sceneName);

        // 3. 徐々に明るくする（Alpha 1 -> 0）
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = 1f - Mathf.Clamp01(timer / fadeDuration);
            blackPanel.color = color;
            yield return null;
        }
    }
}

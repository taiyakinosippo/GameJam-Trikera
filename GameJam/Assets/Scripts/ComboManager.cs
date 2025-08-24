using UnityEngine;
using TMPro;
using System.Collections;

public class ComboManager : MonoBehaviour
{
    public TMP_Text comboText;   // TextMeshPro用
    public int comboCount = 0;
    private Coroutine fadeCoroutine;

    // コンボ加算
    public void AddCombo()
    {
        comboCount++;
        comboText.text = comboCount.ToString() + " combo";
        comboText.color = new Color(comboText.color.r, comboText.color.g, comboText.color.b, 1);

        // フェードアウトを再スタート
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeOutText());
    }

    // コンボリセット
    public void ResetCombo()
    {
        comboCount = 0;
    }

    public int GetComboCount()
    {
        return comboCount;
    }


    // フェードアウト処理
    private IEnumerator FadeOutText()
    {
        float duration = 1.0f; // フェードアウトの時間（秒）
        float elapsed = 0f;

        Color startColor = comboText.color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            comboText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }
    }
}

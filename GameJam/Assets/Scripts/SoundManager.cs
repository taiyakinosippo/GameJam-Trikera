using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgm;   // BGM用のAudioSource
    public int score;         // 現在のスコア
    public ComboManager comboManager; // コンボのスクリプト

    void Update()
    {
        int combo = comboManager.comboCount;

        // コンボに応じてピッチを上げる
        float newPitch = 1.0f + (combo / 10f);

        // 最大ピッチを 2.0 に制限
        newPitch = Mathf.Clamp(newPitch, 1.0f, 2.0f);

        bgm.pitch = newPitch;

        Debug.Log($"今のピッチ: {newPitch}");
    }


    public void test()
    {
        score += 1;
    }

    public void reset()
    {
        score = 0;
    }
}

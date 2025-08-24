using UnityEngine;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    private static string key = "ScoreData";

    // スコアを保存する
    public static void SaveScore(int newScore)
    {
        ScoreData data = LoadScores();

        // 新しいスコアを追加
        data.scores.Add(newScore);

        // 高い順にソート
        data.scores.Sort((a, b) => b.CompareTo(a));

        // 上位10件だけ保持
        if (data.scores.Count > 10)
            data.scores = data.scores.GetRange(0, 10);

        // JSON に変換して保存
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    // スコア一覧を読み込む
    public static ScoreData LoadScores()
    {
        if (PlayerPrefs.HasKey(key))
        {
            string json = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<ScoreData>(json);
        }
        else
        {
            return new ScoreData();
        }
    }
}

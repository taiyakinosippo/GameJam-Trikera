using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ImageCheck : MonoBehaviour
{
    // 左側の画像の番号
    public int LeftNo;
    // 右側の画像の番号
    public int RightNo;
    // 画像が正しく組み合わさっているかどうか
    private bool is_same;
    // 連続成功カウント用の変数
    public int continuity;

    // コンボに関するスクリプト
    public ComboManager ComboManager;

    // スコアに関するスクリプト
    public test test;

    // ライフ管理用スクリプト
    public LifeManager2 LifeManager2;

    // 中央画像制御用スクリプト
    public CenterImage centerImage;

    [SerializeField] private AudioSource correct; // 正解時の効果音

    public void Continuous()
    {
        if (!GameManager.instance.end)
        {
            // 正しい組み合わせなら true
            if (RightNo == 0 && LeftNo == 5 || RightNo == 1 && LeftNo == 6 ||
               RightNo == 2 && LeftNo == 7 || RightNo == 3 && LeftNo == 8 ||
               RightNo == 4 && LeftNo == 9 || RightNo == 5 && LeftNo == 0 ||
               RightNo == 6 && LeftNo == 1 || RightNo == 7 && LeftNo == 2 ||
               RightNo == 8 && LeftNo == 3 || RightNo == 9 && LeftNo == 4)
            {
                Debug.Log("正解！");
                Debug.Log($"連続成功数:{continuity}");
                continuity++;
                ComboManager.AddCombo();    // コンボを加算
                test.SaveTest();            // スコア更新
                correct.Play();             // 効果音再生
                centerImage.CorrectImage(LeftNo); // 中央画像を正解演出
            }
            else
            {
                Debug.Log("不正解！");
                Debug.Log("コンボが0にリセットされました");
                ComboManager.ResetCombo();  // コンボをリセット
                LifeManager2.LifeDown();    // ライフを減らす
                centerImage.MissImage();    // 中央画像をミス演出
            }
        }
    }

    // 左側の画像番号を設定
    public void LeftImageNo(int i)
    {
        LeftNo = i;
    }

    // 右側の画像番号を設定
    public void RightImageNo(int i)
    {
        RightNo = i;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CreateManager : MonoBehaviour
{
    [SerializeField] public Image[] peacePrefabs;  // 生成するプレハブ
    [SerializeField] private Transform canvas;      // 生成先のキャンバス
    [SerializeField] private Vector3 spawnPoints;   // 生成位置
    [SerializeField] private int SpwanFrame;        // 生成間隔（フレーム）
    private int spawnTimer = 0;                     // 生成用タイマー

    public ComboManager comboManager;
    public PieceManager2 pieceManager2;
    private ImageCheck ImageCheck;
    private SetZone SetZone;
    public int RandomImage;

    int combo = 0;

    void Start()
    {
        SetZone = FindObjectOfType<SetZone>();
        ImageCheck = FindObjectOfType<ImageCheck>();
        ShowImage();
    }

    void Update()
    {
        combo = comboManager.comboCount;

        // コンボの上限は20
        int effectiveCombo = Mathf.Min(combo, 20);

        spawnTimer++;

        // 生成間隔をコンボに応じて短縮（最小10フレーム）
        int interval = Mathf.Max(10, SpwanFrame - effectiveCombo * 20);

        if (spawnTimer >= interval)
        {
            ShowImage();
        }
    }

    void ShowImage()
    {
        // タイマーリセット
        spawnTimer = 0;

        // ランダムなプレハブを生成
        RandomImage = Random.Range(0, peacePrefabs.Length);
        pieceManager2.SetPiece();
        Image image = Instantiate(peacePrefabs[RandomImage], canvas);

        // ランダムで取得した画像番号を判定スクリプトに渡す
        ImageCheck.LeftImageNo(RandomImage);

        // SetZone に座標を渡す
        SetZone.RightImageTransForm(image);

        // Imageを左右反転させる
        Vector3 scale = image.rectTransform.localScale;
        image.rectTransform.localScale = new Vector3(-scale.x, scale.y, scale.z);

        // 生成位置を設定
        image.transform.localPosition = spawnPoints;
    }

    public int ReturnRandomImage()
    {
        return RandomImage;
    }
}

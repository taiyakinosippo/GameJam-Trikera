using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PieceManager2 : MonoBehaviour
{
    public List<Image> slots;         // Slot0〜Slot9 の Image をインスペクタで登録（最低5つ必要）
    public List<Sprite> pieceSprites; // 0〜9に対応するスプライト
    private List<int> pieceOrder;     // 選ばれた5つの番号
    int correctPiece = 0;
    public CreateManager spawnManager;

    void Start()
    {
        //SetPiece(correctPiece);
    }

    public void SetPiece()
    {
        // 正解を取得
        int RandomID = spawnManager.ReturnRandomImage();
        if (RandomID > 4)
        {
            correctPiece = RandomID - 5;
        }
        else
        {
            correctPiece = RandomID + 5;
        }

        // --- 候補を作成（0〜9） ---
            List<int> candidates = new List<int>();
        for (int i = 0; i < pieceSprites.Count; i++)
            candidates.Add(i);

        // --- 正解を強制的に入れる ---
        pieceOrder = new List<int>();
        pieceOrder.Add(correctPiece);

        // --- 正解を候補から削除 ---
        candidates.Remove(correctPiece);

        // --- 残りからランダムに4つ選ぶ ---
        for (int i = 0; i < 4; i++)
        {
            int randIndex = Random.Range(0, candidates.Count);
            pieceOrder.Add(candidates[randIndex]);
            candidates.RemoveAt(randIndex);
        }

        // --- 5つをシャッフル（表示位置をランダム化） ---
        Shuffle(pieceOrder);

        // --- スロットに割り当て ---
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < pieceOrder.Count)
            {
                int id = pieceOrder[i];
                slots[i].sprite = pieceSprites[id];
                slots[i].gameObject.SetActive(true);

                // DragPieceにIDを渡す
                DragPiece drag = slots[i].GetComponent<DragPiece>();
                if (drag != null)
                {
                    drag.pieceID = id;
                }
            }
            else
            {
                // 余分なスロットは非表示
                slots[i].gameObject.SetActive(false);
            }
        }
    }

    // シャッフル関数
    void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(0, list.Count);
            int temp = list[i];
            list[i] = list[rand];
            list[rand] = temp;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PieceManager : MonoBehaviour
{
    public List<Image> slots;        // Slot0〜Slot9 の Image をインスペクタで登録
    public List<Sprite> pieceSprites; // 0〜9に対応するスプライト
    private int[] pieceOrder;         // シャッフルされた順番

    public ImageCheck ImageCheck;

    

    void Start()
    {
        // 0〜9の配列を作成
        pieceOrder = new int[10];
        for (int i = 0; i < 10; i++)
            pieceOrder[i] = i;

        // 配列をシャッフル
        Shuffle(pieceOrder);

        // スロットにスプライトを割り当て
        for (int i = 0; i < slots.Count; i++)
        {
            int id = pieceOrder[i];
            slots[i].sprite = pieceSprites[id];

            // DragPieceにIDを渡す
            DragPiece drag = slots[i].GetComponent<DragPiece>();
            if (drag != null)
            {
                drag.pieceID = id;
                
            }
        }
    }

    // シャッフル関数
    void Shuffle(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int rand = Random.Range(0, array.Length);
            int temp = array[i];
            array[i] = array[rand];
            array[rand] = temp;
        }
    }

}

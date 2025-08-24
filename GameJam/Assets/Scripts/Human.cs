using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private float distance = 0.01f; // 検知する距離
    private string myTag;

    void Start()
    {
        // 自身のタグ取得
        myTag = gameObject.tag;
    }

    void Update()
    {
        // 同じタグを持つオブジェクトを全部取得
        GameObject[] objs = GameObject.FindGameObjectsWithTag(myTag);

        foreach (var obj in objs)
        {
            // 自分自身はスキップ
            if (obj == this.gameObject) continue;

            float dist = Vector3.Distance(transform.position, obj.transform.position);

            // 自身と同じタグを持つオブジェクトが指定した距離内にある場合
            if (dist <= distance)
            {
                Debug.Log($"一致！{obj.name} 距離: {dist}");
            }
        }
    }
}

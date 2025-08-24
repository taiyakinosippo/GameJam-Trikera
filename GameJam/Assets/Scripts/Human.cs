using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private float distance = 0.01f; // ���m���鋗��
    private string myTag;

    void Start()
    {
        // ���g�̃^�O�擾
        myTag = gameObject.tag;
    }

    void Update()
    {
        // �����^�O�����I�u�W�F�N�g��S���擾
        GameObject[] objs = GameObject.FindGameObjectsWithTag(myTag);

        foreach (var obj in objs)
        {
            // �������g�̓X�L�b�v
            if (obj == this.gameObject) continue;

            float dist = Vector3.Distance(transform.position, obj.transform.position);

            // ���g�Ɠ����^�O�����I�u�W�F�N�g���w�肵���������ɂ���ꍇ
            if (dist <= distance)
            {
                Debug.Log($"��v�I{obj.name} ����: {dist}");
            }
        }
    }
}

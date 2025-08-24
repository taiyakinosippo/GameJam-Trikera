using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ImageCheck : MonoBehaviour
{
    // ���̉摜�̔ԍ�
    public int LeftNo;
    // �E�̉摜�̔ԍ�
    public int RightNo;
    // �摜���w��̑g�ݍ��킹������
    private bool is_same;
    // �A�������J�E���g�ϐ�
    public int continuity;

    // �R���{�Ɋւ���X�N���v�g
    public ComboManager ComboManager;

    // �X�R�A�Ɋւ���X�N���v�g
    public test test;

    public LifeManager2 LifeManager2;
    public CenterImage centerImage;

    [SerializeField] private AudioSource correct;

    public void Continuous()
    {
        if(!GameManager.instance.end)
        {
            // �w��̑g�ݍ��킹�Ȃ�true
            if (RightNo == 0 && LeftNo == 5 || RightNo == 1 && LeftNo == 6 ||
               RightNo == 2 && LeftNo == 7 || RightNo == 3 && LeftNo == 8 ||
               RightNo == 4 && LeftNo == 9 || RightNo == 5 && LeftNo == 0 ||
               RightNo == 6 && LeftNo == 1 || RightNo == 7 && LeftNo == 2 ||
               RightNo == 8 && LeftNo == 3 || RightNo == 9 && LeftNo == 4)
            {
                Debug.Log("�����I");
                Debug.Log($"�R�����:{continuity}");
                continuity++;
                ComboManager.AddCombo();
                test.SaveTest();
                correct.Play();
                centerImage.CorrectImage();
            }
            else
            {
                Debug.Log("���s�I");
                Debug.Log("�R���{��0�ɂȂ�܂���");
                ComboManager.ResetCombo();
                LifeManager2.LifeDown();
                centerImage.MissImage();
            }
        }
    }

    public void LeftImageNo(int i)
    {
        LeftNo = i;
    }
    public void RightImageNo(int i)
    {
        RightNo = i;
    }
}

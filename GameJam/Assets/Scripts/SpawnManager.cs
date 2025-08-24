using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CreateManager : MonoBehaviour
{
    [SerializeField] public Image[] peacePrefabs;  // ��������v���n�u
    [SerializeField] private Transform canvas;      // ������̃L�����o�X
    [SerializeField] private Vector3 spawnPoints; // �����ʒu
    [SerializeField] private int SpwanFrame;        // �����Ԋu
    private int spawnTimer = 0;                     // �����p�^�C�}�[

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

        // �R���{���20
        int effectiveCombo = Mathf.Min(combo, 20);

        spawnTimer++;

        // �����Ԋu���R���{�ɉ����ĒZ�k�i�ŏ�10�t���[���j
        int interval = Mathf.Max(10, SpwanFrame - effectiveCombo * 20);

        if (spawnTimer >= interval)
        {
            ShowImage();
        }
    }


    void ShowImage()
    {
        // �^�C�}�[���Z�b�g
        spawnTimer = 0;
        // �����_���ȃv���n�u�𐶐�
        RandomImage = Random.Range(0, peacePrefabs.Length);
        pieceManager2.SetPiece();
        Image image = Instantiate(peacePrefabs[RandomImage], canvas);
        ImageCheck.LeftImageNo(RandomImage); // �����_���Ŏ擾�����摜�ԍ��𐳌딻��̃X�N���v�g�ɓn��
        SetZone.RightImageTransForm(image); // ���W��n��
                                            // Image�𔽓]������
        Vector3 scale = image.rectTransform.localScale;
        image.rectTransform.localScale = new Vector3(-scale.x, scale.y, scale.z);
        // �����ʒu��ݒ�
        image.transform.localPosition = spawnPoints;
    }

    public int ReturnRandomImage()
    {
        return RandomImage;
    }
}

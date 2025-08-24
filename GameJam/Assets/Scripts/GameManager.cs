using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // �C���X�^���X
    public static GameManager instance;
    [SerializeField] private GameObject banner;
    [SerializeField] private Image bannerFrame;
    [SerializeField] private TMP_Text resultScore;
    [SerializeField] private Button backTitle;
    [SerializeField] private Button retry;
    private int score;
    public bool end = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject); 
    }

    void Start()
    {
        // ������
        banner.GetComponent<Image>().enabled = false;
        bannerFrame.enabled = false;
        resultScore.enabled = false;
        backTitle.gameObject.SetActive(false);
        retry.gameObject.SetActive(false);

        // �{�^���̃C�x���g�ݒ�
        backTitle.onClick.AddListener(() => SceneManager.LoadScene("TitleScene"));
        retry.onClick.AddListener(() => SceneManager.LoadScene("GameScene"));
    }

    void Update()
    {
        // ���ꖋ�̃X�N���[�����I��������A���ʃX�R�A��\��
        if (banner.GetComponent<BannerScroll>().EndScroll)
        {
            resultScore.enabled = true;
            backTitle.gameObject.SetActive(true);
            retry.gameObject.SetActive(true);
        }
    }

    public void EndGame()
    {
        end = true;

        banner.GetComponent<Image>().enabled = true;
        bannerFrame.enabled = true;
        banner.GetComponent<BannerScroll>().StartScrolling();

        // �X�R�A���擾
        score = test.instance.nowscore;
        // �ŏI�X�R�A��ۑ�
        resultScore.text = $"{score}"; 
    }
}
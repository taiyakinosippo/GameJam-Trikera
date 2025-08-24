using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerScroll : MonoBehaviour
{
    [SerializeField] AudioSource bannerDown;
    [SerializeField] float scrollSpeed;
    private bool isScrolling = false;
    private float goalHeight = 340f;
    public bool EndScroll = false; // �X�N���[���I���t���O

    void Start()
    {
    }

    void Update()
    {
        if (isScrolling)
        {
            if (transform.position.y >= goalHeight)
            {
                transform.Translate(Vector3.up * Time.deltaTime * scrollSpeed * -1);
            }
            else
            {
                isScrolling = false; // �X�N���[���I��
                EndScroll = true; // �X�N���[���I���t���O�𗧂Ă�
            }
        }
    }

    public void StartScrolling()
    {
        isScrolling = true;
        bannerDown.Play();
    }
}
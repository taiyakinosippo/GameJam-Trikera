using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerScroll : MonoBehaviour
{
    [SerializeField] AudioSource bannerDown;
    [SerializeField] float scrollSpeed;
    private bool isScrolling = false;
    private float goalHeight = 340f;
    public bool EndScroll = false; // スクロール終了フラグ

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
                isScrolling = false; // スクロール終了
                EndScroll = true; // スクロール終了フラグを立てる
            }
        }
    }

    public void StartScrolling()
    {
        isScrolling = true;
        bannerDown.Play();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField] private Image[] tutorialImage;
    [SerializeField] private int tutorialNum = 0;
    [SerializeField] private Button next;
    private bool isTutorial = false;

    void Start()
    {
        next.onClick.AddListener(NextPage);
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    // チュートリアルボタンが押されたら
    public void Tutorial()
    {
        isTutorial = true;
        tutorialImage[tutorialNum].enabled = true;
        next.gameObject.SetActive(true);
    }

    private void NextPage()
    {
        if (isTutorial && tutorialNum < tutorialImage.Length - 1)
        {
            tutorialNum++;
            tutorialImage[tutorialNum - 1].enabled = false;
            tutorialImage[tutorialNum].enabled = true;
        }
        else if (isTutorial && tutorialNum == tutorialImage.Length - 1)
        {
            isTutorial = false;
            tutorialImage[tutorialNum].enabled = false;
            tutorialNum = 0;
            next.gameObject.SetActive(false);
        }
    }
}

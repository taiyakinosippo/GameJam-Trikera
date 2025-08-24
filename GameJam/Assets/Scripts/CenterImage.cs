using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CenterImage : MonoBehaviour
{
    public Image slot;
    public List<Sprite> lifeSprites;

    public void CorrectImage(int i)
    {
        Color color = slot.color;
        color.a = Mathf.Clamp01(1); // 0〜1に制限
        i = i % 5;
        slot.sprite = lifeSprites[i];
    }

    public void MissImage()
    {
        slot.sprite = lifeSprites[5];
    }
}

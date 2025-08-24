using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CenterImage : MonoBehaviour
{
    public Image slot;
    public List<Sprite> lifeSprites;

    public void CorrectImage()
    {
        slot.sprite = lifeSprites[0];
    }

    public void MissImage()
    {
        slot.sprite = lifeSprites[1];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public Image Life1;
    public Image Life2;
    public Image Life3;

    [SerializeField] int LifeCount = 0;
    [SerializeField] AudioSource lifeDown;

    public void LifeDown()
    {
        LifeCount++;
        switch (LifeCount)
        {
            case 1: 
                Life3.enabled = false;
                lifeDown.Play();    
                break;
            case 2: 
                Life2.enabled = false;
                lifeDown.Play();
                break;
            case 3: 
                Life1.enabled = false;
                GameManager.instance.EndGame(); // ƒQ[ƒ€I—¹ˆ—‚ğŒÄ‚Ño‚·
                break;
        }
    }
}

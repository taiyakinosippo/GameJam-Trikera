using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LifeManager2 : MonoBehaviour
{
    public int Life = 3;
    public Image slot;
    public List<Sprite> lifeSprites;
    [SerializeField] AudioSource incorrect;

    public GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        slot.sprite = lifeSprites[Life];
    }

    public void LifeDown()
    {
        --Life;
        incorrect.Play();
        if (Life <= 0)
        {
            GameManager.instance.EndGame();
            GameManager.EndGame();
        }
    }
}

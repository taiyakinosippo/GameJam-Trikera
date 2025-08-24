using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class test : MonoBehaviour
{
    public static test instance;
    public int currentScore = 0;
    public ComboManager comboManager; // コンボのスクリプト
    public TMP_Text scoreText;   
    int combo;
    public int nowscore;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        nowscore = 0;
        scoreText.text = ($"{nowscore}");
    }

    // Update is called once per frame
    void Update()
    {
        combo = comboManager.GetComboCount();
        
    }

    public void SaveTest()
    {
        //ScoreManager.SaveScore(combo*1000);
        nowscore += 1000 + combo * 100;
        scoreText.text = ($"{nowscore}");
        Debug.Log($"{nowscore}");
    }

    public void RankTest()
    {
        ScoreData data = ScoreManager.LoadScores();
        foreach (int score in data.scores)
        {
            
            Debug.Log(score);  // UIに表示してOK
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Animator animGameOver;
    public int score = 0;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI bestScore;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        textScore.text = score.ToString();

        bestScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        animGameOver.updateMode = AnimatorUpdateMode.UnscaledTime;

        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void AddPoint()
    {
        score++;
        textScore.text = score.ToString();
        UpdtateBestScore();
    } 
    void UpdtateBestScore()
    {
        if ( score > PlayerPrefs.GetInt("HighScore") )
        {
            PlayerPrefs.SetInt("HighScore", score);
            bestScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }
}

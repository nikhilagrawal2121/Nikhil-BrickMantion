using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score = 0; //Use to calculate score
    public int Lives = 3; // use for life
    public int Coin = 0; //Use to calculate score
    public string nextLevel = "level2";
    public int LevelToUnlock = 2;

    //public SceneFader Fader;

    public int Level= 2;
    public Ball ball; //Refrance to the ball  to acess the function
    public Paddle paddle; //refrance to the paddlee to acess the function
    public Brick[] bricks;
    public GameObject LevelCompleteUI;
    public GameObject GameOverUI;
    public Moment moment;
    public Text scoreText;
    public Text LivesText;
    public Text CoinText;
    public void Awake() // when we start game this method exicute
    {

     
        SceneManager.sceneLoaded += onLevelLoded;
     
    }


    void Start()
    {
        NewGame(); // Start game load this method
        AdManager.instance.RequestInterstitial(); // acess the admanager script to show the interstitial ad when game over
        Coin = PlayerPrefs.GetInt("Coin1");
        CoinText.text = "Coins " + Coin.ToString();
    }

    private void LoadLevel(int level) // Method to load the level
    {
        this.Level = level;


        //SceneManager.LoadScene(2);
    }


    private void NewGame()
    {
        this.score = 0; //Set the score to 0
        this.Lives = 3; //Set lives to 3
        this.Coin = 0; //Set the score to 0

        LoadLevel(2);
    }

 

    public void Hit(Brick brick)
    {
        scoreText.text = "Score " + score.ToString();
        this.score += brick.points; // Updating the score

        if(Cleared())
        {
            Coin = PlayerPrefs.GetInt("Coin1");
            Coin = Coin + 1;
            PlayerPrefs.SetInt("Coin1", Coin);
            CoinText.text = "Coins :" + Coin;

            
            LoadLevel(this.Level + 1);
            
        }
    }

    private bool Cleared()
    {
        for(int i = 0; i< this.bricks.Length; i++)
        {
            if(this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unBreakable) // check that brick is active or not
                                                            // if all brick is inactive then its load new level
            {
                return false;
            }
        }
        Coin = PlayerPrefs.GetInt("Coin1");
        CoinText.text = "Coins " + Coin.ToString();
        Coin = Coin + 100;
        PlayerPrefs.SetInt("Coin1", Coin);
        //CoinText.text = "Coins :" + Coin;
        LevelCompleteUI.SetActive(true);
        WinLevel();
        Time.timeScale = 0;
        return true;
        

    }


    private void onLevelLoded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
        this.moment = FindObjectOfType<Moment>();
        this.bricks = FindObjectsOfType<Brick>();
    }
 


    private void ResetLevel()
    {
        this.ball.ResetBall(); // Reset state of paddle
        this.moment.ResetPaddle(); // Reset state of paddle
        
    }

  private void GameOver()

    {
        
        GameOverUI.SetActive(true);
        Time.timeScale = 0; // Process Resume
        AdManager.instance.showInterstitial(); //display interstitial ad
       
    }


    public void Miss()
    {
        

        this.Lives--; // if ball miss the paddle lives is - by one
        LivesText.text = "Lives " + Lives.ToString();
        if (this.Lives > 0) // if lives is not equal to zero

        {
            ResetLevel(); // call fuction ResetLevel
        }

        else
        {
            GameOver(); // call fuction Gameover
        }
    }



    public void Restrat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // to restart actve level
        Time.timeScale = 1; // Process Resume

    }

    public void MainMenu(int level)
    {
        Time.timeScale = 1f;
        Application.LoadLevel(1); //Load the scene we want

    }

    public void WinLevel()
    {
        PlayerPrefs.SetInt("LevelReached", LevelToUnlock);

    }

}

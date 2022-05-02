using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader; //Refrance to scene
    public Button[] LevelButtons;

    private void Start()
    {
     
        int LevelReached = PlayerPrefs.GetInt("LevelReached",1); //used to find which is our current level is we have not play any level then it will be start of game
                                                                 // if we are new to game it only allows u to play first level
        for (int i = 0; i < LevelButtons.Length; i++) //read number of buttons
        {
            if(i+1 > LevelReached) // if levelreched value is less then i 
            LevelButtons[i].interactable = false; // when we click nothing will be happened 
                                                  //we cannot play that level

         
        }
             
    }
    public void Select(string LavelName)
    {

        fader.FadeTo(LavelName);
    }
}

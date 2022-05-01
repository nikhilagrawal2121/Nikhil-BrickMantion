using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    //[SerializeField] MenuButtonController menuButtonController;
    //[SerializeField] Animator animator;
    //[SerializeField] AnimatorFunctions animatorFunctions;
    //[SerializeField] int thisIndex;

    public void PlayGames()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Build indesx is for the finding sequance of scene and +1 for increment by 1
        


    }

    public void QuitGame()
    {
        Application.Quit();
    }



    public void Shop()
    {
        SceneManager.LoadScene("ShopSystem");

    }
    //void Update()
    //{
    //    if (menuButtonController.index == thisIndex)
    //    {
    //        animator.SetBool("selected", true);
    //        if (Input.GetAxis("Submit") == 1)
    //        {
    //            animator.SetBool("pressed", true);
    //        }
    //        else if (animator.GetBool("pressed"))
    //        {
    //            animator.SetBool("pressed", false);
    //            animatorFunctions.disableOnce = true;
    //        }
    //    }
    //    else
    //    {
    //        animator.SetBool("selected", false);
    //    }
    //}


}

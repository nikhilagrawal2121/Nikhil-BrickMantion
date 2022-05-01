using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Display : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 10;
    public string NewLevel = "MainMenu";
    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
        
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
      
        SceneManager.LoadScene(NewLevel);
    }



}

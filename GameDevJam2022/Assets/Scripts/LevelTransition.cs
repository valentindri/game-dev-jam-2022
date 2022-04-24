using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private int lastLevel = 5;
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void WinGame()
    {
        //Win the game
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(SceneManager.GetActiveScene().buildIndex == lastLevel) 
            {
                WinGame();
            }
            else{
                NextLevel();
            }
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public void SimpleBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    //code to launch the back titration scene
    public void BackBtn()
    {
        SceneManager.LoadScene("BackTitration");
    }


    //launches the mainmenu 
    public void MainMenu()
    {
        SceneManager.LoadScene("start menu");
    }

    //code to restart the Main Menu scene
    public void RestartMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    //restarts the Backtitration scene
    public void RestartBackTitrationScene()
    {
        SceneManager.LoadScene("BackTitration");
    }
}

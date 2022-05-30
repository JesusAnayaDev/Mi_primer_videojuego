using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarJuego : MonoBehaviour
{
    public void LoadGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
    public void LoadLevels(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Levels");
    }
}

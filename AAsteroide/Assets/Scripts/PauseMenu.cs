using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton, pauseMenu;
    public void Pausa(){
        Time.timeScale = 0f; //se detiene el juego
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Reanudar(){
        Time.timeScale = 1f; //se reanuda el juego
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    void Start(){}

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeSelf){
            Pausa();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf){
            Reanudar();
        }
    }
}

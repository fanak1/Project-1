using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private GameManager gm;

    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    public void LoadButton() {
        gm.LoadData();
        gm.OpenGameScreen();
    }

    public void PlayButton() {
        gm.NewGame();
        gm.OpenGameScreen();
    }

    public void QuitButton() {
        gm.QuitGame();
    }
}

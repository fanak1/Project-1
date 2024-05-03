using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveLevel() {
        gm.SaveLevel();
    }

    public void DontSaveLevel() {
        gm.DontSaveLevel();
    }

    public void SaveData() {
        gm.SaveData();
    }

    public void LoadData() {
        gm.LoadData();
    }

    public void QuitRestScreen() {
        gm.OpenGameScreen();
    }

    public void QuitMainMenu() {
        gm.OpenMainMenu();
    }

    
}

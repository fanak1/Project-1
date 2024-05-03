using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private float expD;

    public Vector2 lastCheckPointPos;
    public int hp = 10;
    public int mp = 10;
    public int spd = 10;
    public int aspd = 10;
    public int intel = 10;

    public int level = 1;
    public int tempLevel;
    public int exp = 30000;
    public int expNow;
    public int expDisplay;
    public int tempExp;
    public bool die = false;

    public bool loadNewScene = false;
    public string scene;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        tempLevel = level;
        tempExp = exp;
        expDisplay = exp;
        expNow = exp;
    }

    private void Update() {
        if(expDisplay < exp) {
            expD += 60 * Time.deltaTime;
            expDisplay = (int)expD;
        } else if(expDisplay > exp) {
            expDisplay = exp;
            expD = expDisplay;
        }
    }

    // Update is called once per frame

    public void OpenRestScreen() {
        //SceneManager.LoadScene("RestScreen");
        scene = "RestScreen";
        expDisplay = exp;
        expD = expDisplay;
        tempExp = exp;
        tempLevel = level;
        loadNewScene = true;
    }

    public void OpenGameScreen() {
        //SceneManager.LoadScene("GameScreen");
        scene = "GameScreen";
        expDisplay = exp;
        expD = expDisplay;
        tempExp = exp;
        tempLevel = level;
        loadNewScene = true;  
    }

    public void OpenMainMenu() {
        scene = "MainMenu";
        expDisplay = exp;
        expD = expDisplay;
        tempExp = exp;
        tempLevel = level;
        loadNewScene = true;
    }

    public void QuitGame() {
        Application.Quit();
    }

    public int ExpRequire(int l) {
        float b = l / 2.0f;
        int e = (int)(((b + Mathf.Sin(b + 10) - Mathf.Sin(10)) * 25) + 100 + (l * l));
        return e;
    }

    public bool IncreaseLevel() {
        if(tempExp >= ExpRequire(tempLevel)) {
            tempExp -= ExpRequire(tempLevel);
            tempLevel++;
            return true;
        } else {
            return false;
        }
    }

    public bool DecreaseLevel() {
        if(tempLevel > level) {
            tempExp += ExpRequire(tempLevel - 1);
            tempLevel--;
            return true;
        } else {
            return false;
        }
    }

    public void SaveLevel() {
        level = tempLevel;
        exp = tempExp;
    }

    public void DontSaveLevel() {
        tempLevel = level;
        tempExp = exp;
    }

    public void SaveData() {
        SaveSystem.SaveData(this);
    }

    public void LoadData() {
        GameData data = SaveSystem.LoadData();

        level = data.level;
        exp = data.exp;
        hp = data.hp;
        mp = data.mp;
        spd = data.spd;
        aspd = data.aspd;
        intel = data.intel;

        tempExp = exp;
        tempLevel = level;

        lastCheckPointPos = new Vector2(data.position[0], data.position[1]);

    }

    public void NewGame() {
        level = 1;
        exp = 0;
        hp = 10;
        mp = 10;
        spd = 10;
        aspd = 10;
        intel = 10;

        tempExp = exp;
        tempLevel = level;
        die = false;

        lastCheckPointPos = new Vector2(0, 5);
    }

}

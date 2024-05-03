using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stat : MonoBehaviour {



    private GameManager gm;
    private TextMeshProUGUI tm;

    private const int HP = 0;
    private const int MP = 1;
    private const int SPD = 2;
    private const int ASPD = 3;
    private const int INTEL = 4;
    private int value;
    private int tempValue;

    public int STAT_TYPE;


    // Start is called before the first frame update
    void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        tm = gameObject.GetComponent<TextMeshProUGUI>();
        

        switch (STAT_TYPE) {
            case HP: {
                    value = gm.hp;
                    tempValue = gm.hp;
                    SetText("" + gm.hp);
                    break;
                }
            case MP: {
                    value = gm.mp;
                    tempValue = gm.mp;
                    SetText("" + gm.mp);
                    break;
                }
            case SPD: {
                    value = gm.spd;
                    tempValue = gm.spd;
                    SetText("" + gm.spd);
                    break;
                }
            case ASPD: {
                    value = gm.aspd;
                    tempValue = gm.aspd;
                    SetText("" + gm.aspd);
                    break;
                }
            case INTEL: {
                    value = gm.intel;
                    tempValue = gm.intel;
                    SetText("" + gm.intel);
                    break;
                }

        }
    }

    // Update is called once per frame
    void Update() {

    }

    void SetText(string s) {
        tm.SetText(s);
    }

    public void TemporaryIncreaseValue() {
        if (gm.IncreaseLevel()) {
            tempValue++;
            tm.SetText(tempValue.ToString());
        }
    }

    public void TemporaryDecreaseValue() {
        if (tempValue > value) {
            gm.DecreaseLevel();
            tempValue--;
            tm.SetText(tempValue.ToString());
        }
    }

    public void SaveValueDisplay() {
        switch (STAT_TYPE) {
            case HP: {
                    gm.hp = tempValue;
                    value = gm.hp;
                    SetText("" + gm.hp);
                    break;
                }
            case MP: {
                    gm.mp = tempValue;
                    value = gm.mp;
                    SetText("" + gm.mp);
                    break;
                }
            case SPD: {
                    gm.spd = tempValue;
                    value = gm.spd;
                    SetText("" + gm.spd);
                    break;
                }
            case ASPD: {
                    gm.aspd = tempValue;
                    value = gm.aspd;
                    SetText("" + gm.aspd);
                    break;
                }
            case INTEL: {
                    gm.intel = tempValue;
                    value = gm.intel;
                    SetText("" + gm.intel);
                    break;
                }

        }
    }

    public void DontSaveValueDisplay() {
        SetText(value.ToString());
        tempValue = value;
    }

}

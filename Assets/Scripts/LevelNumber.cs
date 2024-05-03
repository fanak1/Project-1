using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelNumber : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI tm;
    private GameManager gm;
    void Start()
    {
        tm = GetComponent<TextMeshProUGUI>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        tm.SetText("" + gm.level);
    }

    // Update is called once per frame
    void Update()
    {
        tm.SetText(gm.tempLevel.ToString());
    }

    public void TemporaryIncreaseLevel() {
        gm.tempLevel++;
        tm.SetText(gm.tempLevel.ToString());
    }

    public void TemporaryDecreaseLevel() {
        if(gm.tempLevel > gm.level) {
            gm.tempLevel--;
            tm.SetText(gm.tempLevel.ToString());
        }
    }
}

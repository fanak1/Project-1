using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExpGain : MonoBehaviour
{
    private GameManager gm;
    private bool enable = false;
    private TextMeshProUGUI tm;
    private float time = 0f;

    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        tm = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        if(gm.expDisplay < gm.exp) {
            tm.SetText("+" + (gm.exp - gm.expNow));
        } else {
            time += Time.deltaTime;
            if(time > 2) {
                tm.SetText("");
                gm.expNow = gm.exp;
                time = 0;
            }
            
        }
    }
}

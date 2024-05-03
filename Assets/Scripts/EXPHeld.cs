using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EXPHeld : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI tm;
    private GameManager gm;
    void Start()
    {
        tm = GetComponent<TextMeshProUGUI>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        tm.SetText("" + gm.exp);
    }

    // Update is called once per frame
    void Update()
    {
        tm.SetText(gm.tempExp.ToString());
    }

    
}

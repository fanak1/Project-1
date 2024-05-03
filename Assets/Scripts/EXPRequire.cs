using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EXPRequire : MonoBehaviour
{
    private TextMeshProUGUI tm;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMeshProUGUI>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        tm.SetText(gm.ExpRequire(gm.level).ToString());
    }

    // Update is called once per frame
    void Update()
    {
        tm.SetText(gm.ExpRequire(gm.tempLevel).ToString());
    }
}

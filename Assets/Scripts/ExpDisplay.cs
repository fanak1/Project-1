using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExpDisplay : MonoBehaviour
{
    private GameManager gm;
    private TextMeshProUGUI tm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        tm = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tm.SetText(gm.expDisplay.ToString());
    }
}

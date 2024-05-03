using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SavePoint : MonoBehaviour
{
    public GameObject canvas;
    
    private GameManager gm;
    private bool isIn = false;
    public CinemachineVirtualCamera transitionCamera;
    // Start is called before the first frame update
    void Start() {
        canvas.SetActive(false);
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isIn) {
            if (Input.GetKeyDown(KeyCode.E)) {
                gm.lastCheckPointPos = transform.position;
                transitionCamera.Priority = 11;

                gm.OpenRestScreen();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            canvas.SetActive(true);
            isIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            canvas.SetActive(false);
            isIn = false;
        }
    }
}

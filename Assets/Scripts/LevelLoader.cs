using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {

    public Animator transition;
    private GameManager gm;

    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

    }

    private void Update() {
        if (gm.loadNewScene) {
            StartCoroutine(TransitionToScene(gm.scene));
            gm.loadNewScene = false;
        } else if (gm.die) {
            gm.die = false;
            StartCoroutine(DieScreen());
        }
    }

    public IEnumerator TransitionToScene(string scene) {

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(scene);
    }

    public IEnumerator DieScreen() {
        transition.SetTrigger("Die");

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("MainMenu");
    }
}

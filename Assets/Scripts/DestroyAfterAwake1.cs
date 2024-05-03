using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAwake1 : MonoBehaviour {

    private float time;
    // Start is called before the first frame update
    void Start() {
        
    }

    private void Update() {
        time += Time.deltaTime;
        if(time > 1) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
}

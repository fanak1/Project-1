using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnMob : MonoBehaviour
{
    public int numberOfMobs;
    public GameObject mobs;

    private Vector3 spawnOffset = new Vector3(50, 5, 0);
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            for(int i =0; i< numberOfMobs;i++) {
                
                Instantiate(mobs, transform.position + spawnOffset + Vector3.up * 2 * i + Vector3.right * i , transform.rotation);
            }
            Destroy(gameObject);
        }
        
    }
}

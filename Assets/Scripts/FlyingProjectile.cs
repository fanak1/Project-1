using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 20f;
    public GameObject bloomEffect;
    private SpriteRenderer sr;
    private bool hit = false;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (gameObject.CompareTag("pProjectile")) {
            if (collision.gameObject.CompareTag("enemy")) {
                speed = 0;
                Instantiate(bloomEffect,  transform.position, Quaternion.identity);
                EnemyStatus enemyScript = collision.gameObject.GetComponent<EnemyStatus>();
                if (!hit) {
                    hit = true;
                    enemyScript.hitDamage(damage);
                }
                Destroy(gameObject);
            }
            else if (!collision.gameObject.CompareTag("player") && !collision.gameObject.CompareTag("pProjectile")) {
                Instantiate(bloomEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else if (gameObject.CompareTag("eProjectile")) {
            if (collision.gameObject.CompareTag("player")) {
                PlayerStatus playerScript = collision.gameObject.GetComponent<PlayerStatus>();
                playerScript.hitDamage(damage);
                Destroy(gameObject);
            } else {
                if (!collision.gameObject.CompareTag("enemy") && !collision.gameObject.CompareTag("eProjectile")) {
                    Destroy(gameObject);
                }
            } 
        }
        
       
    }

    public void SetDamage(float number) {
        damage = number;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public GameObject health;
    private HealthBar healthBar;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = health.GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.health <= 0f) isDead = true;
    }

    public void hitDamage(float damage) {
        healthBar.takeDamage(damage);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public float maxHealth = 300f;
    public float health;
    public GameObject healthBar;
    public GameObject easeHealthBar;

    private Slider healthSlider;
    private Slider easeHealthSlider;
    private float lerpSpeed = 0.05f;
    private float timeDelayEaseHealth = 0f;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider = healthBar.GetComponent<Slider>();
        easeHealthSlider = easeHealthBar.GetComponent<Slider>();

        float scale = ((maxHealth - 300) / 300);

        healthBar.transform.localScale += Vector3.right * scale;
        easeHealthBar.transform.localScale += Vector3.right * scale;

        health = maxHealth;

        healthSlider.maxValue = maxHealth;
        easeHealthSlider.maxValue = maxHealth;

        healthSlider.value = maxHealth;
        easeHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthSlider.value != health) {
            healthSlider.value = health;
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            takeDamage(10);
        }
        if (healthSlider.value != easeHealthSlider.value) {
            if (timeDelayEaseHealth < 0.5f) timeDelayEaseHealth += Time.deltaTime;
            else {
                if (easeHealthSlider.value > healthSlider.value) easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, healthSlider.value, lerpSpeed);
                else easeHealthSlider.value = healthSlider.value;
            }
        }
    }

    public void takeDamage(float damage) {
        health -= damage;
        timeDelayEaseHealth = 0f;
    }

    public void increaseMaxHealth(float health) {
        healthBar.transform.localScale += Vector3.right * (health / 300);
        easeHealthBar.transform.localScale += Vector3.right * (health / 300);
        maxHealth += health;
        healthSlider.maxValue = maxHealth;
        easeHealthSlider.maxValue = maxHealth;
    }
}

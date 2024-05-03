using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using System;

public class PlayerStatus : MonoBehaviour
{
    public HealthBar healthBar;
    public ManaBar manaBar;

    private Animator playerAnimator;
    private PlayerMovement playerMovement;
    private ShootingProjectile shooting;
    private GameManager gm;

    [SerializeField] private float maxHealth;
    [SerializeField] private float maxMana;

    [SerializeField] private int hp;
    [SerializeField] private int mp;
    [SerializeField] private int spd;
    [SerializeField] private int aspd;
    [SerializeField] private int intel;

    private bool die = false;

    private void Awake() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        hp = gm.hp;
        mp = gm.mp;
        spd = gm.spd;
        aspd = gm.aspd;
        intel = gm.intel;

        shooting = GetComponent<ShootingProjectile>();
        playerMovement = GetComponent<PlayerMovement>();

        maxHealth = hp * 12;
        maxMana = mp * 10;
        playerMovement.spd = spd;
        shooting.aspd = aspd;
        shooting.intel = intel;

        healthBar.maxHealth = maxHealth;
        manaBar.maxMana = maxMana;

        playerAnimator = GetComponent<Animator>();

        shooting.OnShootingMagic += ShootAnimation;

        
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = gm.lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.health <= 0) {
            if (!die) {
                playerMovement.isDead = true;
                gm.die = true;
                die = true;
            }
            
            //playerAnimator.Play("Die", -1, float.NegativeInfinity);
            
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            healthBar.increaseMaxHealth(30);
        }
    }

    public void ShootAnimation(object sender, EventArgs e) {

        //playerAnimator.PlayInFixedTime("Attack", -1, 0.05f);
    }

    public void hitDamage(float damage) {
        healthBar.takeDamage(damage);
        //playerAnimator.PlayInFixedTime("Hurt", -1, 0.05f);
    }


}

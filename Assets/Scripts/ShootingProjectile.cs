using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootingProjectile : MonoBehaviour {
    private const int LINE = 0;
    private const int SPREAD = 1;
    private const int CONTINUOUS = 2;

    public int numberOfBullet;
    public int intel;

    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Vector3 offset = new Vector3(1.5f, 4, 0);

    
    private FlyingProjectile flyingProjectile;

    private Animator animator;

    public ParticleSystem magicBloom;
    public ManaBar manaBarScript;
    public float manaSpend = 50f;
    [SerializeField] private float shootSpeed = 0.2f;
    public int aspd;
    private float time = 0;
    private PlayerMovement playerMovement;
    private float shootAnimDelay = 0.5f;

    public event EventHandler OnShootingMagic;
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        flyingProjectile = projectile.GetComponent<FlyingProjectile>();
        playerMovement = GetComponent<PlayerMovement>();
        numberOfBullet = 2;
        ExchangeIntel(intel);
        ExchangeASPD(aspd);
        time = shootSpeed;
    }

    // Update is called once per frame
    void Update() {
        if(time < 100) {
            time += Time.deltaTime;
        }
        if (time > shootAnimDelay) animator.SetBool("Shoot", false);

        if (Input.GetMouseButton(0) && !playerMovement.isDead) {
            if(time >= shootSpeed) {
                if (manaBarScript.decreaseMana(manaSpend)) {

                    if (OnShootingMagic != null) {
                        OnShootingMagic(this, EventArgs.Empty);
                    }
                    magicBloom.Play();
                    animator.SetBool("Shoot", true);
                    Shoot(LINE);
                    time = 0;
                }
                
            }
            
        }
    }

    void Shoot(int type) {
        
        switch (type) {
            case LINE:
                float angle = firePoint.transform.eulerAngles.z;
                int rotate = (angle > 90 || angle < -90) ? -1 : 1;
                float sin = Mathf.Sin(angle * Mathf.Deg2Rad) ;
                float cos = Mathf.Cos(angle * Mathf.Deg2Rad) ;
                for(int i=0; i<numberOfBullet; i++) {
                    float j = i - numberOfBullet / 2;
                    Instantiate(projectile, firePoint.transform.position + new Vector3(sin * j, -cos * j, 0) + Vector3.right*rotate*2, firePoint.transform.rotation);
                }
                    
                
                break;
        }
    }

    void ExchangeIntel(int intel) {
        float damage = 15 + Mathf.Sqrt(intel * 100);
        flyingProjectile.SetDamage(damage);
        numberOfBullet = 1 + (numberOfBullet / 15);
    }

    void ExchangeASPD(int aspd) {
        shootSpeed = 1 - Mathf.Sqrt(aspd/100);
    }
}



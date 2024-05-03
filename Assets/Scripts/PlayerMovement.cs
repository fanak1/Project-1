using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private GameObject body;
    [SerializeField] private float intervals = 0.2f;
    public ParticleSystem dust;
    private float time = 0;
    private Rigidbody2D playerRb;
    private bool jump = false;
    private bool jump1 = false;
    private bool particlePlay = false;
    private float move;

    public int spd;

    public bool isDead = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start() {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        ExchangeSPD(spd);
    }

    // Update is called once per frame
    void Update() {
        move = Input.GetAxisRaw("Horizontal");
        if(time < intervals) {
            time += Time.deltaTime;
        }
        animator.SetFloat("Speed", Mathf.Abs(move));
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("ground")) {
            animator.SetBool("Air", false);
            jump1 = false;
            jump = false;
            spd -= 2;           
        }
    }

    void Movement() { 
        if (!isDead) {
            if(body.transform.rotation.z > 0.725f || body.transform.rotation.z < -0.725f) {
                transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            } else{
                transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
            }
            if(move != 0) {
                if(time > intervals) {
                    PlayDust();
                    time = 0;
                }
            }

            transform.position += Vector3.right * move * speed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && !jump) {
                animator.SetBool("Air", true);
                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                if (!jump) jump = true;
                spd += 2;
            }
        }
    }

    void PlayDustLeft() {
        dust.transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
    }

    void PlayDustRight() {
        dust.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
    }

    void PlayDust() {
        dust.Play();
    }

    void ExchangeSPD(int spd) {
        float s = 15 + (100 / (spd + 4));
        speed = s;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Scripts : MonoBehaviour {

    [SerializeField] private float moveSpeed = 10f;
    private GameObject player;
    public GameObject bullet;

    private GameManager gm;
    private EnemyStatus enemyStatus;
    private Vector3 offset = new Vector3(0, 3f, 0);
    private float offsetBetweenPlayer = 10f;
    private float rangeToMoveHorizontal = 30f;
    private float time = 0f;
    private float stillTime = 1f;
    private float moveTime = 2f;
    private int rad = 3;
    private bool awake = false;
    [SerializeField] private float fireRate = 2f;
    private Vector3 startPos;

    public int exp;
    // Start is called before the first frame update
    void Start() {
        startPos = transform.position;
        enemyStatus = GetComponent<EnemyStatus>();
        player = GameObject.FindGameObjectWithTag("player");
        InvokeRepeating("ShootingRandom", 2f, fireRate);
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        if (enemyStatus.isDead) {
            Destroy(gameObject);
            gm.exp += exp;
            gm.SaveData();
            gm.OpenMainMenu();
        }
        time += Time.deltaTime;
        if (!awake) {
            if (player.transform.position.x < transform.position.x)
                transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
            else transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            if (time > stillTime) awake = true;
        }
        if (time > stillTime) {
            awake = true;
            rad = 3;
            if (time > moveTime) {
                rad = Random.Range(0, 3);
                time = 0f;
            }
        }
        if (Vector2.Distance(transform.position, player.transform.position) > 50f) {
            transform.position = startPos;
        } else {
            Moving(rad);
        }

    }

    void ShootingRandom() {
        var pos = transform.position;
        var dir = player.transform.position + offset - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        Instantiate(bullet, transform.position, rot);

    }

    void Moving(int move) {
        float dis = Vector2.Distance(transform.position, player.transform.position);
        switch (move) {
            case 0:
                if (dis > offsetBetweenPlayer) {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * moveSpeed);
                }
                break;
            case 1:
                if (transform.position.x - player.transform.position.x < rangeToMoveHorizontal)
                    transform.position -= Vector3.left * moveSpeed * Time.deltaTime;
                break;

            case 2:
                if (transform.position.x - player.transform.position.x > rangeToMoveHorizontal)
                    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                break;
            case 3:
                break;
        }
    }
}
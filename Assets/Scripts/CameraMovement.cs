using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset = new Vector3(5, 7, -10);   
    public GameObject character;
    [SerializeField] private float lerpSpeed = 1f;
    [SerializeField] private float top;
    [SerializeField] private float bottom;
    [SerializeField] private float left;
    [SerializeField] private float right;

    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = character.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = character.transform.position;
    }
}

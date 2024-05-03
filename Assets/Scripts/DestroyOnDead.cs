using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDead : MonoBehaviour
{
    

    public void Kill() {
        Destroy(gameObject);
    }
}

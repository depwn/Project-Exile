using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {
    [SerializeField]
    GameObject player;
    BoxCollider playerCol;

    public void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<BoxCollider>();
    }


    void OnCollisionEnter(Collision col) {
        if (col.collider.Equals(playerCol)) {
            Destroy(this.gameObject);
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {
    [SerializeField]
    GameObject player;
    BoxCollider playerCol;
    [SerializeField]
    public InventorySO playerInventory;
    [SerializeField]
    private AudioClip lootClip;


    public void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<BoxCollider>();        
    }


    void OnCollisionEnter(Collision col) {
        if (col.collider.Equals(playerCol)) {            
            playerInventory.AddItem(GetComponent<Item>().item, GetComponent<Item>().amount);
            AudioSource.PlayClipAtPoint(lootClip, transform.position);
            Destroy(this.gameObject);
        }
    }
}

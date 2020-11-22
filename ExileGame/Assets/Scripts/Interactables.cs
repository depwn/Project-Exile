using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour {
    public float radius = 3f;
    bool isFocused = false;
    GameObject player;
    bool isInteracting = false;
    List<GameObject> interactablesInRange = new List<GameObject>();
    public GameObject poop;
    public int lootAmount = 5;
    [SerializeField]
    private Outline outline;

    public virtual void InteractAction() {
        // This method will be overwritten by the InteractAction() method in the Scriptable objects        
    }

    void Start() {
        
    }

    //Outline the interactable player is mousing over
    private void OnMouseEnter() {

        outline.enabled = !outline.enabled;
    }

    private void OnMouseExit() {

        outline.enabled = !outline.enabled;
    }

    private void OnDestroy() {        
        LootDrop(poop, lootAmount);
    }

    void LootDrop(GameObject name, int amount) {
        for (int i = 0; i < lootAmount; i++) {
            GameObject baggelis = Instantiate(name, new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y + Random.Range(-1f, 2f), transform.position.z + Random.Range(-1.5f, 1.5f)), Quaternion.identity);
            //GameObject instantiated = (GameObject)GameObject.Instantiate(name, transform.position, Quaternion.identity);
            baggelis.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-4f,4f), Random.Range(1f, 5f), Random.Range(-4f, 4f)),ForceMode.Impulse);
        }
        
    }

    //Enters the interactables player is in range with (VacuumLoot collider range) in a List called interactablesInRange
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Interactable")) {
            interactablesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Interactable")) {
            interactablesInRange.Add(other.gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour {

    public float radius = 3f;
    List<GameObject> interactablesInRange = new List<GameObject>();
    [SerializeField]
    private Outline outline;
    public int lootAmount;
    [System.Serializable]
    public class drops {
        public GameObject drop;
        public float chance;
    }

    public List<drops> lootTable = new List<drops>();

    public virtual void InteractAction() {
        // This method will be overwritten by the InteractAction() method in the Scriptable objects        
    }

    void Start() {

    }
        
    public void GenerateLoot(List<drops> lootTable, int lootAmount) {
        List<GameObject> drops = new List<GameObject>();
        //foreach(drops drop in lootTable) {
        for (int i = 0; i < lootAmount; i++) {
            float RNG = Random.Range(0.0f, 100.0f);
            Debug.Log("Rolled: " + RNG);
            foreach (drops item in lootTable) {
                if (item.chance > RNG) {
                    LootDrop(item.drop);
                }
                else {
                    Debug.Log("Did not spawn Dwayne 'The Rock' Johnson!");
                }
            }
        }        
    }

    //Spawn Loot Drops
    void LootDrop(GameObject drop) {

        GameObject baggelis = Instantiate(drop, new Vector3(transform.position.x + Random.Range(-0.5f, 1.5f), transform.position.y + Random.Range(0f, 1f), transform.position.z + Random.Range(-1.5f, 1.5f)), Quaternion.identity);
        //GameObject instantiated = (GameObject)GameObject.Instantiate(name, transform.position, Quaternion.identity);
        baggelis.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-4f, 4f), Random.Range(2f, 4f), Random.Range(-4f, 4f)), ForceMode.Impulse);


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

    //Outline on Mouseover
    private void OnMouseEnter() {
        outline.enabled = !outline.enabled;
    }

    private void OnMouseExit() {
        outline.enabled = !outline.enabled;
    }

    //Loot Drop on Destroy
    private void OnDestroy() {
        GenerateLoot(lootTable, lootAmount);
    }


}

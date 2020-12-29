using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public InventorySO playerInventory;
    public void OnReloadSceneButton()
    {
        SceneManager.LoadScene("Main Game Scene");
        playerInventory.InventoryContainer.Clear();
    }
}

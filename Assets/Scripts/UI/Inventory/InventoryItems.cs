using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.Animation;

public class InventoryItems : MonoBehaviour
{
    
    private PlayerInventory _playerInventory;
    [SerializeField] private GameObject _InventoryItemObject;

    void Start()
    {
        _playerInventory = FindObjectOfType<PlayerInventory>();
        if (!_InventoryItemObject)
        {
            Debug.LogError("Sell Item Object is not assigned in the inspector");
            return;
        }   

        float spawnObjectY = 0;
        foreach (Item item in _playerInventory.items)
        {
            GameObject inventoryItem = Instantiate(_InventoryItemObject, transform.Find("Viewport").transform.Find("Content").transform);            
            inventoryItem.transform.localScale = new Vector3(0.1f, 0.08f, 1);
            inventoryItem.GetComponent<InventoryItem>().item = item;
            spawnObjectY -= 50;
        }
    }

    void FixedUpdate()
    {
        UpdatePreviewEquipment();
    }

    public void UpdatePreviewEquipment() {
        if (SceneManager.GetSceneByName("PreviewPlayer").isLoaded)
        {
            PlayerInventory[] players = FindObjectsOfType<PlayerInventory>();
            foreach (PlayerInventory player in players)
            {
                if (player.gameObject.scene.name == "PreviewPlayer")
                {
                    SpriteLibrary[] playerChildsSL = _playerInventory.gameObject.GetComponentsInChildren<SpriteLibrary>();
                    SpriteLibrary[] previewChildsSL = player.gameObject.GetComponentsInChildren<SpriteLibrary>();
                    for (int i = 0; i < previewChildsSL.Length; i++)
                    {
                        previewChildsSL[i].spriteLibraryAsset = playerChildsSL[i].spriteLibraryAsset;
                        previewChildsSL[i].gameObject.GetComponent<SpriteResolver>().SetCategoryAndLabel(playerChildsSL[i].gameObject.GetComponent<SpriteResolver>().GetCategory(), playerChildsSL[i].gameObject.GetComponent<SpriteResolver>().GetLabel());
                        previewChildsSL[i].gameObject.GetComponent<SpriteRenderer>().sprite = playerChildsSL[i].gameObject.GetComponent<SpriteRenderer>().sprite;
                    }                        
                }
            }
        }
    }
}

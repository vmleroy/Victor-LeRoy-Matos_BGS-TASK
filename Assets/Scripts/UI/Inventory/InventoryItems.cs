using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class InventoryItems : MonoBehaviour
{
    
    private PlayerInventory _playerInventory;
    [SerializeField] private GameObject _InventoryItemObject;
    [SerializeField] private SceneAsset _PlayerPreviewScene;

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
        if (_PlayerPreviewScene)
        {
            Debug.Log("Player Preview Scene is assigned in the inspector");
            if (!_PlayerPreviewScene.IsDestroyed())
            {
                PlayerInventory[] players = FindObjectsOfType<PlayerInventory>();
                foreach (PlayerInventory player in players)
                {
                    if (player.gameObject.scene.name == _PlayerPreviewScene.name)
                    {
                        SpriteLibrary[] previewChildsSL = _playerInventory.gameObject.GetComponentsInChildren<SpriteLibrary>();
                        SpriteLibrary[] playerChildsSL = player.gameObject.GetComponentsInChildren<SpriteLibrary>();
                        for (int i = 0; i < previewChildsSL.Length; i++)
                        {
                            playerChildsSL[i].spriteLibraryAsset = previewChildsSL[i].spriteLibraryAsset;
                        }                        
                    }
                }
            }
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{

    private bool _playerCanOpenChest;
    private PlayerInteractionEvent _playerInteraction;
    [SerializeField] private GameObject _InventoryUI;

    void Start()
    {
        if (!_InventoryUI)
        {
            Debug.LogError("Inventory UI is not assigned in the inspector");
            return;
        }
    }

    void Update()
    {
        if (_playerCanOpenChest && _playerInteraction.isInteracting) {
            OpenInventory();
        }   
    }

    void OpenInventory() {
        Instantiate(_InventoryUI, Vector3.zero, Quaternion.identity);
        SceneManager.LoadSceneAsync("PreviewPlayer", LoadSceneMode.Additive);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _playerInteraction = other.gameObject.GetComponent<PlayerInteractionEvent>();
            _playerCanOpenChest = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _playerInteraction = null;
            _playerCanOpenChest = false;
        }
    }
}

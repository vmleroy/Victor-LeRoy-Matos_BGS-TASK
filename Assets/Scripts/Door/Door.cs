using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    [SerializeField] private string _scene;
    private bool _isPlayerTouchingDoor;
    private PlayerInteractionEvent _playerInteraction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlayerTouchingDoor && _playerInteraction.isInteracting) {            
            SceneManager.LoadScene(_scene);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _playerInteraction = other.gameObject.GetComponent<PlayerInteractionEvent>();
            _isPlayerTouchingDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _playerInteraction = null;
            _isPlayerTouchingDoor = false;
        }
    }
}

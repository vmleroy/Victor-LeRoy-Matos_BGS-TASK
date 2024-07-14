using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseUI : MonoBehaviour
{

    [SerializeField] private GameObject _UI;
    [SerializeField] private Button _closeButton;
    private PlayerInput _playerInput;

    // Start is called before the first frame update
    void Start()
    {   
        if (!_UI) {
            Debug.LogError("UI is not assigned in the inspector");
            return;
        }
        if (!_closeButton) {
            Debug.LogError("Close Button is not assigned in the inspector");
            return;
        }

        _closeButton.onClick.AddListener(CloseUIFunc);

        _playerInput = FindObjectOfType<PlayerInput>();
        _playerInput.isDisabled = true;
    }

    void CloseUIFunc() {
        _playerInput.isDisabled = false;
        if (SceneManager.GetSceneByName("PreviewPlayer").isLoaded) {
            SceneManager.UnloadSceneAsync("PreviewPlayer");
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Clone")) {
            Destroy(go);
        }

        Destroy(_UI);
    }
}

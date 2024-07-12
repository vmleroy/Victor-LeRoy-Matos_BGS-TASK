using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerSpriteControl : MonoBehaviour
{

    private SpriteLibrary[] _spriteLibraries;

    // Start is called before the first frame update
    void Start()
    {
        _spriteLibraries = GetComponentsInChildren<SpriteLibrary>();
    }

    // Update is called once per frame
    void Update()
    {
        // WIP: CODE SIMILAR TO THIS TO BE IMPLEMENTED AT STORE
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Debug.Log("Changing to PlayerAnimation");
            ChangeOutfitLibrary(Resources.Load<SpriteLibraryAsset>("Player/Sprites/PlayerAnimation"));
        }
    }

    public void ChangeOutfitLibrary (SpriteLibraryAsset index) {
        foreach (var library in _spriteLibraries)
        {
            if (library.gameObject.name == "Outfit")
            library.spriteLibraryAsset = index;
        }
    }
}

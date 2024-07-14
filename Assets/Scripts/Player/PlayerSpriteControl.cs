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

    public void ChangeOutfitLibrary (SpriteLibraryAsset index) {
        foreach (var library in _spriteLibraries)
        {
            if (library.gameObject.name == "Outfit")
            library.spriteLibraryAsset = index;
        }
    }
}

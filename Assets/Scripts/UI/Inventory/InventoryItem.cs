using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{

    public Item item;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        if (!item)
        {
            Debug.LogError("Item not set on " + gameObject.name);
            return;
        }

        _player = GameObject.FindGameObjectWithTag("Player");

        Image imagePic = transform.Find("ItemPic").Find("Image").GetComponent<Image>();
        imagePic.sprite = item.itemIcon;

        TMP_Text name = transform.Find("Name").GetComponent<TMP_Text>();
        name.text = item.itemName;

        Button equipButton = transform.Find("EquipButton").GetComponent<Button>();
        equipButton.onClick.AddListener(Equip);
    }

    void Equip () {
        _player.GetComponent<PlayerInventory>().EquipItem(item);
        gameObject.GetComponentInParent<InventoryItems>().UpdatePreviewEquipment();
    }
}

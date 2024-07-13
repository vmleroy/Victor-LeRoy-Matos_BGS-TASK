using TMPro;
using UnityEngine;
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

        GameObject equipButton = transform.Find("EquipButton").gameObject;
        if (_player.GetComponent<PlayerInventory>().EquipedItem(item))
        {
            equipButton.GetComponentInChildren<TMP_Text>().text = "Unequip";
            equipButton.GetComponent<Button>().onClick.AddListener(Unequip);
        }
        else
            equipButton.GetComponent<Button>().onClick.AddListener(Equip);
    }

    void Equip () {
        _player.GetComponent<PlayerInventory>().EquipItem(item);
        transform.Find("EquipButton").GetComponentInChildren<TMP_Text>().text = "Unequip";
        transform.Find("EquipButton").GetComponent<Button>().onClick.AddListener(Unequip);
    }

    void Unequip () {
        if (item.itemType == "Outfit")
            _player.GetComponent<PlayerInventory>().EquipItem(Resources.Load<Item>("Items/BoxerOutfit"));
        if (item.itemType == "Hair")
            _player.GetComponent<PlayerInventory>().EquipItem(Resources.Load<Item>("Items/NoHair"));
        if (item.itemType == "Hat")
            _player.GetComponent<PlayerInventory>().EquipItem(Resources.Load<Item>("Items/NoHat"));
        transform.Find("EquipButton").GetComponentInChildren<TMP_Text>().text = "Equip";
        transform.Find("EquipButton").GetComponent<Button>().onClick.AddListener(Equip);
    }
}

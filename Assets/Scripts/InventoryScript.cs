using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] private FPSController _fpsController;
    public GameObject inventoryList;
    public TextMeshProUGUI inventoryText;
    public List<string> _inventory = new List<string>();

    void Awake()
    {
        _fpsController = GetComponent<FPSController>();
        inventoryList = GameObject.Find("Inventory List");
        inventoryText = inventoryList.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_inventory.Count);

        int _inv = 0;

        if (_inv < 0) return;
        for (_inv = 0; _inv < 8; _inv++)
        {
            inventoryText.text = "Inventory: " + "\n\n" + _inventory[_inv].ToString();

            if (_inv > 0) 
            {
                inventoryText.text = "Inventory: " + "\n\n" + _inventory[_inv].ToString() + "\n+" +_inv + " more item/s";
            }
        }
    }
}

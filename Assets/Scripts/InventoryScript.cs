using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public enum EncumberedState
{
    Free,
    Encumbered,
    Overencumbered
}
public class InventoryScript : MonoBehaviour
{
    [SerializeField] private EncumberedState _encumberedState;
    [SerializeField] private FPSController _fpsController;
    public GameObject inventoryList;
    public TextMeshProUGUI inventoryText;
    public float currentInventoryCapacity = 0f;
    public float maxInventoryCapacity = 999f;
    public List<string> _inventory = new List<string>();

    void Awake()
    {
        _fpsController = GetComponent<FPSController>();
        inventoryList = GameObject.Find("Inventory List");
        inventoryText = inventoryList.GetComponent<TextMeshProUGUI>();
        currentInventoryCapacity = 0f;
        maxInventoryCapacity = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInventoryCapacity > maxInventoryCapacity) 
        {
            if (currentInventoryCapacity > (maxInventoryCapacity + (maxInventoryCapacity * 0.10))) 
            {
                _encumberedState = EncumberedState.Overencumbered;
            }
            else
            {
                _encumberedState = EncumberedState.Encumbered;
            }
        }
        else
        {
            _encumberedState = EncumberedState.Free;
        }

            EncumberChecker();
        // THIS IS NOT WORKING:
        inventoryText.text = "Inventory: " + "\n\n" + _inventory.Count.ToString();
        
    }

    public void EncumberChecker()
    {
        switch (_encumberedState) 
        {
            case EncumberedState.Free:
                Debug.Log("Current State: Free/Low Encumber");
                _fpsController._walkSpeed = 3f;
                _fpsController._sprintMultiplier = 2f;
                break;
            case EncumberedState.Encumbered:
                Debug.Log("Current State: Encumbered");
                _fpsController._walkSpeed = 1.5f;
                _fpsController._sprintMultiplier = 1.25f;
                break;
            case EncumberedState.Overencumbered:
                Debug.Log("Current State: Overencumbered");
                _fpsController._walkSpeed = 1f;
                _fpsController._sprintMultiplier = 1f;
                break;
            default:
                break;
        }
    }
}

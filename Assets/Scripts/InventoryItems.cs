using UnityEngine;

public class InventoryItems : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private float _objectWeight;

    public string InteractionPrompt => _prompt;

    public void Awake()
    {
        _objectWeight = Random.Range(1, 10);
    }
    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<InventoryScript>();

        if (inventory.currentInventoryCapacity > inventory.maxInventoryCapacity)
        {
            if (inventory.currentInventoryCapacity > (inventory.maxInventoryCapacity + (inventory.maxInventoryCapacity * 0.10)))
            {
                Debug.Log("Cannot Pick up Object, Inventory is Over Capacity.");
                return true;
            }
            else
            {
                Debug.Log("Warning. You are now Over Encumbered.");
                inventory.currentInventoryCapacity = inventory.currentInventoryCapacity + _objectWeight;
                inventory._inventory.Add(this.gameObject.name);
                Destroy(this.gameObject);
                return true;
            }
        }
        else
        {
            Debug.Log("Picked up Item");
            inventory.currentInventoryCapacity = inventory.currentInventoryCapacity + _objectWeight;
            inventory._inventory.Add(this.gameObject.name);
            Destroy(this.gameObject);
            return true;
        }
    }
}

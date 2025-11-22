using UnityEngine;

public class InventoryItems : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<InventoryScript>();
            
            Debug.Log("Picked up Item");
            inventory._inventory.Add(this.gameObject.name);
            Destroy(this.gameObject);
            return true;
    }
}

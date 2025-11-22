using UnityEngine;

public class PowerBoxScipt : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        var powerbox = interactor.GetComponent<FPSController>();
        Debug.Log("Turned off Power");
        powerbox.isElectrified = false;
        return true;
    }
}

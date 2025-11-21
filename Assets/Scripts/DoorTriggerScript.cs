using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class DoorTriggerScript : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private Transform doorTransform;
    public UnityEvent onDoorOpen, onDoorClose;
    public string InteractionPrompt => _prompt;
    [Header("Door Settings")]
    public float openAngle = 90f;     // How far the door should rotate
    public float swingDuration = 0.7f;
    public bool isOpen = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    public bool Interact(Interactor interactor)
    {
        if (isOpen)
            CloseDoor();
        else
            OpenDoor();

        return true;
    }

    public void OpenDoor()
    {
        doorTransform.DOLocalRotateQuaternion(openRotation, swingDuration).SetEase(Ease.OutCubic);
        isOpen = true;
        onDoorOpen?.Invoke();
    }

    public void CloseDoor()
    {
        doorTransform.DOLocalRotateQuaternion(closedRotation, swingDuration).SetEase(Ease.InCubic);
        isOpen = false;
        onDoorClose?.Invoke();
    }

    private void Start()
    {
        // Save default rotation as the "closed" state
        closedRotation = doorTransform.localRotation;

        // Calculate open rotation based on y-axis swing
        openRotation = Quaternion.Euler(doorTransform.localEulerAngles.x,
                                        doorTransform.localEulerAngles.y + openAngle,
                                        doorTransform.localEulerAngles.z);
    }

}

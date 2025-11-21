using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private GameObject _pickupPrompt;
    [SerializeField] private TextMeshProUGUI _pickupText;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private void Awake()
    {
        _pickupPrompt = GameObject.FindGameObjectWithTag("PickupUI");
        _pickupText = _pickupPrompt.GetComponent<TextMeshProUGUI>();
        _pickupPrompt.SetActive(false);
    }

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        if (_numFound > 0)
        {
            var interactable = _colliders[0].GetComponent<IInteractable>();

            if (interactable != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                interactable.Interact(this);
            }

            //Shows which object the player is interacting with.
            _pickupPrompt.SetActive(true);
            _pickupText.text = "Press \"E\" to pick up " + _colliders[0].name;
        }
        else
        {
            _pickupPrompt.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}

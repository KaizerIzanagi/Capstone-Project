using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class universaltrigger : MonoBehaviour
{
    public UnityEvent onTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onTrigger?.Invoke();
            Destroy(gameObject);
        } 
    }
}

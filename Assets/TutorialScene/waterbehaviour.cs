using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class waterbehaviour : MonoBehaviour
{
    private float maxheight;
    public float time = 1;
    public bool isTouchingWires = false;
    public void RaiseWaterLvl()
    {
        transform.DOScaleY(maxheight, time);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isTouchingWires)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.TryGetComponent(out FPSController controller))
            {
                controller.ToggleOnWater(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.TryGetComponent(out FPSController controller))
            {
                controller.ToggleOnWater(false);
            }
        }
    }

    public void ToggleWire(bool value)
    {
        isTouchingWires = value;
    }

    public void SetMaxHeight(float value)
    {
        maxheight = value;
    }
}

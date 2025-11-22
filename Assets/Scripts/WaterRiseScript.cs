using UnityEngine;
using System.Collections;

public class WaterRiseScript : MonoBehaviour
{
    public FPSController FPSController;
    public GameObject water;
    public Renderer waterColor;
    public float waterRise;
    public float waterMaxHeight;
    void Awake()
    {
        FPSController = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        water = this.gameObject;
        waterColor = GetComponent<Renderer>();
        FPSController.isElectrified = false;
        FPSController.isPlayerInWater = false;
    }

    // Update is called once per frame
    void Update()
    {
        RisingWater();

        if (!FPSController.isElectrified)
        {
            waterColor.material.color = Color.blue;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision with Player");
            FPSController.isPlayerInWater = true;
        }

        if (other.CompareTag("Hazard"))
        {
            Debug.Log("Water is currently Electric Powered");
            waterColor.material.color = Color.yellow;
            FPSController.isElectrified = true;
        }
    }

    void RisingWater()
    {
        if (waterRise < 8)
        {
            waterRise += Time.deltaTime;
            water.transform.Translate(0, waterRise / 10000, 0);
            Debug.Log("Water is Currently Rising");

        }
        else
        {
            Debug.Log("Water has stopped for now");
        }
    }

}

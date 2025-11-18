using UnityEngine;
using System.Collections;

public enum FloodStage
{
    One,
    Two,
    Three
}
public class WaterRiseScript : MonoBehaviour
{
    public GameObject water;
    public Renderer waterColor;
    public float waterRise;
    public FloodStage stage;
    void Awake()
    {
        water = this.gameObject;
        waterColor = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaterCheckpoints());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            Debug.Log("Collision with Player");
        }

        if (other.CompareTag("Hazard"))
        {
            Debug.Log("Water is currently Electric Powered");
            waterColor.material.color = Color.yellow;
        }
    }

    void RisingWater()
    {
        waterRise += Time.deltaTime / 10000;
    }

    IEnumerator WaterCheckpoints()
    {
        switch (stage)
        {
            case FloodStage.One:
                Debug.Log("Phase 1 Initiated");
                if (water.transform.localScale.y >= 1f && water.transform.localScale.y < 1.4f)
                {
                    RisingWater();
                    water.transform.localScale += new Vector3(0, waterRise, 0);
                }
                if (water.transform.localScale.y > 1.4f)
                {
                    Debug.Log("Plase 1 Terminated");
                    StopCoroutine(WaterCheckpoints());
                }
                break;
            case FloodStage.Two:
                Debug.Log("Phase 2 Initiated");
                if (water.transform.localScale.y <= 1.4f || water.transform.localScale.y >= 1.5f)
                {
                    yield return new WaitForSeconds(10f);
                    RisingWater();
                    water.transform.localScale += new Vector3(0, waterRise, 0);
                }
                if (water.transform.localScale.y > 1.70f)
                {
                    Debug.Log("Plase 2 Terminated");
                    StopCoroutine(WaterCheckpoints());
                }
                break;
            case FloodStage.Three:
                Debug.Log("Phase 3 Initiated");
                if (water.transform.localScale.y <= 1.7f || water.transform.localScale.y >= 1.75f)
                {
                    yield return new WaitForSeconds(10f);
                    RisingWater();
                    water.transform.localScale += new Vector3(0, waterRise, 0);
                }
                if (water.transform.localScale.y >= 2f)
                {
                    Debug.Log("Plase 3 Terminated. Player Dead.");
                    StopCoroutine(WaterCheckpoints());
                }
                break;
            default:
                break;
        }
    }

}

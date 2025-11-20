using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseWireScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Temporary tripwire way to fail the objective
            //Should put a canvas display to the player to indicate fail(restart or quit)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

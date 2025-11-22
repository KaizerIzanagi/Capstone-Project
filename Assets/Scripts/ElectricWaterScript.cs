using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ElectricWaterScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private FPSController FPSController;
    [SerializeField] private GameObject _blackScreenTextObj;
    [SerializeField] private GameObject _MultiUI;
    [SerializeField] private TextMeshProUGUI _blackScreenText;
    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        FPSController = player.GetComponent<FPSController>();
        _MultiUI = GameObject.FindGameObjectWithTag("MultiUI");
        _blackScreenTextObj = GameObject.FindGameObjectWithTag("BlackScreenText");
        _blackScreenText = _blackScreenTextObj.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FPSController.isElectrified == true && FPSController.isPlayerInWater == true)
        {
            _MultiUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _blackScreenText.text = "You died to electrified water";
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

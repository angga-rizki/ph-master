using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSimulasi : MonoBehaviour
{
    public GameObject phMeterButtonObj;
    public GameObject ujiLakmusButtonObj;
    public GameObject praktikumKehidupanButtonObj;

    private Button phMeterButton;
    private Button ujiLakmusButton;
    private Button praktikumKehidupanButton;

    public static string _tipeSimulasi;
    public static string _tipeUji;

    // Start is called before the first frame update
    void Start()
    {
        phMeterButton = phMeterButtonObj.GetComponent<Button>();
        ujiLakmusButton = ujiLakmusButtonObj.GetComponent<Button>();
        praktikumKehidupanButton = praktikumKehidupanButtonObj.GetComponent<Button>();

        phMeterButton.onClick.AddListener(() => LoadScene("TutorialUjiPHMeter", "uji_ph", "ph_meter"));
        ujiLakmusButton.onClick.AddListener(() => LoadScene("TutorialUjiPH", "uji_ph", "uji_lakmus"));
        praktikumKehidupanButton.onClick.AddListener(() => LoadScene("PraktikumMaterialDiKehidupan", "praktikum_kehidupan", "uji_asam"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScene(string namaScene, string tipeSimulasi, string tipeUji)
    {
        _tipeSimulasi = tipeSimulasi;
        _tipeUji = tipeUji;

        SceneManager.LoadScene(namaScene);
    }
}

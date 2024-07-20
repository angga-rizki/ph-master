using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public GameObject petunjukButtonObj;
    public GameObject tentangMediaButtonObj;
    public GameObject startButtonObj;

    private Button petunjukButton;
    private Button tentangMediaButton;
    private Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        petunjukButton = petunjukButtonObj.GetComponent<Button>();
        tentangMediaButton = tentangMediaButtonObj.GetComponent<Button>();
        startButton = startButtonObj.GetComponent<Button>();

        petunjukButton.onClick.AddListener(() => { LoadScene("PetunjukUtama"); });
        tentangMediaButton.onClick.AddListener(() => { LoadScene("TentangMedia"); });
        startButton.onClick.AddListener(() => { LoadScene("MenuUtama"); });
    }

    void LoadScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}

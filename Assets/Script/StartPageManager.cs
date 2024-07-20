using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPageManager : MonoBehaviour
{
    public GameObject mulaiButtonObj;

    private Button mulaiButton;

    // Start is called before the first frame update
    void Start()
    {
        mulaiButton = mulaiButtonObj.GetComponent<Button>();

        mulaiButton.onClick.AddListener(() => { LoadScene("StartMenu"); });
    }

    void LoadScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}

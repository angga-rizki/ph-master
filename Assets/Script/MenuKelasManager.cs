using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuKelasManager : MonoBehaviour
{
    public GameObject backButtonObj;
    public GameObject materiAsamBasaButtonObj;
    public GameObject derajatKeasamanPhButtonObj;
    public GameObject pretestButtonObj;

    private Button materiAsamBasaButton;
    private Button derajatKeasamanPhButton;
    private Button pretestButton;

    // Start is called before the first frame update
    void Start()
    {
        materiAsamBasaButton = materiAsamBasaButtonObj.GetComponent<Button>();
        derajatKeasamanPhButton = derajatKeasamanPhButtonObj.GetComponent<Button>();
        pretestButton = pretestButtonObj.GetComponent<Button>();

        materiAsamBasaButton.onClick.AddListener(() => { LoadScene("MateriAsamBasa"); });
        derajatKeasamanPhButton.onClick.AddListener(() => { LoadScene("MateriDerajatKeasaman"); });
        pretestButton.onClick.AddListener(() => { LoadScene("Pretest"); });
    }

    void LoadScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }
}

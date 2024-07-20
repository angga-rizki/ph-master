using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUtamaManager : MonoBehaviour
{
    public GameObject kelasButtonObj;
    public GameObject labButtonObj;
    public GameObject backButtonObj;

    private Button kelasButton;
    private Button labButton;

    // Start is called before the first frame update
    void Start()
    {
        // inisialisasi button
        kelasButton = kelasButtonObj.GetComponent<Button>();
        labButton = labButtonObj.GetComponent<Button>();

        kelasButton.onClick.AddListener(() => { LoadScene("MenuKelas"); });
        labButton.onClick.AddListener(() => { LoadScene("MenuLab"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }
}

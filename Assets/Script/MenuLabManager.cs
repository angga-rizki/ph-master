using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLabManager : MonoBehaviour
{
    public GameObject backButtonObj;
    public GameObject k3LabButtonObj;
    public GameObject praktikumButtonObj;
    public GameObject postestButtonObj;

    private Button k3LabButton;
    private Button praktikumButton;
    private Button postestButton;

    // Start is called before the first frame update
    void Start()
    {
        k3LabButton = k3LabButtonObj.GetComponent<Button>();
        praktikumButton = praktikumButtonObj.GetComponent<Button>();
        postestButton = postestButtonObj.GetComponent<Button>();

        k3LabButton.onClick.AddListener(() => { LoadScene("MateriK3"); });
        praktikumButton.onClick.AddListener(() => { LoadScene("MenuSimulasi"); });
        postestButton.onClick.AddListener(() => { LoadScene("Posttest"); });
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

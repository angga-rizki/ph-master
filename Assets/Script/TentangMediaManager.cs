using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TentangMediaManager : MonoBehaviour
{
    public GameObject profilPengembangButtonObj;

    private Button profilPengembangButton;

    // Start is called before the first frame update
    void Start()
    {
        profilPengembangButton = profilPengembangButtonObj.GetComponent<Button>();

        profilPengembangButton.onClick.AddListener(() => { LoadScene("ProfilPengembang"); });
    }

    void LoadScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }
}

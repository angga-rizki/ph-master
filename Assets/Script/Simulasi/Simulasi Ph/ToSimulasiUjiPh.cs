using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToSimulasiUjiPh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button toSimulasiUjiPhButton = gameObject.GetComponent<Button>();

        toSimulasiUjiPhButton.onClick.AddListener(KeSimulasiUjiPh);
    }

    void KeSimulasiUjiPh()
    {
        // set previous page menjadi scene Menu Praktikum
        BackButtonSystemManager._previousPage.Pop();

        SceneManager.LoadScene("SimulasiUjiPH");
    }
}

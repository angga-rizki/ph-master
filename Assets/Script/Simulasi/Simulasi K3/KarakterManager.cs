using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KarakterManager : MonoBehaviour
{
    public GameObject lanjutButtonObj;
    private Button lanjutButton;

    public BoxCollider2D colliderMata;
    public BoxCollider2D colliderMulut;
    public BoxCollider2D colliderBadan;
    public BoxCollider2D colliderTangan;

    public bool pakaiKacamata = false;
    public bool pakaiMasker = false;
    public bool pakaiJaket = false;
    public bool pakaiGlove = false;

    private void Start()
    {
        lanjutButton = lanjutButtonObj.GetComponent<Button>();
        lanjutButton.onClick.AddListener(LoadMenuSimulasi);
    }

    private void Update()
    {
        if (pakaiKacamata && pakaiMasker && pakaiJaket && pakaiGlove && !lanjutButton.interactable)
            lanjutButton.interactable = true;
    }

    void LoadMenuSimulasi()
    {
        // set previous page ke scene Menu Lab
        BackButtonSystemManager._previousPage.Pop();
        BackButtonSystemManager._previousPage.Pop();

        SceneManager.LoadScene("MenuSimulasi");
    }
}

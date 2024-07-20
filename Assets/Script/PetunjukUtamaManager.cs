using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PetunjukUtamaManager : MonoBehaviour
{
    public GameObject kembaliButtonObj;
    public GameObject lanjutButtonObj;
    public GameObject petunjuk1Obj;
    public GameObject petunjuk2Obj;

    private Button kembaliButton;
    private Button lanjutButton;

    // Start is called before the first frame update
    void Start()
    {
        kembaliButton = kembaliButtonObj.GetComponent<Button>();
        lanjutButton = lanjutButtonObj.GetComponent<Button>();

        kembaliButton.onClick.AddListener(Page1);
        lanjutButton.onClick.AddListener(Page2);
    }

    void Page1()
    {
        petunjuk1Obj.SetActive(true);
        petunjuk2Obj.SetActive(false);
        lanjutButtonObj.SetActive(true);
        kembaliButtonObj.SetActive(false);
    }

    void Page2()
    {
        petunjuk1Obj.SetActive(false);
        petunjuk2Obj.SetActive(true);
        lanjutButtonObj.SetActive(false);
        kembaliButtonObj.SetActive(true);
    }
}

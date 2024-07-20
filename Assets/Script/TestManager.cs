using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TestManager : MonoBehaviour
{
    public GameObject jawabanGroup1;
    public GameObject jawabanGroup2;
    public GameObject jawabanGroup3;
    public GameObject jawabanGroup4;
    public GameObject jawabanGroup5;
    public GameObject DisabledNextButton;

    private ToggleGroup jawaban1;
    private ToggleGroup jawaban2;
    private ToggleGroup jawaban3;
    private ToggleGroup jawaban4;
    private ToggleGroup jawaban5;

    // Start is called before the first frame update
    void Start()
    {
        jawaban1 = jawabanGroup1.GetComponent<ToggleGroup>();
        jawaban2 = jawabanGroup2.GetComponent<ToggleGroup>();
        jawaban3 = jawabanGroup3.GetComponent<ToggleGroup>();
        jawaban4 = jawabanGroup4.GetComponent<ToggleGroup>();
        jawaban5 = jawabanGroup5.GetComponent<ToggleGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jawaban1.AnyTogglesOn() && jawaban2.AnyTogglesOn() && jawaban3.AnyTogglesOn() && jawaban4.AnyTogglesOn() && jawaban5.AnyTogglesOn())
            DisabledNextButton.gameObject.SetActive(false);
        else
            DisabledNextButton.gameObject.SetActive(true);

    }
}

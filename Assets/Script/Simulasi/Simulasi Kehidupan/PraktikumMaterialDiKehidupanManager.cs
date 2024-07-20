using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PraktikumMaterialDiKehidupanManager : MonoBehaviour
{
    public GameObject dragAndDropObj;
    public GameObject praktikumAsamButtonObj;
    public GameObject praktikumBasaButtonObj;
    public GameObject praktikumSabunObj;
    public GameObject backgroundImageObj;
    public GameObject materialPraktikumAsam;
    public GameObject materialPraktikumBasa;
    public GameObject materialPraktikumSabun;
    public GameObject gelasBeker;
    public GameObject alatSabun;
    public GameObject caraMembuatTextObj;
    public GameObject kertasLakmus;
    public GameObject bubbleObj;
    public GameObject adukProgressObj;

    public Sprite backgroundPraktikumAsam;
    public Sprite backgroundPraktikumBasa;
    public Sprite backgroundPraktikumSabun;

    public bool step1Sabun = false;
    public bool step2Sabun = false;
    public bool step3Sabun = false;
    public bool step4Sabun = false;

    private Slider adukProgress;

    private SpriteRenderer backgroundImage;
    private PartKertasLakmusManager partKertasLakmusManagerScript;

    private Button praktikumAsamButton;
    private Button praktikumBasaButton;
    private Button praktikumSabunButton;

    private void Start()
    {
        GameObject partKertasLakmusObj = GameObject.Find("Part Kertas Lakmus"); //note: cek gameobject, harus active sebelum build project
        partKertasLakmusManagerScript = partKertasLakmusObj.GetComponent<PartKertasLakmusManager>();
        adukProgress = adukProgressObj.GetComponent<Slider>();

        backgroundImage = backgroundImageObj.GetComponent<SpriteRenderer>();        

        praktikumAsamButton = praktikumAsamButtonObj.GetComponent<Button>();
        praktikumBasaButton = praktikumBasaButtonObj.GetComponent<Button>();
        praktikumSabunButton = praktikumSabunObj.GetComponent<Button>();

        praktikumAsamButton.onClick.AddListener(PraktikumAsam);
        praktikumBasaButton.onClick.AddListener(PraktikumBasa);
        praktikumSabunButton.onClick.AddListener(PraktikumSabun);

        if (MenuSimulasi._tipeUji == "uji_asam")
            PraktikumAsam();
        else if (MenuSimulasi._tipeUji == "uji_basa")
            PraktikumBasa();
        else if (MenuSimulasi._tipeUji == "uji_sabun")
            PraktikumSabun();
    }

    void PraktikumAsam()
    {
        MenuSimulasi._tipeUji = "uji_asam";
        backgroundImage.sprite = backgroundPraktikumAsam;        
        gelasBeker.SetActive(true);
        alatSabun.SetActive(false);
        caraMembuatTextObj.SetActive(false);
        kertasLakmus.SetActive(true);
        materialPraktikumAsam.SetActive(true);
        materialPraktikumBasa.SetActive(false);
        materialPraktikumSabun.SetActive(false);
        ResetSimulasi();
    }

    void PraktikumBasa()
    {
        MenuSimulasi._tipeUji = "uji_basa";
        backgroundImage.sprite = backgroundPraktikumBasa;
        gelasBeker.SetActive(true);
        alatSabun.SetActive(false);
        caraMembuatTextObj.SetActive(false);
        kertasLakmus.SetActive(true);
        materialPraktikumAsam.SetActive(false);
        materialPraktikumBasa.SetActive(true);
        materialPraktikumSabun.SetActive(false);
        ResetSimulasi();
    }

    void PraktikumSabun()
    {
        MenuSimulasi._tipeUji = "uji_sabun";
        backgroundImage.sprite = backgroundPraktikumSabun;
        gelasBeker.SetActive(false);
        alatSabun.SetActive(true);
        caraMembuatTextObj.SetActive(true);
        kertasLakmus.SetActive(false);
        materialPraktikumAsam.SetActive(false);
        materialPraktikumBasa.SetActive(false);
        materialPraktikumSabun.SetActive(true);
        ResetSimulasi();
    }

    void ResetSimulasi()
    {
        GameObject[] geleasBeker = GameObject.FindGameObjectsWithTag("GelasBeker");
        GameObject[] containerAirMaterialKehidupan = GameObject.FindGameObjectsWithTag("Container Air Material Kehidupan");

        // reset air beker
        for (int i = 0; i < geleasBeker.Length; i++)
        {
            PolygonCollider2D colliderAirBeker = geleasBeker[i].GetComponent<PolygonCollider2D>();
            GameObject airBekerTerisi = geleasBeker[i].transform.GetChild(0).gameObject;
            GameObject airBekerKosong = geleasBeker[i].transform.GetChild(1).gameObject;

            colliderAirBeker.enabled = false;
            airBekerTerisi.SetActive(false);
            airBekerKosong.SetActive(true);
        }

        // reset air Container Air Material Kehidupan
        for (int i = 0; i < containerAirMaterialKehidupan.Length; i++)
        {
            GameObject airContainerKosong = containerAirMaterialKehidupan[i].transform.GetChild(0).gameObject;
            GameObject airContainerTerisi = containerAirMaterialKehidupan[i].transform.GetChild(1).gameObject;

            airContainerKosong.SetActive(false);
            airContainerTerisi.SetActive(true);
        }

        partKertasLakmusManagerScript.ResetWarnaKertasLakmus();

        step1Sabun = step2Sabun = step3Sabun = step4Sabun = false;
        bubbleObj.SetActive(false);
        adukProgress.value = 0f;
    }
}

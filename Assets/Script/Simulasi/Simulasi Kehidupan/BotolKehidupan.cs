using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotolKehidupan : MonoBehaviour
{
    public Sprite bekerTerisiJeruk;
    public Sprite bekerTerisiLemon;
    public Sprite bekerTerisiVinegar;
    public Sprite bekerTerisiSabunPel;
    public Sprite bekerTerisiObatMaag;
    public Sprite bekerTerisiSoap;
    public Sprite bekerTerisi1_4;
    public Sprite bekerTerisi2_4;
    public Sprite bekerTerisi3_4;
    public Sprite bekerTerisi4_4;

    private bool trigger = false;

    private PraktikumMaterialDiKehidupanManager praktikumMaterialDiKehidupanManagerScript;

    private GameObject gelasBeker;
    private GameObject gelasBekerTerisi;
    private GameObject gelasBekerKosong;
    private GameObject botolTerisi;
    private GameObject botolKosong;
    private GameObject tutupBotol;
    private SpriteRenderer airGelasBekerTerisi;

    // Start is called before the first frame update
    void Start()
    {
        GameObject praktikumMaterialDiKehidupanManagerObj = GameObject.Find("Praktikum Material Di Kehidupan Manager");
        praktikumMaterialDiKehidupanManagerScript = praktikumMaterialDiKehidupanManagerObj.GetComponent<PraktikumMaterialDiKehidupanManager>();

        botolKosong = gameObject.transform.GetChild(0).gameObject;
        botolTerisi = gameObject.transform.GetChild(1).gameObject;

        if (gameObject.name == "Botol Sabun Pel" || gameObject.name == "Botol Obat Maag"
            || gameObject.name == "Minyak Sawit" || gameObject.name == "Minyak Kelapa" || gameObject.name == "Minyak Zaitun" || gameObject.name == "Larutan KOH")
            tutupBotol = gameObject.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger && Input.GetMouseButtonUp(0))
        {
            if (gelasBeker && botolTerisi.activeSelf)
            {
                // set GameObject gelasBekerTerisi dan airGelasBekerTerisi
                gelasBekerTerisi = gelasBeker.transform.GetChild(0).gameObject;
                airGelasBekerTerisi = gelasBekerTerisi.GetComponent<SpriteRenderer>();


                if (MenuSimulasi._tipeUji != "uji_sabun" && gelasBekerKosong.activeSelf)
                {
                    SetSpriteAirGelasBekerTerisi();
                    IsiAirGelasBeker();

                    // enable collider trigger air
                    gelasBeker.GetComponent<PolygonCollider2D>().enabled = true;
                }
                else if (MenuSimulasi._tipeUji == "uji_sabun")
                {
                    if (gameObject.name == "Larutan KOH"
                        && !praktikumMaterialDiKehidupanManagerScript.step1Sabun)
                    {
                        SetSpriteAirGelasBekerTerisi();
                        IsiAirGelasBeker();
                        praktikumMaterialDiKehidupanManagerScript.step1Sabun = true;
                    }
                    else if (gameObject.name == "Minyak Kelapa"
                        && praktikumMaterialDiKehidupanManagerScript.step1Sabun && !praktikumMaterialDiKehidupanManagerScript.step2Sabun)
                    {
                        SetSpriteAirGelasBekerTerisi();
                        IsiAirGelasBeker();
                        praktikumMaterialDiKehidupanManagerScript.step2Sabun = true;
                    }
                    else if (gameObject.name == "Minyak Sawit"
                        && praktikumMaterialDiKehidupanManagerScript.step1Sabun && praktikumMaterialDiKehidupanManagerScript.step2Sabun
                        && !praktikumMaterialDiKehidupanManagerScript.step3Sabun)
                    {
                        SetSpriteAirGelasBekerTerisi();
                        IsiAirGelasBeker();
                        praktikumMaterialDiKehidupanManagerScript.step3Sabun = true;
                    }
                    else if (gameObject.name == "Minyak Zaitun"
                        && praktikumMaterialDiKehidupanManagerScript.step1Sabun && praktikumMaterialDiKehidupanManagerScript.step2Sabun
                        && praktikumMaterialDiKehidupanManagerScript.step3Sabun && !praktikumMaterialDiKehidupanManagerScript.step4Sabun)
                    {
                        SetSpriteAirGelasBekerTerisi();
                        IsiAirGelasBeker();
                        praktikumMaterialDiKehidupanManagerScript.step4Sabun = true;                        

                        // enable collider trigger air
                        gelasBeker.GetComponent<PolygonCollider2D>().enabled = true;
                    }
                }
            }
        }
    }

    void SetSpriteAirGelasBekerTerisi()
    {
        // set sprite air terisi untuk gelas beker
        if (gameObject.transform.parent.name == "Gelas Jeruk")
            airGelasBekerTerisi.sprite = bekerTerisiJeruk;
        else if (gameObject.transform.parent.name == "Gelas Lemon")
            airGelasBekerTerisi.sprite = bekerTerisiLemon;
        else if (gameObject.name == "Botol Cuka")
            airGelasBekerTerisi.sprite = bekerTerisiVinegar;
        else if (gameObject.name == "Botol Sabun Pel")
            airGelasBekerTerisi.sprite = bekerTerisiSabunPel;
        else if (gameObject.name == "Botol Obat Maag")
            airGelasBekerTerisi.sprite = bekerTerisiObatMaag;
        else if (gameObject.name == "Botol Soap")
            airGelasBekerTerisi.sprite = bekerTerisiSoap;
        else if (gameObject.name == "Larutan KOH")
            airGelasBekerTerisi.sprite = bekerTerisi1_4;
        else if (gameObject.name == "Minyak Kelapa")
            airGelasBekerTerisi.sprite = bekerTerisi2_4;
        else if (gameObject.name == "Minyak Sawit")
            airGelasBekerTerisi.sprite = bekerTerisi3_4;
        else if (gameObject.name == "Minyak Zaitun")
            airGelasBekerTerisi.sprite = bekerTerisi4_4;
    }

    void IsiAirGelasBeker()
    {
        // isi air ke dalam gelas beker
        gelasBekerKosong.SetActive(false);
        gelasBekerTerisi.SetActive(true);

        // hapus air dalam botol
        botolTerisi.SetActive(false);
        botolKosong.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GelasBeker"))
        {
            trigger = true; // set true flag trigger

            // set GameObject
            gelasBeker = collision.gameObject;
            gelasBekerKosong = gelasBeker.transform.GetChild(1).gameObject;

            transform.rotation = Quaternion.Euler(0, 0, 60f);

            if (tutupBotol)
                tutupBotol.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GelasBeker"))
        {
            trigger = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            if (tutupBotol)
                tutupBotol.SetActive(true);
        }
    }
}

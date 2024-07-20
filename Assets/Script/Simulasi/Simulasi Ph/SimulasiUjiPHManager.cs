using System;
using System.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimulasiUjiPHManager : MonoBehaviour
{
    public GameObject phMeterObj;

    public GelasBeker gelasBeker;
    public Botol botol;

    //UI
    public GameObject backgroundImageObj;
    public GameObject parentButtonDaftarSenyawa;
    public GameObject buttonDaftarSenyawaPrefab;
    public GameObject inputFieldObj;
    public GameObject windowHasilUjiPhMeter;
    public GameObject nilaiUjiPhMeterTextObj;
    public Sprite backgroundPhMeter;
    public Sprite backgroundUjiLakmus;

    private InputField inputCari;
    private TextMeshProUGUI nilaiUjiPhMeterText;

    //Audio Manager
    private GameObject audioManagerObj;
    private AudioManager audioManagerScript;

    //SQLite
    public GameObject sqliteObj;
    private SQLite sqliteScript;

    //Kertas lakmus
    public GameObject kertasLakmus;
    private GameObject partKertasLakmusObj;
    private PartKertasLakmusManager partKertasLakmusManagerScript;

    //--Serialize--
    [Serializable]
    public class DictionaryLiquid
    {
        public string nama;
        public float ph;
        public float konsentrasiMolaritas;
    }

    // Data list senyawa, ada di inspector
    [SerializeField]
    private List<DictionaryLiquid> listLiquidInspector;
    //--Serialize--

    private Dictionary<string, (float, float)> dictionaryDataSenyawa; //Dictionary<> untuk dibuild dari field serialize List<>

    private void Awake()
    {
        sqliteScript = sqliteObj.GetComponent<SQLite>();

        dictionaryDataSenyawa = new Dictionary<string, (float, float)>();
        foreach (DictionaryLiquid entry in listLiquidInspector)
        {
            dictionaryDataSenyawa.Add(entry.nama, (entry.ph, entry.konsentrasiMolaritas));

            sqliteScript.InsertLiquid(entry.nama, entry.ph, entry.konsentrasiMolaritas);

            CreateButtonDaftarSenyawa(entry.nama);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inputCari = inputFieldObj.GetComponent<InputField>();
        inputCari.onValueChanged.AddListener(CariSenyawa);

        SpriteRenderer backgroundImage = backgroundImageObj.GetComponent<SpriteRenderer>();
        nilaiUjiPhMeterText = nilaiUjiPhMeterTextObj.GetComponent<TextMeshProUGUI>();

        // set alat pengujian
        if(MenuSimulasi._tipeUji == "uji_lakmus")
        {
            backgroundImage.sprite = backgroundUjiLakmus;
            kertasLakmus.SetActive(true);
            phMeterObj.SetActive(false);
            windowHasilUjiPhMeter.SetActive(false);
        } else if (MenuSimulasi._tipeUji == "ph_meter")
        {
            backgroundImage.sprite = backgroundPhMeter;
            kertasLakmus.SetActive(false);
            phMeterObj.SetActive(true);
            windowHasilUjiPhMeter.SetActive(true);
        }

        // beri audio button daftar senyawa
        audioManagerObj = GameObject.Find("Audio Manager");
        AddSoundButtonDaftarSenyawa();

        partKertasLakmusObj = GameObject.Find("Part Kertas Lakmus");
        if (partKertasLakmusObj)
            partKertasLakmusManagerScript = partKertasLakmusObj.GetComponent<PartKertasLakmusManager>();
    }

    void AddSoundButtonDaftarSenyawa()
    {
        audioManagerScript = audioManagerObj.GetComponent<AudioManager>();
        GameObject[] buttonDaftarMaterial = GameObject.FindGameObjectsWithTag("ButtonDaftarSenyawa");
        audioManagerScript.AddButtonSound(buttonDaftarMaterial);
    }

    void CreateButtonDaftarSenyawa(string nama)
    {
        GameObject buttonSpawnBotol = Instantiate(buttonDaftarSenyawaPrefab, parentButtonDaftarSenyawa.transform); // buat button
        Button button = buttonSpawnBotol.GetComponent<Button>(); // inisialisasi button

        // buat objek class data senyawa
        Senyawa senyawa = new Senyawa(nama, dictionaryDataSenyawa[nama].Item1, dictionaryDataSenyawa[nama].Item2);
                
        buttonSpawnBotol.GetComponentInChildren<Text>().text = botol.ConvertNumberKeSubscript(nama); // set nama button
        button.onClick.AddListener(() => SpawnBotol(senyawa));
    }

    void SpawnBotol(Senyawa dataBotol)
    {
        ResetSimulasi();

        // set data botol yang akan di spawn
        botol.namaLiquid = dataBotol.namaLiquid;
        botol.ph = dataBotol.ph;
        botol.konsentrasiMoralitas = dataBotol.konsentrasiMoralitas;

        botol.SetKeteranganBotol();

        Instantiate(botol); // spawn botol dari senyawa yg dipilih
    }

    void ResetSimulasi()
    {
        // Reset warna kertas lakmus
        if(partKertasLakmusObj)
            partKertasLakmusManagerScript.ResetWarnaKertasLakmus();

        // reset hasil uji ph meter
        nilaiUjiPhMeterText.SetText("--");

        // -- Reset kondisi gelas beker ke awal --
        GameObject bekerTerisiObj = gelasBeker.transform.GetChild(0).gameObject;
        GameObject bekerKosongObj = gelasBeker.transform.GetChild(1).gameObject;

        // hapus air gelas beker
        bekerKosongObj.SetActive(true);
        bekerTerisiObj.SetActive(false);
        gelasBeker.GetComponent<PolygonCollider2D>().enabled = false; // disable collider trigger air
        gelasBeker.ResetValue();

        // hapus botol saat ini
        if (GameObject.FindGameObjectWithTag("Botol") != null)        
            Destroy(GameObject.FindGameObjectWithTag("Botol"));        
    }

    void CariSenyawa(string namaLiquid)
    {
        // Hapus list liquid
        GameObject[] buttonDaftarSenyawa = GameObject.FindGameObjectsWithTag("ButtonDaftarSenyawa");
        foreach (GameObject button in buttonDaftarSenyawa)        
            Destroy(button);        

        // Hasil search
        IDataReader result = sqliteScript.SearchData(namaLiquid);

        // Buat list liquid dari hasil cari, 0 = _id, 1 = keyNamaLiquid, 2 = keyPh
        while (result.Read())        
            CreateButtonDaftarSenyawa(result.GetString(1));        

        AddSoundButtonDaftarSenyawa();
    }
}

public class Senyawa
{
    public string namaLiquid;
    public float ph;
    public float konsentrasiMoralitas;

    public Senyawa(string namaLiquid, float ph, float konsentrasiMoralitas)
    {
        this.namaLiquid = namaLiquid;
        this.ph = ph;
        this.konsentrasiMoralitas = konsentrasiMoralitas;
    }
}

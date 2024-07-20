using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Botol : MonoBehaviour
{
    public string namaLiquid;
    public float ph;
    public float konsentrasiMoralitas;

    private bool trigger = false;

    private GameObject gelasBekerTerisi;
    private GameObject gelasBekerKosong;
    private GameObject botolTerisi;
    private GameObject botolKosong;
    private GameObject tutupBotol;

    private GelasBeker gelasBeker;

    private void Start()
    {
        gelasBeker = GameObject.Find("Gelas Beker").GetComponent<GelasBeker>();
        gelasBekerTerisi = gelasBeker.transform.GetChild(0).gameObject;
        gelasBekerKosong = gelasBeker.transform.GetChild(1).gameObject;
        botolKosong = transform.GetChild(1).gameObject;
        botolTerisi = transform.GetChild(2).gameObject;        
        tutupBotol = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger && Input.GetMouseButtonUp(0))
        {
            // hapus air dalam gelas beker
            botolTerisi.SetActive(false);
            botolKosong.SetActive(true);

            // isi air ke dalam bowl dan enable collider trigger air
            gelasBekerKosong.SetActive(false);
            gelasBekerTerisi.SetActive(true);
            gelasBeker.GetComponent<PolygonCollider2D>().enabled = true;

            // set stat liquid dan ph bowl
            gelasBeker.namaLiquid = namaLiquid;
            gelasBeker.ph = ph;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GelasBeker"))
        {
            trigger = true;

            transform.rotation = Quaternion.Euler(0, 0, 80f);

            tutupBotol.SetActive(false);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GelasBeker"))
        {
            trigger = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            tutupBotol.SetActive(true);
        }
    }

    public void SetKeteranganBotol()
    {
        GameObject keteranganNamaSenyawaObj = transform.GetChild(0).gameObject;
        GameObject ketaranganKonsentrasiMoralitasObj = transform.GetChild(7).gameObject;

        TextMeshPro keteranganNamaSenyawa = keteranganNamaSenyawaObj.GetComponent<TextMeshPro>();
        TextMeshPro ketaranganKonsentrasiMoralitas = ketaranganKonsentrasiMoralitasObj.GetComponent<TextMeshPro>();

        keteranganNamaSenyawa.SetText(ConvertNumberKeSubscript(namaLiquid));
        ketaranganKonsentrasiMoralitas.SetText(konsentrasiMoralitas.ToString("n5").TrimEnd('0') + " M");
    }

    public string ConvertNumberKeSubscript(string nama)
    {
        StringBuilder output = new StringBuilder();
        foreach (char character in nama)
        {
            char outputChar = character;
            if (Char.IsNumber(character))
                outputChar = (char)int.Parse(("f208" + character), System.Globalization.NumberStyles.HexNumber);

            output.Append(outputChar);
        }

        return output.ToString();
    }
}

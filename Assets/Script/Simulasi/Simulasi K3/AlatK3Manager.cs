using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlatK3Manager : MonoBehaviour
{
    public Sprite tanganGloveSprite;

    private GameObject karakter;
    private GameObject maskerKarakter;
    private GameObject kacamataKarakter;
    private GameObject bajuKarakter;
    private GameObject jaketKarakter;
    private GameObject tanganKarakter;

    private string namaObjAlatBaju = "Alat Jaket";
    private string namaObjAlatKacamata = "Alat Kacamata";
    private string namaObjAlatMasker = "Alat Masker";
    private string namaObjAlatGlove = "Alat Glove";   

    private bool triggerMata = false;
    private bool triggerMulut = false;
    private bool triggerBadan = false;
    private bool triggerTangan = false;

    private KarakterManager karakterManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        karakter = GameObject.Find("Karakter");
        karakterManagerScript = karakter.GetComponent<KarakterManager>();

        GameObject mukaKarakter = karakter.transform.GetChild(0).gameObject;
        maskerKarakter = mukaKarakter.transform.GetChild(0).gameObject;
        kacamataKarakter = mukaKarakter.transform.GetChild(1).gameObject;

        bajuKarakter = karakter.transform.GetChild(1).gameObject;
        jaketKarakter = karakter.transform.GetChild(2).gameObject;
        tanganKarakter = karakter.transform.GetChild(3).gameObject;
    }

    private void Update()
    {
        if (!Input.GetMouseButton(0) && triggerMulut && gameObject.activeSelf)
        {
            maskerKarakter.SetActive(true);
            gameObject.SetActive(false);
            karakterManagerScript.pakaiMasker = true;
        }
        else if (!Input.GetMouseButton(0) && triggerMata && gameObject.activeSelf)
        {
            kacamataKarakter.SetActive(true);
            gameObject.SetActive(false);
            karakterManagerScript.pakaiKacamata = true;
        }
        else if (!Input.GetMouseButton(0) && triggerBadan && gameObject.activeSelf)
        {
            bajuKarakter.SetActive(false);
            jaketKarakter.SetActive(true);
            gameObject.SetActive(false);
            karakterManagerScript.pakaiJaket = true;
        }
        else if (!Input.GetMouseButton(0) && triggerTangan && gameObject.activeSelf)
        {
            tanganKarakter.GetComponent<SpriteRenderer>().sprite = tanganGloveSprite;
            gameObject.SetActive(false);
            karakterManagerScript.pakaiGlove = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == namaObjAlatMasker && collision == karakterManagerScript.colliderMulut)
            triggerMulut = true;
        else if (gameObject.name == namaObjAlatKacamata && collision == karakterManagerScript.colliderMata)
            triggerMata = true;
        else if (gameObject.name == namaObjAlatBaju && collision == karakterManagerScript.colliderBadan)
            triggerBadan = true;
        else if (gameObject.name == namaObjAlatGlove && collision == karakterManagerScript.colliderTangan)
            triggerTangan = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.name == namaObjAlatMasker && collision == karakterManagerScript.colliderMulut)
            triggerMulut = false;
        else if (gameObject.name == namaObjAlatKacamata && collision == karakterManagerScript.colliderMata)
            triggerMata = false;
        else if (gameObject.name == namaObjAlatBaju && collision == karakterManagerScript.colliderBadan)
            triggerBadan = false;
        else if (gameObject.name == namaObjAlatGlove && collision == karakterManagerScript.colliderTangan)
            triggerTangan = false;
    }
}

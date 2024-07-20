using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartKertasLakmusManager : MonoBehaviour
{
    private float ph;

    private Renderer[] partKertasLakmusMerahRenderer;
    private Renderer[] partKertasLakmusBiruRenderer;
    private Color warnaKertasLakmusMerah = new Color(0.9568627f, 0.2156863f, 0.3764706f, 1);
    private Color warnaKertasLakmusBiru = new Color(0.1764706f, 0.5019608f, 0.8862745f, 1);

    private GelasBeker gelasBeker;

    private void Awake()
    {
        //di letakkan di Awake() karena terkadang hasil kertasLakmusMerahObj null karena func ResetSimulasi() dipanggil di Start() PraktikumMaterialDiKehidupanManager
        //sebelum PartKertasLakmusManager() selseai execute Start().
        GameObject kertasLakmusMerahObj = GameObject.Find("Kertas Lakmus Merah");
        GameObject kertasLakmusBiruObj = GameObject.Find("Kertas Lakmus Biru");

        partKertasLakmusMerahRenderer = kertasLakmusMerahObj.GetComponentsInChildren<Renderer>();
        partKertasLakmusBiruRenderer = kertasLakmusBiruObj.GetComponentsInChildren<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gelasBeker = GameObject.Find("Gelas Beker").GetComponent<GelasBeker>();

        SetWarnaKertasLakmus();
    }

    void SetWarnaKertasLakmus()
    {
        Renderer partKertasLakmusRenderer = gameObject.GetComponent<Renderer>();

        if (gameObject.transform.parent.name == "Kertas Lakmus Merah")
            partKertasLakmusRenderer.material.color = warnaKertasLakmusMerah;
        else if (gameObject.transform.parent.name == "Kertas Lakmus Biru")
            partKertasLakmusRenderer.material.color = warnaKertasLakmusBiru;
    }

    public void ResetWarnaKertasLakmus()
    {
        for (int i = 0; i < partKertasLakmusMerahRenderer.Length; i++)        
            partKertasLakmusMerahRenderer[i].material.color = warnaKertasLakmusMerah;        

        for (int i = 0; i < partKertasLakmusBiruRenderer.Length; i++)        
            partKertasLakmusBiruRenderer[i].material.color = warnaKertasLakmusBiru;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GelasBeker") && collision == collision.gameObject.GetComponent<PolygonCollider2D>())
        {
            if (MenuSimulasi._tipeSimulasi == "uji_ph")
                ph = gelasBeker.ph;
            else if (MenuSimulasi._tipeSimulasi == "praktikum_kehidupan" && MenuSimulasi._tipeUji == "uji_asam")
                ph = 5;
            else if (MenuSimulasi._tipeSimulasi == "praktikum_kehidupan" && (MenuSimulasi._tipeUji == "uji_basa" || MenuSimulasi._tipeUji == "uji_sabun"))
                ph = 10;

            // ubah warna kertas lakmus
            if (gameObject.transform.parent.name == "Kertas Lakmus Merah" && ph > 7 && ph <= 14)
            {
                gameObject.GetComponent<Renderer>().material.color = warnaKertasLakmusBiru;
            }
            else if (gameObject.transform.parent.name == "Kertas Lakmus Biru" && ph > 0 && ph < 7)
            {
                gameObject.GetComponent<Renderer>().material.color = warnaKertasLakmusMerah;
            }
        }
    }
}

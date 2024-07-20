using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhMeterManager : MonoBehaviour
{
    public GameObject nilaiUjiTextObj;
    public GelasBeker gelasBeker;

    private TextMeshProUGUI nilaiUjiText;

    private float ph;

    // Start is called before the first frame update
    void Start()
    {
        nilaiUjiText = nilaiUjiTextObj.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Gelas Beker" && collision == collision.gameObject.GetComponent<PolygonCollider2D>())
        {
            ph = gelasBeker.ph;
            nilaiUjiText.SetText(ph.ToString());
        }
    }
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bowl" && collision == collision.gameObject.GetComponent<PolygonCollider2D>())
        {
            ph = simulasiUjiPhManagerScript.bowl.ph;
            nilaiUjiText.SetText("--");
        }
    }
    */
}

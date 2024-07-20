using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelasBeker : MonoBehaviour
{
    public string namaLiquid;
    public float ph;

    public void ResetValue()
    {
        namaLiquid = "";
        ph = 0;
    }
}

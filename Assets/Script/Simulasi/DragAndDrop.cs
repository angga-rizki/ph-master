using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private GameObject partKertasLakmusObj;

    private PartKertasLakmusManager partKertasLakmusManagerScript;
    private AudioManager audioManagerScript;
    private Camera mainCamera;
    private Rigidbody2D selectedObjectRb;

    public GameObject selectedObject;
    private Vector3 mousePosition;
    private Vector3 offset;
    private Vector3 posisiAwalObjek;
    private float speed = 5f;
    private bool returnPosisi = false;

    //offset dari position z main camera untuk membuat z menjadi sama dengan position z objek yang di drag pada kalkulasi
    //variable mousePosition
    private Vector3 offsetGameObjectPositionZ = new Vector3(0, 0, 100);

    private Quaternion rotasiPhMeter = Quaternion.Euler(0, 0, 280f);
    private Quaternion rotasiSendok = Quaternion.Euler(0, 0, -77f);
    private Quaternion rotasiMasker = Quaternion.Euler(0, 0, -15f);

    private void Start()
    {
        // Cari singleton Audio Manager untuk play sound
        GameObject audioManagerObj = GameObject.Find("Audio Manager");
        audioManagerScript = audioManagerObj.GetComponent<AudioManager>();

        partKertasLakmusObj = GameObject.Find("Part Kertas Lakmus");
        if (partKertasLakmusObj)
            partKertasLakmusManagerScript = partKertasLakmusObj.GetComponent<PartKertasLakmusManager>();

        mainCamera = Camera.main;
    }

    private void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition + offsetGameObjectPositionZ);

        if (Input.GetMouseButtonDown(0) && !returnPosisi)
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;

                // reset warna kertas lakmus saat di klik jika simulasi praktikum kehidupan
                if (partKertasLakmusObj && (selectedObject.CompareTag("Part Kertas Lakmus") || selectedObject.CompareTag("Kertas Lakmus")) && MenuSimulasi._tipeSimulasi == "praktikum_kehidupan")                
                    partKertasLakmusManagerScript.ResetWarnaKertasLakmus();
                

                // jika yang terklik part kertas lakmus, set selectedObject ke parent (Kertas Lakmus)
                if (selectedObject.CompareTag("Part Kertas Lakmus"))                
                    selectedObject = selectedObject.transform.parent.gameObject;
                

                posisiAwalObjek = selectedObject.transform.position;
                offset = selectedObject.transform.position - mousePosition;

                // set rigidbody untuk digunakan MovePosition
                if (selectedObject.GetComponent<Rigidbody2D>())
                {
                    selectedObjectRb = selectedObject.GetComponent<Rigidbody2D>();

                    // add sound button
                    audioManagerScript.PlayButtonSound();
                }
            }
        }

        // sudah berada di posisi awal
        if (selectedObject && selectedObjectRb && !Input.GetMouseButton(0) && selectedObject.transform.position == posisiAwalObjek)
        {
            // kembalikan collider ke trigger
            selectedObject.GetComponent<Collider2D>().isTrigger = true;

            if (selectedObject.CompareTag("GelasBeker")) //botol material
                selectedObject.transform.GetChild(3).GetComponent<Collider2D>().isTrigger = true; // tutup botol

            // kembalikan rotation objek
            if (selectedObject.name == "PH Meter")
                selectedObject.transform.rotation = rotasiPhMeter;
            else if (selectedObject.name == "Sendok")
                selectedObject.transform.rotation = rotasiSendok;
            else if (selectedObject.name == "Alat Masker")
                selectedObject.transform.rotation = rotasiMasker;

            selectedObject = null;
            selectedObjectRb = null;
            returnPosisi = false;
        }
    }

    private void FixedUpdate()
    {
        // dragging
        if (selectedObject && selectedObjectRb)
        {
            // buat trigger collider ke false (default : true)
            selectedObject.GetComponent<Collider2D>().isTrigger = false;

            if (selectedObject.CompareTag("GelasBeker")) //botol material
                selectedObject.transform.GetChild(3).GetComponent<Collider2D>().isTrigger = false; // tutup botol

            // buat rotasi objek menjadi berdiri
            if (selectedObject.name == "PH Meter" || selectedObject.name == "Sendok" || selectedObject.name == "Alat Masker")
                selectedObject.transform.rotation = Quaternion.Euler(0, 0, 0);


            selectedObjectRb.isKinematic = false;
            selectedObjectRb.MovePosition(mousePosition + offset);
        }

        // return ke posisi awal objek
        if (selectedObject && selectedObjectRb && !Input.GetMouseButton(0) && selectedObject.transform.position != posisiAwalObjek)
        {
            returnPosisi = true;
            selectedObjectRb.isKinematic = true;

            // return posisi
            selectedObject.transform.position = Vector3.MoveTowards(selectedObject.transform.position, posisiAwalObjek, (speed * 100) * Time.deltaTime);
        }
    }
}

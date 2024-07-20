using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendokManager : MonoBehaviour
{
    public GameObject dragAndDropObj;
    public GameObject adukProgressObj;
    public GameObject kertasLakmus;
    public GameObject bubbleObj;

    private AudioManager audioManagerScript;

    private Slider adukProgress;

    private Vector3 lastPosition;
    private Vector3 currentPosition;

    private bool trigger = false;

    // Start is called before the first frame update
    void Start()
    {
        // Cari singleton Audio Manager untuk play sound
        GameObject audioManagerObj = GameObject.Find("Audio Manager");
        audioManagerScript = audioManagerObj.GetComponent<AudioManager>();

        adukProgress = adukProgressObj.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = gameObject.transform.position;

        if (!kertasLakmus.activeSelf && adukProgress.value == 100f)
        {
            audioManagerScript.soundPlayer.PlayOneShot(audioManagerScript.adukFinishSound);
            kertasLakmus.SetActive(true);
            bubbleObj.SetActive(true);
        }
    }

    private void LateUpdate()
    {
        if (trigger && lastPosition != currentPosition && adukProgress.value <= 100f)
        {
            adukProgress.value += .1f;
        }

        lastPosition = gameObject.transform.position;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Gelas Beker" && collision == collision.gameObject.GetComponent<PolygonCollider2D>())
        {
            trigger = true;
            adukProgressObj.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Gelas Beker" && collision == collision.gameObject.GetComponent<PolygonCollider2D>())
        {
            trigger = false;
            adukProgressObj.SetActive(false);
        }
    }
}

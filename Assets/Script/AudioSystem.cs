using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSystem : MonoBehaviour
{
    public GameObject[] buttonObj;

    private GameObject audioManagerObj;
    private AudioManager audioManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Akses singleton Audio Manager
        audioManagerObj = GameObject.Find("Audio Manager");
        audioManagerScript = audioManagerObj.GetComponent<AudioManager>();

        audioManagerScript.AddButtonSound(buttonObj);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToSimulasiK3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => { LoadScene("SimulasiK3"); });
    }

    void LoadScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }
}

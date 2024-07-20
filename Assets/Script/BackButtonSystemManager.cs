using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonSystemManager : MonoBehaviour
{
    public static Stack<string> _previousPage;

    // Start is called before the first frame update
    void Start()
    {
        // inisialisasi stack untuk menyimpan data previous page
        _previousPage = new Stack<string>();
        _previousPage.Push(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

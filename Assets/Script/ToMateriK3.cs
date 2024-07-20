using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToMateriK3 : MonoBehaviour
{
    private Button keK3Button;

    // Start is called before the first frame update
    void Start()
    {
        keK3Button = gameObject.GetComponent<Button>();

        keK3Button.onClick.AddListener(KeK3);
    }

    void KeK3()
    {
        // set previous page menjadi scene MenuLab
        BackButtonSystemManager._previousPage.Pop();
        BackButtonSystemManager._previousPage.Pop();
        BackButtonSystemManager._previousPage.Push("MenuLab");

        SceneManager.LoadScene("MateriK3");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButtonSystem : MonoBehaviour
{
    private Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        // set previous page untuk digunakan button back
        string thisScene = SceneManager.GetActiveScene().name;

        if (!BackButtonSystemManager._previousPage.Contains(thisScene))
            BackButtonSystemManager._previousPage.Push(thisScene);

        backButton = gameObject.GetComponent<Button>();
        backButton.onClick.AddListener(Back);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Back();
        }
    }

    void Back()
    {
        BackButtonSystemManager._previousPage.Pop();
        SceneManager.LoadScene(BackButtonSystemManager._previousPage.Peek());
    }
}

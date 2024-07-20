using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToGoogleClassroomButton : MonoBehaviour
{
    private string linkClassroom = "https://bit.ly/3TzP8uQ";

    private Button classroomButton;

    // Start is called before the first frame update
    void Start()
    {
        classroomButton = gameObject.GetComponent<Button>();

        classroomButton.onClick.AddListener(ToGoogleClassroom);
    }

    void ToGoogleClassroom()
    {
        Application.OpenURL(linkClassroom);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HyperlinkSystem : MonoBehaviour, IPointerClickHandler
{
    private TMP_Text m_textMeshPro;
    private Camera m_uiCamera;

    void Start()
    {
        m_textMeshPro = GetComponent<TMP_Text>();

        /*
        Camera[] cameras = FindObjectsOfType<Camera>();
        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i].CompareTag("MainCamera")) // this may be whatever for your case
            {
                m_uiCamera = cameras[i];
                break;
            }
        }*/
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(m_textMeshPro, Input.mousePosition, null);
        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = m_textMeshPro.textInfo.linkInfo[linkIndex];
            Application.OpenURL(linkInfo.GetLinkID());
        }
    }
}

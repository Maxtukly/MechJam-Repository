using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject panel;

    public void ChangePanel()
    {
        panel.active = !panel.active;
    }
}

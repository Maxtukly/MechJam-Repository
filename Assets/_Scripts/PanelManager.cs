using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject moduleManager;
    public GameObject panel;
    ModuleManager manager;
    ColorChange panelColors;

    private void Start()
    {
        manager = moduleManager.GetComponent<ModuleManager>();
        panelColors = panel.GetComponent<ColorChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.CheckValues())
        {
            panelColors.ChangeColor(1);
        }
        else
        {
            panelColors.ChangeColor(0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpPanelManager : MonoBehaviour
{
    public GameObject moduleManager;
    public GameObject statusIndicator;
    Dictionary<string, float> functionsStatus;
    ModuleManager manager;
    private void Start()
    {
        manager = moduleManager.GetComponent<ModuleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        functionsStatus = manager.FunctionsStatus();

        if (manager.CheckValues())
        {
            statusIndicator.GetComponent<ColorChange>().ChangeColor(1);
        }
        else
        {
            statusIndicator.GetComponent<ColorChange>().ChangeColor(0);
        }
    }
}

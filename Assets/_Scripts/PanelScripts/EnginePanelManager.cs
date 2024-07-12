using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginePanelManager : MonoBehaviour
{
    public GameObject moduleManager;
    public GameObject statusIndicator;
    public GameObject coolerIndicator;
    public GameObject oilIndicator;
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

        if (functionsStatus["Cooler"] > 50)
        {
            coolerIndicator.GetComponent<ColorChange>().ChangeColor(1);
        }
        else
        {
            coolerIndicator.GetComponent<ColorChange>().ChangeColor(0);
        }

        if (functionsStatus["Oil"] > 50)
        {
            oilIndicator.GetComponent<ColorChange>().ChangeColor(1);
        }
        else
        {
            oilIndicator.GetComponent<ColorChange>().ChangeColor(0);
        }

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

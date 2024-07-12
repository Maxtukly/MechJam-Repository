using System.Collections.Generic;
using UnityEngine;

public class ElectronicsPanelManager : MonoBehaviour
{
    public GameObject moduleManager;
    public GameObject statusIndicator;

    private ModuleManager manager;

    void Start()
    {
        manager = moduleManager.GetComponent<ModuleManager>();
    }

    void Update()
    {
        Dictionary<string, float> functionsStatus = manager.FunctionsStatus();
        if (functionsStatus.ContainsKey("Charge") && functionsStatus["Charge"] == 80)
        {
            statusIndicator.GetComponent<ColorChange>().ChangeColor(1); // Change to green or appropriate color at index 1
        }
        else
        {
            statusIndicator.GetComponent<ColorChange>().ChangeColor(0); // Change to red or appropriate color at index 0
        }
    }

    public void IncreaseCharge()
    {
        manager.GetComponent<ElectronicsFunctions>().AddToValue("Charge", 10);
    }
}

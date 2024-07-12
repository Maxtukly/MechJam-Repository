using System.Collections.Generic;
using UnityEngine;

public class ElectronicsFunctions : MonoBehaviour
{
    public float Charge;
    private const float maxCharge = 80;

    public Dictionary<string, float> functions = new Dictionary<string, float>();
    ModulInteraction mainModule;

    void Start()
    {
        mainModule = GetComponent<ModulInteraction>();
        Charge = 0;

        functions.Add("Charge", 0); // Initialize charge to 0
    }

    void Update()
    {
        if (mainModule.Enabled)
        {
            mainModule.moduleManager.SendMessage("FunctionsChange", functions);
        }

        if (functions["Charge"] >= maxCharge)
        {
            mainModule.Steady = true;
        }
        else
        {
            mainModule.Steady = false;
        }
    }

    public void AddToValue(string key, float value)
    {
        if (functions.ContainsKey(key))
        {
            functions[key] += value;
            if (functions[key] > maxCharge)
            {
                functions[key] = maxCharge;
            }
        }
        else
        {
            Debug.LogWarning($"Key {key} not found in functions dictionary.");
        }
    }

    public void ModuleStart()
    {
        if (mainModule.Steady)
        {
            mainModule.Working = true;
        }
    }

    public void ModuleStop()
    {
        mainModule.Working = false;
    }
}
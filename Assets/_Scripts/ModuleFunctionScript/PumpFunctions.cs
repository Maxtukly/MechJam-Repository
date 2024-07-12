using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpFunction : MonoBehaviour
{
    public Dictionary<string, float> functions = new Dictionary<string, float>();

    ModulInteraction mainModule;

    // Start is called before the first frame update
    void Start()
    {
        mainModule = GetComponent<ModulInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainModule.Enabled)
        {
            mainModule.moduleManager.SendMessage("FunctionsChange", functions);
            mainModule.Steady = true;
        }
    }

    public void AddToValue(string Key, float plus)
    {
        functions[Key] += plus;
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

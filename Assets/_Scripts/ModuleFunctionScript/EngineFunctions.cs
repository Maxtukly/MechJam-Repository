using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EngineFunctions : MonoBehaviour
{
    public float cooler;
    public float oil;
    public float radiator1;
    public float radiator2;

    public Dictionary<string, float> functions = new Dictionary<string, float>();
    public Dictionary<string, float> maxfunctions = new Dictionary<string, float>();
    ModulInteraction mainModule;

    // Start is called before the first frame update
    void Start()
    {
        mainModule = GetComponent<ModulInteraction>();
        cooler = 100;
        oil = 100;

        functions.Add("Cooler", cooler);
        functions.Add("Oil", oil);
        functions.Add("Radiator 1", radiator1);
        functions.Add("Radiator 2", radiator2);

        maxfunctions.Add("Cooler", 100);
        maxfunctions.Add("Oil", 100);
        maxfunctions.Add("Radiator 1", 1);
        maxfunctions.Add("Radiator 2", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (mainModule.Enabled)
        {
            mainModule.moduleManager.SendMessage("FunctionsChange", functions);
        }
        if (functions["Cooler"] > 50 && functions["Oil"] > 50 && functions["Radiator 1"] > 0 && functions["Radiator 2"] > 0)
        {
            mainModule.Steady = true;
        }

    }

    public void AddToValue(string Key, float plus)
    {
        functions[Key] += plus;
    }

    public void ModuleStart()
    {
        if(mainModule.Steady)
        {
            mainModule.Working = true;
        }
    }

    public void ModuleStop()
    {
        mainModule.Working = false;
    }

    void BreakSomething()
    {
        string[] keys = new string[functions.Keys.Count];
        functions.Keys.CopyTo(keys, 0);
        string key = keys[Random.Range(0, keys.Length - 1)];
        if (functions[key] > 0)
        {
            AddToValue(key, -Random.Range(1, maxfunctions[key]));
        }
        else
        {
            functions[key] = 0;
        }
        ModuleStop();
    }
}

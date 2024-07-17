using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpFunction : MonoBehaviour
{
    public string Type;
    bool listed;

    FightManager fightManager;

    public Dictionary<string, float> functions = new Dictionary<string, float>();
    public Dictionary<string, float> maxfunctions = new Dictionary<string, float>();

    ModulInteraction mainModule;

    // Start is called before the first frame update
    void Start()
    {
        mainModule = GetComponent<ModulInteraction>();
        fightManager = GameObject.Find("FightManager").GetComponent<FightManager>();
        Type = "Pumps";
        listed = false;

        functions.Add("Pipe1", 1);
        functions.Add("Pipe2", 1);
        functions.Add("Pipe3", 1);

        maxfunctions.Add("Pipe1", 1);
        maxfunctions.Add("Pipe2", 1);
        maxfunctions.Add("Pipe3", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (mainModule.Enabled)
        {
            mainModule.moduleManager.SendMessage("FunctionsChange", functions);
            mainModule.Steady = true;
        }
        if (mainModule.Working && !listed)
        {
            fightManager.RepairModule(Type);
            listed = true;
        }
        if (functions["Pipe1"] >= 1 && functions["Pipe2"] >= 1 && functions["Pipe3"] >= 1)
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
        if (mainModule.Steady)
        {
            mainModule.Working = true;
            fightManager.RepairModule(Type);
            listed = true;
        }
    }

    public void ModuleStop()
    {
        mainModule.Working = false;
        fightManager.BreakModule(Type);
        listed = false;
    }

    void BreakSomething()
    {
        string[] keys = new string[functions.Keys.Count];
        functions.Keys.CopyTo(keys, 0);
        string key = keys[Random.Range(0, keys.Length)];
        if (functions[key] > 0)
        {
            AddToValue(key, -Random.Range(1, maxfunctions[key]));
            Debug.Log(key);
            if (functions[key] < 0)
            {
                functions[key] = 0;
            }
        }
        mainModule.Steady = false;
        ModuleStop();
    }
}

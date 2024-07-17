using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EngineFunctions : MonoBehaviour
{
    public float cooler;
    public float oil;
    public float radiator1;

    public string Type;
    bool listed;

    public Dictionary<string, float> functions = new Dictionary<string, float>();
    public Dictionary<string, float> maxfunctions = new Dictionary<string, float>();
    ModulInteraction mainModule;
    FightManager fightManager;

    // Start is called before the first frame update
    void Start()
    {
        mainModule = GetComponent<ModulInteraction>();
        fightManager = GameObject.Find("FightManager").GetComponent<FightManager>();
        Type = "Motors";
        listed = false;

        cooler = 100;
        oil = 100;

        functions.Add("Cooler", cooler);
        functions.Add("Oil", oil);
        functions.Add("Radiator 1", 1);

        maxfunctions.Add("Cooler", 100);
        maxfunctions.Add("Oil", 100);
        maxfunctions.Add("Radiator 1", 1);

    }

    // Update is called once per frame
    void Update()
    {
        if (mainModule.Enabled)
        {
            mainModule.moduleManager.SendMessage("FunctionsChange", functions);
        }
        if(mainModule.Working && !listed)
        {
            fightManager.RepairModule(Type);
            listed = true;
        }

        functions["Cooler"] += fightManager.mechModules["Pumps"] * Time.deltaTime;

        if (functions["Cooler"] > 50 && functions["Oil"] > 50 && functions["Radiator 1"] > 0)
        {
            mainModule.Steady = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(functions["Radiator 1"]);
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
            if(functions[key] < 0)
            {
                functions[key] = 0;
            }
        }
        mainModule.Steady = false;
        ModuleStop();
    }
}

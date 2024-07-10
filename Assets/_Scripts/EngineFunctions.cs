using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineFunctions : MonoBehaviour
{
    public float cooler;
    public float oil;

    float maxCooler = 100;
    float maxOil = 100;

    public Dictionary<string, float> functions = new Dictionary<string, float>();

    ModulInteraction mainModule;

    // Start is called before the first frame update
    void Start()
    {
        mainModule = GetComponent<ModulInteraction>();

        cooler = Random.Range(0, maxCooler/2);
        oil = Random.Range(0, maxOil/2);

        functions.Add("Cooler", cooler);
        functions.Add("Oil", oil);
    }

    // Update is called once per frame
    void Update()
    {
        if (functions["Cooler"] > maxCooler/2 && functions["Oil"] > maxOil/2)
        {
            mainModule.Working = true;
        }
    }

    public void AddToValue(string Key, float plus)
    {
        functions[Key] += plus;
    }
}

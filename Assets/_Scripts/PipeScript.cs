using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeScript : MonoBehaviour
{
    ModuleManager manager;

    [SerializeField] Sprite functioning;
    [SerializeField] Sprite broken;
    [SerializeField] int ID;

    Dictionary<string, float> pumpFunctions = new Dictionary<string, float>();
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Module Manager").GetComponent<ModuleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        pumpFunctions = manager.FunctionsStatus();

        if (pumpFunctions["Pipe" + ID.ToString()] < 1)
        {
            GetComponent<Image>().overrideSprite = broken;
        }
        else
        {
            GetComponent<Image>().overrideSprite = functioning;
        }

        manager.FunctionsChange(pumpFunctions);
    }

    public void Repair()
    {
        if(manager.instrument() == "Wrench")
        {
            pumpFunctions["Pipe" + ID.ToString()] = 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidIterfaceScript : MonoBehaviour
{
    public GameObject moduleManager;
    public GameObject indicator;
    GameObject Engine;
    ModuleManager manager;

    bool filling;
    public string liquid;

    // Start is called before the first frame update
    void Start()
    {
        manager = moduleManager.GetComponent<ModuleManager>();
        filling = false;
    }

    // Update is called once per frame
    void Update()
    {
        Engine = manager.CurrentModule();
        if (Engine.GetComponent<EngineFunctions>().functions[liquid] > 50)
        {
            indicator.GetComponent<ColorChange>().ChangeColor(1);
        }
        if (filling)
        {
            if(Engine.GetComponent<EngineFunctions>().functions[liquid] < Engine.GetComponent<EngineFunctions>().maxfunctions[liquid])
            {
                if(manager.instrument() == "Hose")
                {
                    Engine.GetComponent<EngineFunctions>().AddToValue(liquid, 20 * Time.deltaTime);
                }              
            }
            else
            {
                Engine.GetComponent<EngineFunctions>().functions[liquid] = Engine.GetComponent<EngineFunctions>().maxfunctions[liquid];
            }
            Debug.Log(liquid + ":" + Engine.GetComponent<EngineFunctions>().functions[liquid]);
        }
    }

    public void Fill(bool Filling)
    {
        filling = Filling;
    }
}

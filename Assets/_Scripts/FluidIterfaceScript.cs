using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidIterfaceScript : MonoBehaviour
{
    public GameObject moduleManager;
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
        if(filling)
        {
            Engine.GetComponent<EngineFunctions>().AddToValue(liquid, 5 * Time.deltaTime);
            Debug.Log(liquid + ":" + Engine.GetComponent<EngineFunctions>().functions[liquid]);
        }
    }

    public void Fill(bool Filling)
    {
        filling = Filling;
    }
}

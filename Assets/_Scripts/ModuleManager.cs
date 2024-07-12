using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ModuleManager : MonoBehaviour
{
    public GameObject currentModule;
    public Transform Player;
    public LayerMask Modules;
    public Dictionary<string, float> moduleFunctions = new Dictionary<string, float>();

    private void Update()
    {
        if(!Physics2D.OverlapCircle(Player.position, 2, Modules))
        {
            currentModule = null;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Current module" + currentModule.name);
        }
    }

    public void InteractWithModule()
    {
        ModulInteraction module = currentModule.GetComponent<ModulInteraction>();
        if (module != null)
        {
            module.Interaction();
        }
    }

    public bool CheckValues()
    {
        if(currentModule != null)
        {
            ModulInteraction module = currentModule.GetComponent<ModulInteraction>();
            return module.Working;
        }
        return false;
    }

    public GameObject CurrentModule()
    {
        return currentModule;
    }

    public void FunctionsChange(Dictionary<string, float> Functions)
    {
        moduleFunctions = Functions;
    }
    public Dictionary<string, float> FunctionsStatus()
    {
        return moduleFunctions;
    }
}

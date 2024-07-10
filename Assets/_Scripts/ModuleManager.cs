using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ModuleManager : MonoBehaviour
{
    public GameObject currentModule;
    public Transform Player;
    public LayerMask Modules;

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
        ModulInteraction module = currentModule.GetComponent<ModulInteraction>();
        return module.Working;
    }

    public GameObject CurrentModule()
    {
        return currentModule;
    }


}

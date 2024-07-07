using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ModuleManager : MonoBehaviour
{
    public GameObject currentModule;
    
    public void InteractWithModule()
    {
        ModulInteraction module = currentModule.GetComponent<ModulInteraction>();
        if (module != null)
        {
            module.Interaction();
        }
    }
}

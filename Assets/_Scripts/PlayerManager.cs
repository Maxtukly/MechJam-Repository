using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public string CurrentInstrument;

    //[SerializeField] Sprite cableSprite;
    [SerializeField] Texture2D screwdriverSprite;
    [SerializeField] Texture2D hoseSprite;
    [SerializeField] Texture2D wrenchSprite;

    private void Update()
    {
        if(CurrentInstrument == null)
        {
            Cursor.SetCursor(null, new Vector2(0, 0), CursorMode.ForceSoftware);
        }

        if (CurrentInstrument == "Cable")
        {
            Cursor.SetCursor(null, new Vector2(0, 0), CursorMode.ForceSoftware);
        }

        if (CurrentInstrument == "Screwdriver")
        {
            Cursor.SetCursor(screwdriverSprite, new Vector2(16, 16), CursorMode.ForceSoftware);
        }

        if (CurrentInstrument == "Hose")
        {
            Cursor.SetCursor(hoseSprite, new Vector2(16, 16), CursorMode.ForceSoftware);
        }

        if (CurrentInstrument == "Wrench")
        {
            Cursor.SetCursor(wrenchSprite, new Vector2(20, 20), CursorMode.ForceSoftware);
        }
    }
}

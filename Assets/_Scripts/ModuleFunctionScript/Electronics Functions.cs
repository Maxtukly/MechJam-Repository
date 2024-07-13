using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectronicFunctions : MonoBehaviour
{
    public float chargeAmount = 10f; // ʳ������ ������, �� ��������
    private ElectronicsPanelManager panelManager;

    private void Start()
    {
        panelManager = FindObjectOfType<ElectronicsPanelManager>();
        if (panelManager != null)
        {
            Button button = GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(OnClick);
            }
            else
            {
                Debug.LogError("Button component missing from the GameObject.");
            }
        }
    }

    // ����� ��� ��������� ������
    private void OnClick()
    {
        if (panelManager != null)
        {
            panelManager.ChargeBattery(chargeAmount);
        }
    }
}

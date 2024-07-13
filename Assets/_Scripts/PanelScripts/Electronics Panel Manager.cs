using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectronicsPanelManager : MonoBehaviour
{
    public GameObject panel; // ������, ��� ������� ����������/���������
    public Image batteryIndicator; // ��������� ������
    public Button[] chargeButtons; // ����� ������ ��� �������
    public Button resetButton; // ������ ��� �������� ������

    private float batteryCharge = 0f; // ����� ������
    private const float maxBatteryCharge = 80f; // ������������ ����� ������

    private void Start()
    {
        // ������������ �������� ����� ������
        foreach (Button button in chargeButtons)
        {
            button.onClick.AddListener(() => ChargeBattery(10f));
        }
        resetButton.onClick.AddListener(ResetBattery);

        // Make sure panel is initially inactive
        if (panel != null)
        {
            panel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Panel GameObject is not assigned in the Inspector.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (panel != null)
            {
                panel.SetActive(!panel.activeSelf);
            }
            else
            {
                Debug.LogWarning("Panel GameObject is not assigned in the Inspector.");
            }
        }

        UpdatePanelStatus();
    }

    // ����� ��� ���������� ������
    public void ChargeBattery(float amount)
    {
        batteryCharge += amount;
        if (batteryCharge > maxBatteryCharge)
        {
            batteryCharge = maxBatteryCharge; // �������� 80
        }
    }

    // ����� ��� �������� ������
    private void ResetBattery()
    {
        batteryCharge = 0f;
    }

    // ����� ��� ��������� ����� �����
    private void UpdatePanelStatus()
    {
        // ��������� ������� ���������� ������ � ������
        if (batteryCharge >= maxBatteryCharge)
        {
            batteryIndicator.color = Color.cyan; // ���� ��� ������������� �����
            foreach (Button button in chargeButtons)
            {
                button.GetComponent<Image>().color = Color.green; // ����� ������ ��� ������������� �����
            }
        }
        else
        {
            batteryIndicator.color = Color.red; // �������� ��� ������������� �����
            foreach (Button button in chargeButtons)
            {
                button.GetComponent<Image>().color = Color.red; // ����� ���� ������
            }
        }
    }
}

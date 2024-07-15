using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightManager : MonoBehaviour
{

    [SerializeField] float fightTime;
    [SerializeField] float casualtiesTime;
    [SerializeField] float mechHealth;
    float casualtiesTimer;
    [SerializeField] TextMeshProUGUI timerText;
    public Dictionary<string, int> mechFunctions = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        casualtiesTimer = casualtiesTime;
        mechFunctions.Add("Motors", 0);
        mechFunctions.Add("Pumps", 0);
        mechFunctions.Add("Electronics", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(fightTime > 0)
        {

            fightTime -= Time.deltaTime;

            if(casualtiesTimer > 0)
            {
                casualtiesTimer -= Time.deltaTime + Random.RandomRange(-0.5f, 2);
            }
            if(casualtiesTimer < 0)
            {
                casualtiesTimer = casualtiesTime;
            }
        }
        if(fightTime < 0)
        {
            fightTime = 0;
        }

        int minutes = Mathf.FloorToInt(fightTime / 60);
        int seconds = Mathf.FloorToInt(fightTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    void BreakDown()
    {
        
    }
}

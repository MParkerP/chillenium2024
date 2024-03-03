using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private int dayLength = 10;

    [SerializeField] private int dayCount = 1;
    [SerializeField] private int secondsRemaining;

    public UnityEvent newDay;
    public UnityEvent newNight;

    [SerializeField] private TextMeshProUGUI secondsText;
    [SerializeField] private TextMeshProUGUI daysText;
    [SerializeField] private TextMeshProUGUI daylightText;




    private void Start()
    {
        daylightText.text = " DAYTIME";
        StartCoroutine(dayTimer());
    }

    

    IEnumerator dayTimer()
    {
        secondsRemaining = dayLength;
        int intervals = 1;
        while (true)
        {
            while (intervals < 2)
            {
                Debug.Log("intervals = " + intervals.ToString());
                yield return new WaitForSeconds(1);
                secondsRemaining--;
                secondsText.text = "Time: " + secondsRemaining.ToString();
                if (secondsRemaining == 0)
                {
                    if (intervals == 0)
                    {
                        daylightText.text = " DAYTIME";
                        newDay?.Invoke();
                    }
                    
                    if(intervals == 1)
                    {
                        daylightText.text = " NIGHTTIME";
                        newNight?.Invoke();
                    }
                    intervals++;
                    secondsRemaining = dayLength;
                    
                }
            }
            dayCount++;
            daysText.text = " Day: " + dayCount.ToString();
            intervals = 0;
        }
    }

}

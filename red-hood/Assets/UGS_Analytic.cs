using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

public class UGS_Analytic : MonoBehaviour
{
    async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
            GiveConsent(); //Get user consent according to various legislations
        }
        catch (ConsentCheckException e)
        {
            Debug.Log(e.ToString());
        }
    }

    public void LevelCompletedCustomEvent()
    {

        // Define Custom Parameters
        try
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "levelName", "level 1 " }
        };

            // The ‘levelCompleted’ event will get cached locally
            //and sent during the next scheduled upload, within 1 minute
            AnalyticsService.Instance.CustomData("levelCompleted", parameters);

            // You can call Events.Flush() to send the event immediately
            AnalyticsService.Instance.Flush();
            Debug.Log("Level completed event has just been sent");

        }
        catch (System.Exception e )
        {

            Debug.Log(e.ToString());
        }

    }


    public void LevelFailedCustomEvent()
    {

        // Define Custom Parameters
        try
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "levelName", "level 1 " }
        };

            // The ‘levelCompleted’ event will get cached locally
            //and sent during the next scheduled upload, within 1 minute
            AnalyticsService.Instance.CustomData("levelFailed", parameters);

            // You can call Events.Flush() to send the event immediately
            AnalyticsService.Instance.Flush();
            Debug.Log("Level failed event has just been sent");

        }
        catch (System.Exception ex)
        {

            Debug.Log(ex.ToString());
        }

    }


    public void PlayerInventoryCustomEvent(int numberOfDiamonds, int numberOfKeys, int percentageOfHealth)
    {
        try
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "numberOfDiamonds", numberOfDiamonds},
                { "numberOfKeys",  numberOfKeys},
                { "percentageOfHealth", percentageOfHealth }
            };
            AnalyticsService.Instance.CustomData("playerInventory", parameters);

            // You can call Events.Flush() to send the event immediately
            AnalyticsService.Instance.Flush();
            Debug.Log("playerInventory event has just been sent");
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }

    public void GiveConsent()
    {
        // Call if consent has been given by the user
        AnalyticsService.Instance.StartDataCollection();
        Debug.Log($"Consent has been provided. The SDK is now collecting data!");
    }

    public void CurrentNumberOfDiamonds(int numberOfDiamonds)
    {
        try
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "eventTimestamp", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") },
                { "numberOfDiamonds", numberOfDiamonds},
            };
            AnalyticsService.Instance.CustomData("numberOfDiamonds", parameters);

            // You can call Events.Flush() to send the event immediately
            AnalyticsService.Instance.Flush();
            Debug.Log("numberOfDiamonds event has just been sent");
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }

    public void CurrentNumberOfKeys(int numberOfKeys)
    {
        try
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "eventTimestamp", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") },
                { "numberOfKeys", numberOfKeys},
            };
            AnalyticsService.Instance.CustomData("numberOfKeys", parameters);

            // You can call Events.Flush() to send the event immediately
            AnalyticsService.Instance.Flush();
            Debug.Log("numberOfKeys event has just been sent");
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }

    public void CurrentNumberOfBatteries(int numberOfBatteries)
    {
        try
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "eventTimestamp", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") },
                { "numberOfKeys", numberOfBatteries},
            };
            AnalyticsService.Instance.CustomData("numberOfBatteries", parameters);

            // You can call Events.Flush() to send the event immediately
            AnalyticsService.Instance.Flush();
            Debug.Log("numberOfBatteries event has just been sent");
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }
}

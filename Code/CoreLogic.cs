using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GWYF.NoNPCs.Code
{
    internal static class CoreLogic
    {
        internal static void MakeNPCStaticsInactive(ManualLogSource logger)
        {
            GameObject[] allObjects = GameObject.FindObjectsByType<GameObject>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

            int count = 0;
            foreach (GameObject obj in allObjects)
            {
                if (obj.name.Contains("NPC Static"))
                {
                    obj.SetActive(false);
                    count++;
                }
            }

            logger.LogInfo($"Disabled {count} NPC object(s).");
        }
    }
}

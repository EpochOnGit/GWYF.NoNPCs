using BepInEx;
using BepInEx.Logging;
using GWYF.NoNPCs.Code;
using HarmonyLib;
using UnityEngine.SceneManagement;

namespace GWYF.NoNPCs
{
    [BepInProcess("Gamble With Your Friends.exe")]
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;
        
        private void Awake()
        {
            // Plugin startup logic
            Logger = base.Logger;

            SceneManager.sceneLoaded += OnSceneLoaded;
            
            new Harmony(MyPluginInfo.PLUGIN_GUID).PatchAll();

            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            CoreLogic.MakeNPCStaticsInactive(Logger);
        }
    }

    public static class MyPluginInfo
    {
        public const string PLUGIN_GUID = "GWYF.Epoch.NoNPCs";
        public const string PLUGIN_NAME = "No NPCs!";
        public const string PLUGIN_VERSION = "1.0.2";
    }
}

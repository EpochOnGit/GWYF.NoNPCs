using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GWYF.NoNPCs.Code
{
    [HarmonyPatch(typeof(NPCController), "RegisterNPC")]
    public static class Patch_NPCController_RegisterNPC
    {
        static bool Prefix()
        {
            // returning false skips the original method entirely
            return false;
        }
    }

    [HarmonyPatch(typeof(NPCSpawner), "SpawnAllCoroutine")]
    public static class Patch_SpawnAllCoroutine
    {
        static bool Prefix(ref IEnumerator __result)
        {
            __result = EmptyCoroutine();
            return false;
        }

        static IEnumerator EmptyCoroutine()
        {
            yield break;
        }
    }

    [HarmonyPatch(typeof(NPCSpawner), "SpawnNPCsForFloor")]
    public static class Patch_SpawnNPCsForFloor
    {
        static bool Prefix(ref IEnumerator __result)
        {
            __result = EmptyCoroutine();
            return false;
        }

        static IEnumerator EmptyCoroutine()
        {
            yield break;
        }
    }
}

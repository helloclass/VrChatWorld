
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Defulat_Player_Stat1 : UdonSharpBehaviour
{
    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        player.SetWalkSpeed(6);
        player.SetStrafeSpeed(6);
    }
}

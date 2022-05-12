
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Default_Player_Stat : UdonSharpBehaviour
{
    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        player.SetWalkSpeed(5);
        player.SetStrafeSpeed(5);
    }
}

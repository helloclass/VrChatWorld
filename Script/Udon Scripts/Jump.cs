
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Jump : UdonSharpBehaviour
{
    // 트리거가 충돌체에 충돌하면 반응
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        player.SetVelocity(new Vector3(0.0f, 20.0f, 0.0f));
    }

}

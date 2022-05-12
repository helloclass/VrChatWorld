
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Jump2 : UdonSharpBehaviour
{
    void Start()
    {
        
    }

    // 트리거가 충돌체에 충돌하면 반응
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        player.SetVelocity(new Vector3(0.0f, 80.0f, 100.0f));
    }
}

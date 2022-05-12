
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SwimCollider : UdonSharpBehaviour
{
    public void Start()
    {
    }

    public override void OnPlayerTriggerStay(VRCPlayerApi player)
    {
        if (Input.GetKey("space"))
        {
            player.SetVelocity(new Vector3(0.0f, 3.0f, 0.0f));
        }
    }
}

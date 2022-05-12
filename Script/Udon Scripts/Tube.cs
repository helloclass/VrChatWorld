
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Tube : UdonSharpBehaviour
{
    public GameObject mWaterCollider;

    bool isUsed;
    Rigidbody rigid;
    VRCPlayerApi mPlayer;
    Vector3 spine;
    Vector3 mSpawnPos;

    private void Start()
    {
        isUsed = false;
        rigid = GetComponent<Rigidbody>();
        mSpawnPos = rigid.position;
    }

    private void FixedUpdate()
    {
        if (isUsed)
        {
            spine = mPlayer.GetBonePosition(HumanBodyBones.Spine);
            rigid.position = spine;
        }
    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        mPlayer = player;
    }

    public override void Interact()
    {
        if (isUsed)
        {
            rigid.position = mSpawnPos;
            mWaterCollider.GetComponent<SwimCollider1>().mIsFloating = false;
        }
        else
        {
            mWaterCollider.GetComponent<SwimCollider1>().mIsFloating = true;
        }

        isUsed ^= true;
    }
}

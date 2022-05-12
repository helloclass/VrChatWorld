using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TestCam : UdonSharpBehaviour
{
    public bool isUsed;
    Rigidbody rigid;
    VRCPlayerApi mPlayer;
    Vector3 head, spine;
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
            rigid.rotation = mPlayer.GetRotation();

            //if (Input.GetKey(KeyCode.F9))
            //{
            //    head = mPlayer.GetBonePosition(HumanBodyBones.Head);
            //}
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
        }

        isUsed ^= true;
    }
}

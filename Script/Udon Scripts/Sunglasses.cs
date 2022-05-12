
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Sunglasses : UdonSharpBehaviour
{
    bool isUsed;
    Rigidbody rigid;
    VRCPlayerApi mPlayer;
    Vector3 offset, spine;
    Vector3 mSpawnPos;
    Quaternion spineRot;

    public GameObject mBody;

    private void Start()
    {
        isUsed = false;
        rigid = GetComponent<Rigidbody>();
        mSpawnPos = rigid.position;
        offset = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (isUsed)
        {
            if (Input.GetKey(KeyCode.F2))
            {
                Vector3 rotVec;

                if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                {
                    rotVec = rigid.rotation.eulerAngles + new Vector3(1.0f, 0.0f, 0.0f);
                    rigid.rotation = Quaternion.Euler(rotVec);
                }
                else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                    rotVec = rigid.rotation.eulerAngles + new Vector3(-1.0f, 0.0f, 0.0f);
                    rigid.rotation = Quaternion.Euler(rotVec);
                }
                else if (Input.GetKey(KeyCode.PageUp))
                {
                    rigid.transform.localScale *= 1.1f;
                }
                else if (Input.GetKey(KeyCode.PageDown))
                {
                    rigid.transform.localScale *= 0.9f;
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    offset.z += 0.01f;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    offset.z -= 0.01f;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    offset.y += 0.01f;
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    offset.y -= 0.01f;
                }
                else if (Input.GetKey(KeyCode.Escape))
                {
                    Interact();
                }
            }

            spine = mPlayer.GetBonePosition(HumanBodyBones.Head);
            rigid.transform.position = spine;

            mBody.transform.localPosition = offset;

            spineRot = mPlayer.GetBoneRotation(HumanBodyBones.Head);
            rigid.transform.rotation = spineRot;
            mBody.transform.rotation = spineRot;
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
            rigid.transform.position = mSpawnPos;
            rigid.transform.rotation = Quaternion.identity;
            offset = Vector3.zero;
            mBody.transform.localPosition = Vector3.zero;
        }
        else
        {
            offset = new Vector3(0.0f, 2.0f, 3.0f);
            mBody.transform.localPosition += offset;
        }

        //rigid.transform.localEulerAngles += new Vector3(0.0f, 180.0f, 0.0f);
        isUsed ^= true;
    }
}

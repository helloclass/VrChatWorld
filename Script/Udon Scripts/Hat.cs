
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Hat : UdonSharpBehaviour
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
            if (Input.GetKey(KeyCode.F3))
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
                    offset.z += 2.2f;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    offset.z -= 2.2f;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    offset.y += 2.2f;
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    offset.y -= 2.2f;
                }
                else if (Input.GetKey(KeyCode.Escape))
                {
                    Interact();
                }
            }

            spine = mPlayer.GetBonePosition(HumanBodyBones.Head);
            rigid.transform.position = spine;

            mBody.GetComponent<Rigidbody>().position = offset;

            ////////////
            rigid.transform.position += new Vector3(0.0f, 0.01f, 0.0f);
            mBody.GetComponent<Rigidbody>().position += new Vector3(0.0f, 0.01f, 0.0f);
            ////////////

            spineRot = mPlayer.GetBoneRotation(HumanBodyBones.Head);
            rigid.rotation = spineRot;
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
            rigid.position = mSpawnPos;
            offset = Vector3.zero;
            mBody.GetComponent<Rigidbody>().position = Vector3.zero;
        }
        else
        {
            offset = new Vector3(0.0f, 4.0f, 0.0f);
            mBody.GetComponent<Rigidbody>().position += offset;
        }

        //rigid.transform.localEulerAngles += new Vector3(0.0f, 180.0f, 0.0f);
        isUsed ^= true;
    }
}

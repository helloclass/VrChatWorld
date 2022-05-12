
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Boat : UdonSharpBehaviour
{
    VRCPlayerApi mPlayer;
    Vector3 mLeft, mRight;
    Vector3 mSpeed;
    bool isBoarding;

    Vector3 mResponePos;
    Quaternion mResponeRot;

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);

        isBoarding = false;
        mResponePos = GetComponent<Rigidbody>().position;
        mResponeRot = GetComponent<Rigidbody>().rotation;
    }

    private void FixedUpdate()
    {
        if (isBoarding)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.GetComponent<Rigidbody>().transform.Rotate(gameObject.transform.up * Time.fixedDeltaTime * -80.0f);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.GetComponent<Rigidbody>().transform.Rotate(gameObject.transform.up * Time.fixedDeltaTime * 80.0f);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                mSpeed = gameObject.transform.right * -5.0f;
                gameObject.GetComponent<Rigidbody>().AddForce(mSpeed);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                mSpeed = gameObject.transform.right * 5.0f;
                gameObject.GetComponent<Rigidbody>().AddForce(mSpeed);
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                mSpeed = gameObject.GetComponent<Rigidbody>().velocity;

                if ((0.01f < mSpeed.x || mSpeed.x < -0.01f) ||
                    (0.01f < mSpeed.z || mSpeed.z < -0.01f))
                {
                    mSpeed.x = Mathf.Lerp(mSpeed.x, 0.0f, 30.0f);
                    mSpeed.z = Mathf.Lerp(mSpeed.z, 0.0f, 30.0f);

                    gameObject.GetComponent<Rigidbody>().velocity = mSpeed;
                }
               
            }
            else
            {
                mSpeed = gameObject.GetComponent<Rigidbody>().velocity;

                if ((0.01f < mSpeed.x || mSpeed.x < -0.01f) ||
                    (0.01f < mSpeed.z || mSpeed.z < -0.01f))
                {
                    mSpeed.x = Mathf.Lerp(mSpeed.x, 0.0f, Time.fixedDeltaTime);
                    mSpeed.z = Mathf.Lerp(mSpeed.z, 0.0f, Time.fixedDeltaTime);

                    gameObject.GetComponent<Rigidbody>().velocity = mSpeed;
                }
                else
                {
                    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
                }
            }
        }
    }

    public override void OnStationEntered(VRCPlayerApi player)
    {
        mPlayer = player;
        isBoarding = true;
    }

    public override void OnStationExited(VRCPlayerApi player)
    {
        isBoarding = false;

        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        GetComponent<Rigidbody>().position = mResponePos;
        GetComponent<Rigidbody>().rotation = mResponeRot;
    }
}

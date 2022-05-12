
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SwimCollider1 : UdonSharpBehaviour
{
    public GameObject mSoundEffect;
    public bool mIsSoundOn;
    public bool mIsFloating;
    public bool mIsExit;
    public float mExitTime;

    void Start()
    {
        mSoundEffect = GameObject.Find("PlayerEffectSound");
        mIsSoundOn  = false;
        mIsFloating = false;
        mIsExit     = false;
        mExitTime   = 0.0f;
    }

    private void Update()
    {
        if (mIsExit)
        {
            mExitTime += Time.deltaTime;

            if (mExitTime > 3.0f)
            {
                mExitTime = 0.0f;
                mIsExit = false;
                mIsSoundOn = false;
                mSoundEffect.GetComponent<AudioSource>().Stop();
            }
        }
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        mIsExit = false;

        if (!mIsSoundOn)
        {
            mIsSoundOn = true;
            mSoundEffect.GetComponent<AudioSource>().Play();
        }
    }

    public override void OnPlayerTriggerStay(VRCPlayerApi player)
    {
        if (Input.GetKey("space") || mIsFloating)
        {
            player.SetVelocity(new Vector3(0.0f, 2.0f, 0.0f));
        }

        mSoundEffect.GetComponent<Rigidbody>().position =
            player.GetPosition();
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        mIsExit = true;
    }
}

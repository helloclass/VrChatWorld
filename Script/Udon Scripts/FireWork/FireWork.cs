
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class FireWork : UdonSharpBehaviour
{
    public GameObject mFireParticle;
    ParticleSystem mFirePS;
    Quaternion mOriginRot;
    bool isUsed;

    void Start()
    {
        mFirePS = mFireParticle.GetComponent<ParticleSystem>();
        mOriginRot = GetComponent<Rigidbody>().rotation;
        isUsed = false;
    }

    public override void OnPickup()
    {
        isUsed = true;
    }

    public override void OnDrop()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().rotation = mOriginRot;
        isUsed = false;
    }

    public void Update()
    {
        if (isUsed)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                mFirePS.Play();
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {
                mFirePS.Stop();
            }
        }
    }
}

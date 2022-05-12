
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Wheel : UdonSharpBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


}

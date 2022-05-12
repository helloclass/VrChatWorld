
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class ToggleClickTest : UdonSharpBehaviour
{
    public Toggle tog;

    void Start()
    {
        tog = GameObject.Find("Toggle").GetComponent<Toggle>();
    }

    public override void Interact()
    {
        tog.isOn = !tog.isOn;

        if (!tog.isOn)
        {
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(1.0f, 0.0f, 0.0f));
        }
    }
}

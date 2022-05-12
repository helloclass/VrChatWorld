
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class UdonSlider : UdonSharpBehaviour
{
    private Slider _slider;
    RectTransform rt;

    Vector3 origin;
    Vector3 position;

    void Start()
    {
        _slider = transform.GetComponent<Slider>();
        rt = GameObject.Find("PlayListPanel").GetComponent<RectTransform>();

        origin = rt.position;
    }

    public void UpdateScrollBar()
    {
        position = origin;
        position.y += _slider.value;

        rt.position = position;
    }
}

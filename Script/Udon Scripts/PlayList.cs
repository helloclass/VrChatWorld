
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class PlayList : UdonSharpBehaviour
{
    public Scrollbar bar;
    RectTransform tf;
    float preValue;

    Vector3 position;

    void Start()
    {
        bar.value = 0;
        tf = GetComponent<RectTransform>();
        preValue = 0.0f;
    }

    private void Update()
    {
        position = tf.position;

        preValue = bar.value - preValue;
        position.y += preValue;

        tf.position = position;
    }
}

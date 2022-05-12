
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC;
using VRC.Udon;

public class Camera1 : UdonSharpBehaviour
{
    bool isScreen;
    public GameObject mTarget;
    public GameObject mScreen;
    public Vector3 Offset;

    private void Start()
    {
        isScreen = false;
        mTarget = GameObject.Find("Third Person Cameras");
    }

    private void FixedUpdate()
    {
        if (mTarget.GetComponent<TestCam>().isUsed)
        {
            if (isScreen)
            {
                gameObject.transform.localPosition = Offset;
                gameObject.transform.LookAt(mTarget.transform);
            }

            if (Input.GetKeyDown(KeyCode.F9))
            {
                isScreen = !isScreen;
                mScreen.SetActive(isScreen);
            }
            else if (Input.GetKey(KeyCode.F10))
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                {
                    Offset *= 1.2f;
                }
                else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                    Offset *= 0.8f;
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    Offset.y += 0.1f;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    Offset.y -= 0.1f;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    Offset.x += 0.1f;
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Offset.x -= 0.1f;
                }
            }
        }
    }
}

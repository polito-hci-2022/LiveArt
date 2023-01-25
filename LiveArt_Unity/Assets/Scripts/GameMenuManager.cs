using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class GameMenuManager : MonoBehaviour
{
    public GameObject gameMenuObject;
    public GameObject messageObject;
    public InputActionProperty showButton;

    public TrackedDeviceGraphicRaycaster canvasInteraction1_1;
    public TrackedDeviceGraphicRaycaster canvasInteraction1_2;
    public TrackedDeviceGraphicRaycaster canvasInteraction2_1;
    public TrackedDeviceGraphicRaycaster canvasInteraction3_1;
    public TrackedDeviceGraphicRaycaster canvasInteraction3_2;
    public TrackedDeviceGraphicRaycaster canvasInteraction3_3;
    public TrackedDeviceGraphicRaycaster canvasInteraction4_1;

    public TrackedDeviceGraphicRaycaster canvasInteraction1_1_image;
    public TrackedDeviceGraphicRaycaster canvasInteraction1_2_image;
    public TrackedDeviceGraphicRaycaster canvasInteraction2_1_image;
    public TrackedDeviceGraphicRaycaster canvasInteraction3_1_image;
    public TrackedDeviceGraphicRaycaster canvasInteraction3_2_image;
    public TrackedDeviceGraphicRaycaster canvasInteraction3_3_image;
    public TrackedDeviceGraphicRaycaster canvasInteraction4_1_image;

    public TrackedDeviceGraphicRaycaster canvasInteraction1_1_info;
    public TrackedDeviceGraphicRaycaster canvasInteraction1_2_info;
    public TrackedDeviceGraphicRaycaster canvasInteraction2_1_info;
    public TrackedDeviceGraphicRaycaster canvasInteraction3_1_info;
    public TrackedDeviceGraphicRaycaster canvasInteraction3_2_info;
    public TrackedDeviceGraphicRaycaster canvasInteraction3_3_info;
    public TrackedDeviceGraphicRaycaster canvasInteraction4_1_info;

    public TrackedDeviceGraphicRaycaster canvasInteraction1_1_int;
    public TrackedDeviceGraphicRaycaster canvasInteraction1_2_int;
    public TrackedDeviceGraphicRaycaster canvasInteraction2_1_int;
    public TrackedDeviceGraphicRaycaster canvasInteraction3_1_int;
    public TrackedDeviceGraphicRaycaster canvasInteraction3_2_int;
    public TrackedDeviceGraphicRaycaster canvasInteraction3_3_int;
    public TrackedDeviceGraphicRaycaster canvasInteraction4_1_int;

    public GameObject leftMenu;
    public GameObject rightMenu;

    TrackedDeviceGraphicRaycaster[] canvas;

    void Start()
    {
        TrackedDeviceGraphicRaycaster[] newCanvas =
        {
            canvasInteraction1_1,
            canvasInteraction1_2,
            canvasInteraction2_1,
            canvasInteraction3_1,
            canvasInteraction3_2,
            canvasInteraction3_3,
            canvasInteraction4_1,
            canvasInteraction1_1_image,
            canvasInteraction1_2_image,
            canvasInteraction2_1_image,
            canvasInteraction3_1_image,
            canvasInteraction3_2_image,
            canvasInteraction3_3_image,
            canvasInteraction4_1_image,
            canvasInteraction1_1_info,
            canvasInteraction1_2_info,
            canvasInteraction2_1_info,
            canvasInteraction3_1_info,
            canvasInteraction3_2_info,
            canvasInteraction3_3_info,
            canvasInteraction4_1_info,
            canvasInteraction1_1_int,
            canvasInteraction1_2_int,
            canvasInteraction2_1_int,
            canvasInteraction3_1_int,
            canvasInteraction3_2_int,
            canvasInteraction3_3_int,
            canvasInteraction4_1_int,
        };

        canvas = newCanvas;
    }

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            gameMenuObject.SetActive(!gameMenuObject.activeSelf);
        }
        if (gameMenuObject.activeSelf == true || messageObject.activeSelf == true)
        {
            PlayerPrefs.SetInt("menuOpen", 1);
            setCanvasEnable(false);
        }
        else if (gameMenuObject.activeSelf == false && messageObject.activeSelf == false)
        {
            PlayerPrefs.SetInt("menuOpen", 0);
            setCanvasEnable(true);
        }
        PlayerPrefs.Save();
    }

    public void CloseMenu()
    {
        setCanvasEnable(true);
        gameMenuObject.SetActive(false);
    }

    void setCanvasEnable(bool val)
    {
        foreach (TrackedDeviceGraphicRaycaster el in canvas)
        {
            el.enabled = val;
        }
        int mancini = PlayerPrefs.GetInt("Mancini");
        if (val == true)
        {
            if (mancini == 1)
                rightMenu.SetActive(true);
            else
                leftMenu.SetActive(true);
        }
        else{
                rightMenu.SetActive(false);
                leftMenu.SetActive(false);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScenes : MonoBehaviour
{
    private Camera mainCamera;
    public List<float> sceneXPos;
    public List<GameObject> canvases = new List<GameObject>();

    private void Start()
    {
        mainCamera = Camera.main;
        SwitchScene(3);
    }

    public void SwitchScene(int sceneNum)
    {
        mainCamera.transform.position = new Vector3(sceneXPos[sceneNum], 0, -10);

        for (int i = 0; i < canvases.Count; i++)
        {
            if (i != sceneNum)
            {
                canvases[i].SetActive(false);
            }
            else
            {
                canvases[i].SetActive(true);
            }
        }
    }
}

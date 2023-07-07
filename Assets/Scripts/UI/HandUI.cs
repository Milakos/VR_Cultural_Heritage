using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUI : MonoBehaviour
{
    ButtonActionsController controller;
    [SerializeField] GameObject rightHand;
    public GameObject canvas;

    private void Awake()
    {
        controller = FindObjectOfType<ButtonActionsController>();
    }
    private void OnEnable()
    {
        controller.UIHandCanvas += ActivateHandUI;
    }

    private void OnDisable()
    {
        controller.UIHandCanvas -= ActivateHandUI;
    }

    private void ActivateHandUI(bool setActive)
    {
        canvas.gameObject.SetActive(setActive);
        canvas.transform.position = rightHand.transform.position;
        canvas.transform.rotation = rightHand.transform.rotation;
    }
}

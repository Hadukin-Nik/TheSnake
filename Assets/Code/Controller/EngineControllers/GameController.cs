using System;
using System.Collections;
using System.Collections.Generic;
using Code.Controller;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Controllers _controllers;

    public void SetControllers(Controllers _controller)
    {
        _controllers = _controller;
    }
    void Update()
    {
         _controllers.Execute(Time.deltaTime);
    }

    private void LateUpdate()
    {
        _controllers.LateExecute(Time.deltaTime);
    }
}

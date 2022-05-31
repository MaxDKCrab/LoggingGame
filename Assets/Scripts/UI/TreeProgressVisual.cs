using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class TreeProgressVisual : MonoBehaviour
{
    [SerializeField] private SliderValueHolder progress;
    [SerializeField] private BoolBox interact;
    private Animator anim;
    private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("on", interact.on);
        slider.maxValue = progress.sliderMaxValue;
        slider.value = progress.progress;
    }
}

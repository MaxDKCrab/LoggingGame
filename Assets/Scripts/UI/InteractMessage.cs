using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractMessage : MonoBehaviour
{
    [SerializeField] private BoolBox interact;
    private TextMeshProUGUI textObject;

    private void Start()
    {
        textObject = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textObject.enabled = interact.on;
    }
}

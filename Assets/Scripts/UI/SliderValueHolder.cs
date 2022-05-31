using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Value Holder", menuName = "Slider Value Holder")]
public class SliderValueHolder : ScriptableObject
{
   public float progress;
   public float sliderMaxValue;
}

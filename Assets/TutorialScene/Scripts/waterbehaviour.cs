using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class waterbehaviour : MonoBehaviour
{
    public float maxheight = 20;
    public float time = 1;
    public void RaiseWaterLvl()
    {
        transform.DOScaleY(maxheight, time);
    }
}

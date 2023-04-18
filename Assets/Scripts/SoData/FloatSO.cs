using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [Brough, Heath]
// [4/17/2023]
// used to store the coin value throughout scenes
[CreateAssetMenu]
public class FloatSO : ScriptableObject
{
    // I followed a tutorial on this one so I do not know what serialize field does
    [SerializeField]
    // the value to be stored
    private float _Value;

    public float Value
    {
        get { return _Value; }
        set { _Value = value; }
    }

}

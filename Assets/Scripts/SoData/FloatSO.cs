using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatSO : ScriptableObject
{
    [SerializeField]
    private float _Value;

    public float Value
    {
        get { return _Value; }
        set { _Value = value; }
    }

}

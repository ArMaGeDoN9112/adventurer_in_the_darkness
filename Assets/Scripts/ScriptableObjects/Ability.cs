using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string name;
    public float cooldownTime;
    public KeyCode key;

    public virtual void Activate(GameObject gameObject) { }
    public virtual void BeginCooldowm(GameObject gameObject) { }
}

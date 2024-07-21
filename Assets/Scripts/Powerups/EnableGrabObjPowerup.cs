using UnityEngine;

public class EnavleGrabObjPowerup : MonoBehaviour, IPowerup
{
    public void Apply(GameObject target)
    {
        target.GetComponent<GrabObject>().abilityEnabled = true;
    }
}
using UnityEngine;


public class AbilityHolder : MonoBehaviour
{
    [SerializeField] public Ability[] abilities;
    private float[] timeTillCooldown;

    public enum AbilityState
    {
        ready,
        cooldown
    }
    public AbilityState[] abilityState;

    private void Awake()
    {
        abilityState = new AbilityState[abilities.Length];
        timeTillCooldown = new float[abilities.Length];
        for (int i = 0; i < abilities.Length; i++)
        {
            abilityState[i] = AbilityState.ready;
            timeTillCooldown[i] = 0;
        }
    }

    void Update()
    {
        if (abilities.Length == 0) return;

        for (int i = 0; i < abilities.Length; i++)
        {
            switch (abilityState[i])
            {
                case AbilityState.ready:
                    if (Input.GetKeyDown(abilities[i].key))
                    {
                        abilities[i].Activate(gameObject);
                        abilityState[i] = AbilityState.cooldown;
                    }
                    break;
                case AbilityState.cooldown:
                    if (timeTillCooldown[i] < abilities[i].cooldownTime)
                    {
                        timeTillCooldown[i] += Time.deltaTime;
                    }
                    else
                    {
                        abilityState[i] = AbilityState.ready;
                        timeTillCooldown[i] = 0;
                    }
                    break;
            }
        }
    }



}
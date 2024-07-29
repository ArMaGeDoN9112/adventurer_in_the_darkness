using UnityEngine;



[CreateAssetMenu(fileName = "MeleeAttack", menuName = "Abilities/MeleeAttack")]
public class MeleeAttackAbility : Ability
{
    private MeleeAttack _meleeAttack;
    public override void Activate(GameObject parent)
    {
        _meleeAttack = parent.GetComponent<MeleeAttack>();
        _meleeAttack.BeginAttack();
    }

    public override void BeginCooldowm(GameObject parent)
    {
    }
}
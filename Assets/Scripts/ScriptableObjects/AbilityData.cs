using UnityEngine;

[CreateAssetMenu(fileName = "AbilityPreviewData", menuName = "Abilities/PreviewUI")]
public class AbilityData : ScriptableObject
{
    public Sprite AbilityPreview;
    public Sprite usedAbilityPreview;
    public Sprite ButtonPreview;
    public int CorrespondingAbilityIndex;
    public ScriptableObject ability;
}

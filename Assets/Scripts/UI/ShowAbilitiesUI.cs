using UnityEngine;
using UnityEngine.UI;

public class ShowAbilitiesUI : MonoBehaviour
{
    [Header("Abilities Data")]
    [SerializeField] private AbilityData[] _abilitiesData;

    [Header("UI fields")]
    [SerializeField] private Canvas _prefab;
    [SerializeField] private AbilityHolder _abilitiesHolder;
    private Canvas child;
    private Image _AbilityPreview;
    private Image _ButtonPreview;

    private void OnEnable()
    {
        for (int i = 0; i < _abilitiesData.Length; i++)
        {
            child = Instantiate(_prefab);
            child.transform.SetParent(transform);

            _AbilityPreview = child.transform.Find("AbilityPreview").GetComponent<Image>();
            _ButtonPreview = child.transform.Find("ButtonPreview").GetComponent<Image>();

            _AbilityPreview.sprite = _abilitiesData[i].AbilityPreview;
            _ButtonPreview.sprite = _abilitiesData[i].ButtonPreview;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _abilitiesData.Length; i++)
        {
            var state = _abilitiesHolder.abilityState[i];
            _AbilityPreview = transform.GetChild(i).Find("AbilityPreview").GetComponent<Image>();

            if (state == AbilityHolder.AbilityState.cooldown)
            {
                _AbilityPreview.sprite = _abilitiesData[i].usedAbilityPreview;
            }
            else
            {
                _AbilityPreview.sprite = _abilitiesData[i].AbilityPreview;
            }
        }
    }

    // private void ShowAbility(GameObject child)
    // {
    //     child.sprite = _abilitiesData[index].AbilityPreview;
    //     child.sprite = _abilitiesData[index].ButtonPreview;
    // }
}
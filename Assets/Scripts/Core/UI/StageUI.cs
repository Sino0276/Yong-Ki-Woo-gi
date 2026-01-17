using TMPro;
using UnityEngine;

public class StageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private TextMeshProUGUI countText;

    public void Start()
    {
        stageText.text = Managers.User.Stage.CurrentStage.Value.ToString();
        countText.text = Managers.User.Stage.CurrentCount.Value.ToString() + "/10";

        Managers.User.Stage.CurrentStage.OnValueChange += OnStageValueChange;
        Managers.User.Stage.CurrentCount.OnValueChange += OnCountValueChange;
    }

    private void OnStageValueChange(int oldValue, int newValue)
    {
        stageText.text = newValue.ToString();
    }

    private void OnCountValueChange(int oldValue, int newValue)
    {
        countText.text = newValue.ToString() + "/10";
    }
}

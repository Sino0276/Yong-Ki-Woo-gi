using TMPro;
using UnityEngine;

public class StageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private TextMeshProUGUI countText;

    public void FixedUpdate()
    {
        stageText.text = Managers.User.Stage.CurrentStage.ToString();
        countText.text = Managers.User.Stage.CurrentCount.ToString() + "/10";
    }
}

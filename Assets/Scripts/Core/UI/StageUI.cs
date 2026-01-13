using TMPro;
using UnityEngine;

public class StageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private TextMeshProUGUI countText;

    public void FixedUpdate()
    {
        stageText.text = Managers.UserData.stageData.stage.ToString();
        countText.text = Managers.UserData.stageData.count.ToString() + "/10";
    }
}

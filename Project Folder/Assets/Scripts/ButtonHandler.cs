using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Button separateButton;
    public MoveUpWithSeparation[] moveUpComponents;
    public MoveDownWithSeparation[] moveDownComponents;

    void Start()
    {
        separateButton.onClick.AddListener(OnSeparateButtonClick);
    }

    void OnSeparateButtonClick()
    {
        foreach (var component in moveUpComponents)
        {
            component.Move();
        }
        foreach (var component in moveDownComponents)
        {
            component.Move();
        }
    }
}

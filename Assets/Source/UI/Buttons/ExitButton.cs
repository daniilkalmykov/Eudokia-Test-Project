using UnityEngine;

namespace UI.Buttons
{
    public sealed class ExitButton : GameButton
    {
        protected override void OnClick()
        {
            Application.Quit();
        }
    }
}
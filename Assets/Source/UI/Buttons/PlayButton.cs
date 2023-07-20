using Enums;
using UnityEngine.SceneManagement;

namespace UI.Buttons
{
    public sealed class PlayButton : GameButton
    {
        protected override void OnClick()
        {
            SceneManager.LoadScene(SceneName.Level.ToString());
        }
    }
}
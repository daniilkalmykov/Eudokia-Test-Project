using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public sealed class QuitButton : GameButton
    {
        [SerializeField] private Image _image;
        
        protected override void OnClick()
        {
            _image.gameObject.SetActive(false);
        }
    }
}
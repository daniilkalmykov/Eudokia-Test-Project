using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public sealed class ScoreButton : GameButton
    {
        [SerializeField] private Image _image;
        
        protected override void OnClick()
        {
            _image.gameObject.SetActive(true);
        }
    }
}
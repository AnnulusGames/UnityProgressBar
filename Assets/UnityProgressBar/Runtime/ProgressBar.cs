using UnityEngine;
using UnityEngine.UI;

namespace UnityProgressBar
{
    [AddComponentMenu("UI/Progress Bar")]
    public sealed class ProgressBar : ProgressBarBase
    {
        public enum FillMode
        {
            FillAmount,
            Stretch
        }

        enum Direction
        {
            LeftToRight,
            RightToLeft,
            BottomToTop,
            TopToBottom
        }

        enum Axis
        {
            Horizontal,
            Vertical
        }


        [SerializeField] FillMode fillMode;
        [SerializeField] Image fillImage;
        [SerializeField] Direction direction;
        [SerializeField] RectTransform fillRect;

        public RectTransform FillRect
        {
            get => fillRect;
            set => fillRect = value;
        }

        public Image FillImage
        {
            get => fillImage;
            set => fillImage = value;
        }

        protected override void OnValueChangedCore(float value)
        {
            switch (fillMode)
            {
                case FillMode.FillAmount:
                    fillImage.fillAmount = GetNormalizedValue();
                    break;
                case FillMode.Stretch:
                    var zero = Vector2.zero;
                    var one = Vector2.one;

                    if (direction == Direction.RightToLeft || direction == Direction.TopToBottom)
                    {
                        zero[(int)DirectionToAxis()] = 1f - GetNormalizedValue();
                    }
                    else
                    {
                        one[(int)DirectionToAxis()] = GetNormalizedValue();
                    }

                    fillRect.anchorMin = zero;
                    fillRect.anchorMax = one;
                    break;
            }
        }

        Axis DirectionToAxis()
        {
            return (direction != Direction.LeftToRight && direction != Direction.RightToLeft) ? Axis.Vertical : Axis.Horizontal;
        }
    }
}
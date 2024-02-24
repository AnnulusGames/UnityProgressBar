using UnityEngine;
using UnityEngine.Events;

namespace UnityProgressBar
{
    public abstract class ProgressBarBase : MonoBehaviour
    {
        [SerializeField] float minValue = 0f;
        [SerializeField] float maxValue = 1f;
        [SerializeField] float value = 0f;
        [SerializeField] UnityEvent<float> onValueChanged;

        public float MinValue
        {
            get => minValue;
            set
            {
                minValue = value;
                if (Value < minValue) Value = minValue;
            }
        }

        public float MaxValue
        {
            get => maxValue;
            set
            {
                maxValue = value;
                if (Value > maxValue) Value = maxValue;
            }
        }

        public float Value
        {
            get
            {
                return value;
            }
            set
            {
                SetValueCore(value);
            }
        }

        public UnityEvent<float> OnValueChanged => onValueChanged;

        protected virtual void OnValueChangingCore(ref float value) { }
        protected virtual void OnValueChangedCore(float value) { }

        public void SetValueWithoutNotify(float value)
        {
            OnValueChangingCore(ref value);
            this.value = value;
            OnValueChangedCore(value);
        }

        public void ForceNotify()
        {
            SetValueCore(value);
        }

        void SetValueCore(float value)
        {
            OnValueChangingCore(ref value);
            this.value = value;
            OnValueChangedCore(value);

            onValueChanged.Invoke(value);
        }

        protected float GetNormalizedValue()
        {
            return Mathf.InverseLerp(MinValue, MaxValue, value);
        }
    }
}
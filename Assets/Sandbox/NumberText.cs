using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class NumberText : MonoBehaviour
{
    public void SetValue(float value)
    {
        Debug.Log(value);
        GetComponent<Text>().text = value.ToString("F0");
    }
}

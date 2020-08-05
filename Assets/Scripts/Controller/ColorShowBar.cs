using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 运行时颜色显示条
/// </summary>
public class ColorShowBar : MonoBehaviour
{
    public Image RGBImg; //RGB显示图
    public Slider AlphaSlider; //透明度比例条

    /// <summary>
    /// 设置颜色
    /// </summary>
    /// <param name="color"></param>
    public void SetColor(Color color)
    {
        AlphaSlider.value = color.a;
        color.a = 1.0f;
        RGBImg.color = color;
    }

    /// <summary>
    /// 设置颜色
    /// </summary>
    /// <param name="color"></param>
    public void SetColor32(Color32 color)
    {
        AlphaSlider.value = color.a / 255;
        color.a = 255;
        RGBImg.color = color;
    }
}
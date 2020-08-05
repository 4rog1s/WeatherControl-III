using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 控制面板
/// </summary>
public class ControllerCanvas : MonoBehaviour
{
    /// <summary>
    /// 用于存储数据的Json类
    /// </summary>
    [Serializable]
    public class ValueRecorder
    {
        public float RainScale = 50; //雨势范围
        public float RainForce = 0; //雨势大小
        public float CloudScale = 50; //云势范围
        public float CloudSpeed = 20; //云速度
        public Color CloudPeekColor = new Color32(228, 236, 241, 9); //云峰颜色
        public Color CloudValleyColor = new Color32(187, 207, 217, 0); //云谷颜色
    }

    public MeshRenderer CloudRenderer; //云渲染组件
    public ParticleSystem RainParticle; //雨粒子特效

    public Button LoadValueBtn; //加载按钮
    public Button SaveValueBtn; //保存按钮

    /// <summary>
    /// 雨势范围相关组件
    /// </summary>
    [Space]
    public Slider RainScaleSlider;
    public InputField RainScaleInputField;
    public Text RainScaleValue;

    /// <summary>
    /// 雨势大小相关组件
    /// </summary>
    [Space]
    public Slider RainForceSlider;
    public InputField RainForceInputField;
    public Text RainForceValue;

    /// <summary>
    /// 云势范围相关组件
    /// </summary>
    [Space]
    public Slider CloudScaleSlider;
    public InputField CloudScaleInputField;
    public Text CloudScaleValue;

    /// <summary>
    /// 云速度相关组件
    /// </summary>
    [Space]
    public Slider CloudSpeedSlider;
    public InputField CloudSpeedInputField;
    public Text CloudSpeedValue;

    /// <summary>
    /// 云峰颜色板组件
    /// </summary>
    [Space]
    public ColorPicker CloudPeekColorPicker;

    /// <summary>
    /// 云谷颜色板组件
    /// </summary>
    [Space]
    public ColorPicker CloudValleyColorPicker;

    private ValueRecorder m_ValueRecorder;
    private string m_FileName = "RainCloudRecorder.json";

    private void Awake()
    {
        m_ValueRecorder = new ValueRecorder();
        SetRecorderValue(); //设置默认值

        //添加监听
        LoadValueBtn.onClick.AddListener(ReadJson);
        SaveValueBtn.onClick.AddListener(WriteJson);

        //OnRainScaleChanged(RainScaleSlider.value);
        RainScaleSlider.onValueChanged.AddListener(OnRainScaleChanged);
        RainScaleInputField.onEndEdit.AddListener(OnRainScaleEditChanged);

        //OnRainForceChanged(RainForceSlider.value);
        RainForceSlider.onValueChanged.AddListener(OnRainForceChanged);
        RainForceInputField.onEndEdit.AddListener(OnRainForceEditChanged);

        //OnCloudScaleChanged(CloudScaleSlider.value);
        CloudScaleSlider.onValueChanged.AddListener(OnCloudScaleChanged);
        CloudScaleInputField.onEndEdit.AddListener(OnCloudScaleEditChanged);

        //OnCloudSpeedChanged(CloudSpeedSlider.value);
        CloudSpeedSlider.onValueChanged.AddListener(OnCloudSpeedChanged);
        CloudSpeedInputField.onEndEdit.AddListener(OnCloudSpeedEditChanged);

        CloudPeekColorPicker.onValueChanged.AddListener(OnColorPeekColorValueChanged);

        CloudValleyColorPicker.onValueChanged.AddListener(OnColorValleyColorValueChanged);
    }

    #region 雨势范围

    /// <summary>
    /// 滑动条值变化的事件注册方法
    /// </summary>
    /// <param name="arg0"></param>
    private void OnRainScaleChanged(float arg0)
    {
        RainScaleValue.text = arg0.ToString();
        RainParticle.transform.localScale = Vector3.one * arg0 / 50;
        m_ValueRecorder.RainScale = arg0;
        RainScaleInputField.text = arg0.ToString();
    }

    /// <summary>
    /// 输入框完成编辑事件注册方法
    /// </summary>
    /// <param name="arg0"></param>
    private void OnRainScaleEditChanged(string arg0)
    {
        if (float.TryParse(arg0, out float result))
        {
            if (result < RainScaleSlider.minValue)
            {
                result = RainScaleSlider.minValue;
            }
            else
            {
                if (result > RainScaleSlider.maxValue)
                {
                    result = RainScaleSlider.maxValue;
                }
            }

            RainScaleSlider.value = result;
        }
    }

    #endregion

    #region 雨势大小

    private void OnRainForceChanged(float arg0)
    {
        RainForceValue.text = arg0.ToString();
        ParticleSystem.MainModule main = RainParticle.main;
        main.maxParticles = (int)arg0 * 1000;
        m_ValueRecorder.RainForce = arg0;
        RainForceInputField.text = arg0.ToString();
    }

    private void OnRainForceEditChanged(string arg0)
    {
        if (float.TryParse(arg0, out float result))
        {
            if (result < RainForceSlider.minValue)
            {
                result = RainForceSlider.minValue;
            }
            else
            {
                if (result > RainForceSlider.maxValue)
                {
                    result = RainForceSlider.maxValue;
                }
            }

            RainForceSlider.value = result;
        }
    }

    #endregion

    #region 云势范围

    private void OnCloudScaleChanged(float arg0)
    {
        CloudScaleValue.text = arg0.ToString();
        CloudRenderer.transform.localScale = Vector3.one * arg0 / 100;
        m_ValueRecorder.CloudScale = arg0;
        CloudScaleInputField.text = arg0.ToString();
    }

    private void OnCloudScaleEditChanged(string arg0)
    {
        if (float.TryParse(arg0, out float result))
        {
            if (result < CloudScaleSlider.minValue)
            {
                result = CloudScaleSlider.minValue;
            }
            else
            {
                if (result > CloudScaleSlider.maxValue)
                {
                    result = CloudScaleSlider.maxValue;
                }
            }

            CloudScaleSlider.value = result;
        }
    }

    #endregion

    #region 云速度

    private void OnCloudSpeedChanged(float arg0)
    {
        CloudSpeedValue.text = arg0.ToString();
        CloudRenderer.material.SetFloat("Vector1_FCFE8EBC", arg0);
        m_ValueRecorder.CloudSpeed = arg0;
        CloudSpeedInputField.text = arg0.ToString();
    }

    private void OnCloudSpeedEditChanged(string arg0)
    {
        if (float.TryParse(arg0, out float result))
        {
            if (result < CloudSpeedSlider.minValue)
            {
                result = CloudSpeedSlider.minValue;
            }
            else
            {
                if (result > CloudSpeedSlider.maxValue)
                {
                    result = CloudSpeedSlider.maxValue;
                }
            }

            CloudSpeedSlider.value = result;
        }
    }

    #endregion

    #region 云峰颜色

    private void OnColorPeekColorValueChanged(Color arg0)
    {
        m_ValueRecorder.CloudPeekColor = arg0;
        CloudRenderer.material.SetColor("Color_64B2D229", arg0);
    }

    #endregion

    #region 云谷颜色

    private void OnColorValleyColorValueChanged(Color arg0)
    {
        m_ValueRecorder.CloudValleyColor = arg0;
        CloudRenderer.material.SetColor("Color_FA9CE866", arg0);
    }

    #endregion

    /// <summary>
    /// json写入
    /// </summary>
    private void WriteJson()
    {
        string path = GetPath();

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path.Replace(m_FileName, ""));
        }
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }

        FileStream stream = File.Open(path, FileMode.Truncate, FileAccess.Write);

        var writer = new StreamWriter(stream);

        writer.WriteLine(JsonUtility.ToJson(m_ValueRecorder));

        writer.Close();
        stream.Close();
    }

    /// <summary>
    /// 读取Json
    /// </summary>
    private void ReadJson()
    {
        string path = GetPath();
        m_ValueRecorder = new ValueRecorder();

        if (File.Exists(path))
        {
            FileStream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var reader = new StreamReader(stream);

            string data = reader.ReadLine();

            stream.Close();
            reader.Close();

            if (data != null && data.Length > 0)
            {
                m_ValueRecorder = JsonUtility.FromJson<ValueRecorder>(data);
            }
        }

        SetRecorderValue();
    }

    /// <summary>
    /// 设置值
    /// </summary>
    private void SetRecorderValue()
    {
        OnRainScaleEditChanged(m_ValueRecorder.RainScale.ToString());
        OnRainForceEditChanged(m_ValueRecorder.RainForce.ToString());
        OnCloudScaleEditChanged(m_ValueRecorder.CloudScale.ToString());
        OnCloudSpeedEditChanged(m_ValueRecorder.CloudSpeed.ToString());
        CloudPeekColorPicker.InvokeChanedEvent(m_ValueRecorder.CloudPeekColor);
        CloudValleyColorPicker.InvokeChanedEvent(m_ValueRecorder.CloudValleyColor);
    }

    /// <summary>
    /// 获取路径
    /// </summary>
    /// <returns></returns>
    private string GetPath()
    {
        return FileUtility.File.GetDataPath() + m_FileName;
    }
}
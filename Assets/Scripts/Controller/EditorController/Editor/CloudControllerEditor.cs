using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CloudController))]
public class CloudControllerEditor : Editor
{
    private CloudController m_CloudController;
    private Vector3 m_PrimaryLocalScale;
    private MeshRenderer m_CloudRenderer;

    private void OnEnable()
    {
        m_CloudController = target as CloudController;
        m_CloudRenderer = m_CloudController.GetComponent<MeshRenderer>();
        if (m_CloudRenderer == null)
        {
            throw new ArgumentNullException("此脚本挂载的物体上没有找到云的渲染组件，请检查！");
        }
        m_PrimaryLocalScale = m_CloudController.transform.localScale;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        m_CloudController.ModifyCloudScale(m_PrimaryLocalScale);
        //m_CloudController.ModifyFlowSpeed();
    }
}
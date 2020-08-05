using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RainController))]
public class RainControllerEditor : Editor
{
    private RainController m_RainController;
    private Vector3 m_PrimaryLocalScale;
    private ParticleSystem m_RainParticle;

    private void OnEnable()
    {
        m_RainController = target as RainController;
        m_RainParticle = m_RainController.GetComponent<ParticleSystem>();
        if (m_RainParticle == null)
        {
            throw new ArgumentNullException("此脚本挂载的物体上没有找到雨的粒子特效，请检查！");
        }
        m_PrimaryLocalScale = m_RainController.transform.localScale;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        m_RainController.ModifyRainScale(m_PrimaryLocalScale);
        m_RainController.ModifyRainForce(m_RainParticle.main);
    }
}
using UnityEngine;

public class RainController : MonoBehaviour
{
    [SerializeField, Tooltip("雨势大小")] protected int m_RainForce = 10000;
    [SerializeField, Tooltip("雨势范围")] private float m_RainScale = 1.0f;

    public float RainForce => m_RainForce;
    public float RainScale => m_RainScale;

    public void ModifyRainScale(Vector3 primaryLocalScale)
    {
        transform.localScale = new Vector3(primaryLocalScale.x * m_RainScale, primaryLocalScale.y, primaryLocalScale.z * m_RainScale);
    }

    public void ModifyRainForce(ParticleSystem.MainModule particleSystem)
    {
        particleSystem.maxParticles = m_RainForce;
    }
}
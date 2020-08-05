using UnityEngine;

[ExecuteAlways]
public class CloudController : MonoBehaviour
{
    [SerializeField, Tooltip("云团范围")] private float m_CloudScale = 1.0f;

    public float CloudScale => m_CloudScale;

    public void ModifyCloudScale(Vector3 primaryLocalScale)
    {
        transform.localScale = new Vector3(primaryLocalScale.x * m_CloudScale, primaryLocalScale.y, primaryLocalScale.z * m_CloudScale);
    }
}
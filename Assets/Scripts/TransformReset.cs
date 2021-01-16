using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformReset : MonoBehaviour
{
    private Vector3 m_CachedPosition;
    private Vector3 m_CachedRotation;

    void Awake()
    {
        m_CachedPosition = transform.localPosition;
        m_CachedRotation = transform.localEulerAngles;
    }

    public void ResetTransform()
    {
        Animation animation = GetComponent<Animation>();
        if (animation != null)
            animation.Stop();
        transform.localPosition = m_CachedPosition;
        transform.localEulerAngles = m_CachedRotation;
    }
}

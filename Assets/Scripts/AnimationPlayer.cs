using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public void PlayAnimation()
    {
        GetComponent<Animation>()?.Play();
    }
}

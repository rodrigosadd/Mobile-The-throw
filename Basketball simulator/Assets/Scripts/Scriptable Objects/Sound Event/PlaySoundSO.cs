using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlaySound", menuName = "ScriptableObjects/Play Sound")]
public class PlaySoundSO : ScriptableObject
{
    public UnityAction<SoundSO> OnPlaySound;

    public void RaiseEvent(SoundSO sound)
    {
        OnPlaySound?.Invoke(sound);
    }
}


using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class postprocessing : MonoBehaviour
{
    public PostProcessVolume volume;
    [SerializeField] private static Vignette vig;
    [SerializeField] private static ChromaticAberration ca;

    void Start()
    {
        volume.profile.TryGetSettings(out vig);
        volume.profile.TryGetSettings(out ca);
    }

    public static void Change()
    {
        vig.color.value = new Color(255, 0, 0, 255);
        vig.intensity.value = 0.118f;
        vig.smoothness.value = 0.166f;
        ca.intensity.value = 1f;
    }
    public static void ChangeBack()
    {
        vig.color.value = new Color(255, 255, 255, 255);
        vig.intensity.value = 0;
        vig.smoothness.value = 0.01f;
        ca.intensity.value = 0;
    }
}
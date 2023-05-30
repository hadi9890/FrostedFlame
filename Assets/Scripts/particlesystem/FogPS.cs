
using UnityEngine;

public class FogPS : MonoBehaviour
{
    public static FogPS fog;
    public GameObject particleSys;
    private ParticleSystem.MainModule ps;
    private ParticleSystem.EmissionModule pse;
    private ParticleSystem.ShapeModule pss;

    // Start is called before the first frame update
    void Start()
    {
        ps = particleSys.GetComponentInChildren<ParticleSystem>().main;
        pse = particleSys.GetComponentInChildren<ParticleSystem>().emission;
        pss = particleSys.GetComponentInChildren<ParticleSystem>().shape;

        SetPS();
    }

    void SetPS()
    {
        ps.startColor = new Color(173, 173, 173, 180);
        ps.startLifetime = 5;
        ps.startSizeXMultiplier = 240;
        ps.startSizeYMultiplier = 240;
        ps.startSizeZMultiplier = 240;
        ps.simulationSpeed = 1;
        ps.loop = true;
        // ps.duration = 5.3f;
        ps.startSpeed = 2;
        ps.maxParticles = 1000;

        pse.rateOverTime = 1000000000;
        pse.rateOverDistance = 1;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class VFXRandomizer : MonoBehaviour
{

    [SerializeField]
    private VisualEffect visualEffect;

    [SerializeField]
    private Vector3 fieldTransformCenter;

    [SerializeField]
    private Vector3 fieldTransformAngles;

    [SerializeField]
    private Vector3 fieldTransformSize;

    [SerializeField, Range(1, 20)]
    private float fieldTransformIntensity;

    [SerializeField, Range(0.1f, 10)]
    private float fieldTransformDrag;

    [SerializeField]
    private float setSize;

    [SerializeField]
    private float setScaleX;

    [SerializeField]
    private float setLifetimeRandomMax;

    [SerializeField]
    private int constantSpawnRate;

    [SerializeField]
    private Gradient colorGradient;


    void Start()
    {
        transform.position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-2.0f, 2.0f), Random.Range(-10.0f, 5.0f));
        fieldTransformCenter = new Vector3(Random.Range(-15, 15), Random.Range(-8, 8), 0);
        fieldTransformAngles = new Vector3(Random.Range(0, 359), Random.Range(0, 359), Random.Range(0, 359));
        fieldTransformSize = new Vector3(Random.Range(0.01f, 10), Random.Range(0.01f, 10), Random.Range(0.01f, 10));
        fieldTransformIntensity = Random.Range(1, 20);
        fieldTransformDrag = Random.Range(0.1f, 10);
        setSize = 1; ;
        setScaleX = 0.03f;
        setLifetimeRandomMax = Random.Range(3, 10);
        constantSpawnRate = Random.Range(5000, 100000);
        colorGradient = GenerateGradient();

        visualEffect.SetVector3("fieldTransformAngles", fieldTransformAngles);
        visualEffect.SetVector3("fieldTransformCenter", fieldTransformCenter);
        visualEffect.SetVector3("fieldTransformSize", fieldTransformSize);
        visualEffect.SetFloat("fieldTransformIntensity", fieldTransformIntensity);
        visualEffect.SetFloat("fieldTransformDrag", fieldTransformDrag);
        visualEffect.SetFloat("setSize", setSize);
        visualEffect.SetFloat("setScaleX", setScaleX);
        visualEffect.SetFloat("setLifetimeRandomMax", setLifetimeRandomMax);
        visualEffect.SetInt("constantSpawnRate", constantSpawnRate);
        visualEffect.SetGradient("colorGradient", colorGradient);


    }


    private Gradient GenerateGradient()
    {
        Gradient gradient;
        GradientColorKey[] colorKey;
        GradientAlphaKey[] alphaKey;

        gradient = new Gradient();

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[3];
        colorKey[0].color = GenerateColor();
        colorKey[0].time = 0.0f;
        colorKey[1].color = GenerateColor();
        colorKey[1].time = 0.5f;
        colorKey[2].color = GenerateColor();
        colorKey[2].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[3];
        alphaKey[0].alpha = Random.Range(0.0f, 1.0f);
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = Random.Range(0.0f, 1.0f);
        alphaKey[1].time = 0.5f;
        alphaKey[2].alpha = Random.Range(0.0f, 1.0f);
        alphaKey[2].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);

        return gradient;


    }

    private Color GenerateColor()
    {
        Color finalColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        return finalColor;
    }
}

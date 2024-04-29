using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif
using UnityEngine;

[ExecuteInEditMode]
public class EtoileRendererParameters : MonoBehaviour
{
    [SerializeField] private bool enableBeacon = true;
    
    [Header("Component Links")] [SerializeField]
    private ParticleSystem[] particles;

    [SerializeField]
    private GameObject beacon;

#if UNITY_EDITOR
    private void Update()
    {
        if (Application.isPlaying) return;
        
        if (!transform.hasChanged) return;


        foreach (ParticleSystem particle in particles)
        {
            ParticleSystem.ShapeModule shape = particle.shape;
            ParticleSystem.VelocityOverLifetimeModule velocity = particle.velocityOverLifetime;
            ParticleSystem.TrailModule trails = particle.trails;

            shape.scale = new Vector3(0f, 0f, transform.localScale.x / 10f);
            velocity.speedModifier = transform.localScale.x / 5f;
            trails.widthOverTrailMultiplier = transform.localScale.x / 5f;
           
            PrefabUtility.RecordPrefabInstancePropertyModifications(particle.gameObject);
        
        }
    }

    private void OnValidate()
    {
        beacon.SetActive(enableBeacon);

        PrefabUtility.RecordPrefabInstancePropertyModifications(beacon.gameObject);
    }
#endif
}
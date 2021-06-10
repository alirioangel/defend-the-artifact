using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactHealthUI : MonoBehaviour
{

    [SerializeField] private Slider artifactHealthSlider;
    [SerializeField] private ArtifactController artifact;

    private void Start()
    {
        artifactHealthSlider.maxValue = artifact.maximumArtifactHealth;
        artifactHealthSlider.value = artifact.maximumArtifactHealth;
    }

    private void Update()
    {
        artifactHealthSlider.value = artifact.artifactHealth;

    }
}

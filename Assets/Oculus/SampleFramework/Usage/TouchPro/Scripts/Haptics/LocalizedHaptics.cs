// (c) Meta Platforms, Inc. and affiliates. Confidential and proprietary.

using UnityEngine;

public class LocalizedHaptics : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private OVRInput.Handedness m_handedness = OVRInput.Handedness.LeftHanded;

    private OVRInput.Controller m_controller;
    public float defaultAmplitude = 0.2f;
    public float defaultDuration = 0.5f;
    
    [ContextMenu(itemName:"Send Haptics")]
    public void SendHaptics(){
        float handAmp = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, m_controller) > 0.5f ? 1f : 0f;
        OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsLocation.Hand, 0.0001f, 10f, m_controller);
        Debug.Log("bzzz now");
    }
    private void Start()
    {
        m_controller = m_handedness == OVRInput.Handedness.LeftHanded ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
        // LocalizedHaptics vib;
        // vib = GameObject.FindGameObjectWithTag("vibrate").GetComponent<LocalizedHaptics>();
        // vib.LocalizedHaptics.SendHaptics();
        SendHaptics();
    }

    private void OnTriggerEnter(Collider other)
    {
        SendHaptics();
        // public struct HapticsAmplitudeEnvelopeVibration
        // {
        //     public int SamplesCount;
        //     public float[] Samples;
        //     public float Duration;
        // // }
        // float[] samples = {1f, 0.20f, 00.30f, 1f};
        // OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsAmplitudeEnvelopeVibration( 
        //                                             4,
        //                                            samples, 
        //                                             0.1f));
        //OVRInput.SendHapticImpulse(0u, defaultAmplitude, defaultDuration);
    }

    private void Update()
    {
        // Build vibration for the frame based on device inputs
        //float thumbAmp = OVRInput.Get(OVRInput.Axis1D.PrimaryThumbRestForce, m_controller) > 0.5f ? 1f : 0f;
        //OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsLocation.Thumb, 0f, thumbAmp, m_controller);

        //float indexAmp = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, m_controller) > 0.5f ? 1f : 0f;
        //OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsLocation.Index, 0f, indexAmp, m_controller);

        //float handAmp = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, m_controller) > 0.5f ? 1f : 0f;
        //OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsLocation.Hand, 0f, handAmp, m_controller);
        
       
    }

    
}

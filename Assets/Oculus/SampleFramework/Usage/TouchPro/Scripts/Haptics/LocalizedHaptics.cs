// (c) Meta Platforms, Inc. and affiliates. Confidential and proprietary.

using UnityEngine;

public class LocalizedHaptics : MonoBehaviour
{
    [Header("Settings")] //This is the default code that was originally in the file
    //[SerializeField] private OVRInput.Handedness m_handedness = OVRInput.Handedness.RightHanded; //This is the default code that was originally in the file

    private OVRInput.Controller m_controller; //This is the default code that was originally in the file
    //public Collider mugCollider;
    //public Collider deskCollider;
    public bool isGrabbed;
    public bool isHit;


    public void Grab() //Object has been grabbed
    {
        if (isGrabbed == false)
        {
            isGrabbed = true;
        }
    }

    public void Drop() //Object has been dropped
    {
        if (isGrabbed == true)
        {
            isGrabbed = false;
        }
    }

    public void Hit()
    {
        if (isHit == false)
        {
            isHit = true;
        }
    }

    public void Leave()
    {
        if (isHit == true)
        {
            isHit = false;
        }
    }

    private void Start()
    {
        // --------------This is the default code that was originally in the file ---------------------------
        //m_controller = m_handedness == OVRInput.Handedness.LeftHanded ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
        m_controller = OVRInput.Controller.RTouch;
        isGrabbed = false;
        isHit = false;
    }

    private void Update()
    {
        // Build vibration for the frame based on device inputs
        // --------------This is the default code that was originally in the file ---------------------------
        /*float thumbAmp = OVRInput.Get(OVRInput.Axis1D.PrimaryThumbRestForce, m_controller) > 0.5f ? 1f : 0f;
        OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsLocation.Thumb, 0f, thumbAmp, m_controller);

        float indexAmp = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, m_controller) > 0.5f ? 1f : 0f;
        OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsLocation.Index, 0f, indexAmp, m_controller);

        float handAmp = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, m_controller) > 0.5f ? 1f : 0f;
        OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsLocation.Hand, 0f, handAmp, m_controller);   */

        float handAmp = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, m_controller) > 0.5f ? 1f : 0f;

        if (isGrabbed == true)
        {
            OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsLocation.Hand, 0.1f, 0.6f, m_controller);
        }
        else if (isHit == true)
        {
            OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsLocation.Hand, 0.1f, 0.2f, m_controller);
        }

        if (isGrabbed == false)
        {
            OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsLocation.Hand, 0.0f, 0.0f, m_controller);
        }
        else if (isHit == false)
        {
            OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsLocation.Hand, 0.0f, 0.0f, m_controller);
        }
    }
}

# VR Tactile test

To run the scene, open the project in the correct Unity version and open the scene Assets/VRexperiment/VRSeriousTest-v10 . The right controller should be attached to a mug and the Guardian should be set to desktop.

Hacked together with the following assets for Prof. Teather's VR class Winter 2023
Rodolfo Cossovich
Andrew Thompson
Shagha Kalantari

## Tech requirements:
    - Unity 2021.3.21f1 with an Oculus Quest 2 (Dev mode) to run tethered
    - Oculus XR Plugin 3.2.3
    - OpenXR Plugin 1.6.0
    - XR Hands 1.1.0
    - XR Interaction Toolkit 2.3.0 with Starter Assets and Hands Interaction Demo samples installed 
    - XR Hands 1.1.0 with HandVisualizer sample installed
    - TextMeshPro 3.06
    - Ardity 1.1.0 (unused in the latest version)

## Test protocol by April 10, 2023: 
    - Hand tracking works well. But we can't track hands when using the controller.
    - Mug tracking is somehow glitchy because it requires manual calibration of the physical prop position and when the controller sleeps it drifts position. 
    - Haptic feedback on the controllers is hard-wired to the routine of collision detection, making it less than ideal.
    - AirLink stopped working.
    - We analyzed screen recording wiht ML from Tracker 6.1.2 https://physlets.org/tracker

## Test protocol by March 10, 2023: 
    - Tested using most up to date OpenXR plugin and Unity 2022.
    - Problems with getting the vibration working on the Oculus.


Test protocol by Feb 25, 2023: (Original experiment)
    - Arduino connected sensor (switch and ultrasonic distance sensor) and actuator (servomotor) with Arduity to move a physical lever
    - Technically works very well. But to add different placement positions, we pivoted to use the controller as a tracked physical prop.
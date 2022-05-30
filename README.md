# UnityAndroidToasty

Sample to solve Android dependent library by gradle.

- Unity Project: [UnityAndroidToasty](UnityAndroidToasty)
- Android Project: [ToastyWrapper](ToastyWrapper)

## Requirements

- Unity2021.3.3f1
    - Android Build Support Module
- Android Studio Chipmunk

## How to build

1. copy `classes.jar` in Unity Editor to `ToastyWrapper/unity/libs/`
1. copy `UnityPlayerActivity.java` in Unity Editor to `ToastyWrapper/unity/src/main/com/unity3d/player/`  
see also https://docs.unity3d.com/Manual/AndroidUnityPlayerActivity.html
1. build android library

        $ cd ToastyWrapper
        $ ./gradlew clean build
1. publish android library to [m2repository](UnityAndroidToasty/m2repository/)

        $ ./gradlew publish
1. build app with unity

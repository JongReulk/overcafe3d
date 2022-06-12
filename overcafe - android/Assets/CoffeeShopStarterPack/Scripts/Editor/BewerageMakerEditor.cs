﻿// ******------------------------------------------------------******
// BewerageMakerEditor.cs
//
// Author:
//       K.Sinan Acar <ksa@puzzledwizard.com>
//
// Copyright (c) 2019 PuzzledWizard
//
// ******------------------------------------------------------******
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace PW
{
    [CustomEditor(typeof(BewerageMaker))]
    [CanEditMultipleObjects]
    public class BewerageMakerEditor : Editor
    {

        bool showAnimationSettings;

        #region AnimationProperties

        string animStatus = "Animations Settings";


        SerializedProperty useAnimation;

        SerializedProperty preFillAnimationStateName;

        SerializedProperty fillEndedAnimationState;


        SerializedProperty preFillProcess;
        SerializedProperty fillingProcess;


        SerializedProperty dummyAnimationTarget;

        SerializedProperty fillParticle;

        SerializedProperty useTweeningAnimation;
        SerializedProperty finalTweenTarget;

        #endregion

        SerializedProperty cupType;
        SerializedProperty progressHelperprefab;
        SerializedProperty fillCupSpot;
        SerializedProperty DrinkSoundEffect;
        SerializedProperty AmericanoSound;
        SerializedProperty MochapotSound;
        SerializedProperty refillsound;
        SerializedProperty waterrefillsound;
        SerializedProperty breakSound;
        SerializedProperty breakParticle;
        SerializedProperty fixSound;





        SerializedProperty progressRefillprefab;


        void OnEnable()
        {
            useAnimation = serializedObject.FindProperty("useAnimation");
            preFillAnimationStateName = serializedObject.FindProperty("preFillAnimationStateName");
            fillEndedAnimationState = serializedObject.FindProperty("fillEndedAnimationState");
            preFillProcess = serializedObject.FindProperty("preFillProcess");
            fillingProcess = serializedObject.FindProperty("fillingProcess");
            cupType = serializedObject.FindProperty("cupType");
            progressHelperprefab = serializedObject.FindProperty("progressHelperprefab");
            fillCupSpot = serializedObject.FindProperty("fillCupSpot");
            dummyAnimationTarget = serializedObject.FindProperty("dummyAnimationTarget");
            fillParticle = serializedObject.FindProperty("fillParticle");
            useTweeningAnimation = serializedObject.FindProperty("useTweeningAnimation");
            finalTweenTarget = serializedObject.FindProperty("finalTweenTarget");
            DrinkSoundEffect = serializedObject.FindProperty("DrinkSoundEffect");
            AmericanoSound = serializedObject.FindProperty("AmericanoSound");
            MochapotSound = serializedObject.FindProperty("MochapotSound");
            refillsound = serializedObject.FindProperty("refillsound");
            waterrefillsound = serializedObject.FindProperty("waterrefillsound");
            breakSound = serializedObject.FindProperty("breakSound");
            breakParticle = serializedObject.FindProperty("breakParticle");
            fixSound = serializedObject.FindProperty("fixSound");






            progressRefillprefab = serializedObject.FindProperty("progressRefillprefab");


        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(cupType);
            EditorGUILayout.PropertyField(progressHelperprefab);
            EditorGUILayout.PropertyField(fillCupSpot);
            EditorGUILayout.PropertyField(DrinkSoundEffect);
            EditorGUILayout.PropertyField(useAnimation);
            EditorGUILayout.PropertyField(AmericanoSound);
            EditorGUILayout.PropertyField(MochapotSound);
            EditorGUILayout.PropertyField(refillsound);
            EditorGUILayout.PropertyField(waterrefillsound);
            EditorGUILayout.PropertyField(breakSound);
            EditorGUILayout.PropertyField(breakParticle);
            EditorGUILayout.PropertyField(fixSound);




            EditorGUILayout.PropertyField(progressRefillprefab);

            //Animation Settings FoldOut
            //Find out that do we even need animation settings for this object?
            showAnimationSettings = EditorGUILayout.Foldout(showAnimationSettings, animStatus);
            if (showAnimationSettings)
            {
                if (useAnimation.boolValue)
                {
                    EditorGUILayout.PropertyField(useTweeningAnimation);
                    
                    EditorGUILayout.PropertyField(dummyAnimationTarget, new GUIContent("Dummy Animation target to use"));
                    

                    if (useTweeningAnimation.boolValue)
                    {
                        EditorGUILayout.PropertyField(finalTweenTarget);
                    }

                    OnInspectorAdvancedAnimationSettings();
                }
                
            }
            if(!useAnimation.boolValue)
            {
                showAnimationSettings = false;
            }

            serializedObject.ApplyModifiedProperties();
        }

        public void OnInspectorUpdate()
        {
            this.Repaint();
        }

        public void OnInspectorAdvancedAnimationSettings()
        {
            //Prefill Settings 

            EditorGUILayout.PropertyField(preFillProcess, new GUIContent("PreFill Duration"));

            if(!useTweeningAnimation.boolValue)
                EditorGUILayout.PropertyField(preFillAnimationStateName, new GUIContent("PreFill Animation State"));


            //Filling Settings 

            EditorGUILayout.PropertyField(fillingProcess, new GUIContent("Filling Duration"));
            EditorGUILayout.PropertyField(fillParticle, new GUIContent("Filling Animation particle"));

            if (!useTweeningAnimation.boolValue)
                EditorGUILayout.PropertyField(fillEndedAnimationState, new GUIContent("Fıll Ended Animation State"));

        }
    }
}

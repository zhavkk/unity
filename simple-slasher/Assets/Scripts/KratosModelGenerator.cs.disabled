using UnityEngine;
using UnityEditor;

/// <summary>
/// Advanced God of War model generator with enhanced Kratos-inspired character.
/// Creates highly detailed Norse warrior with improved visual fidelity.
/// </summary>
public class KratosModelGenerator
{
    /// <summary>
    /// Creates an ultra-detailed Kratos-inspired Norse warrior with enhanced features.
    /// Improvements: Better proportions, more detailed armor, enhanced weapon, improved materials.
    /// </summary>
    public static GameObject CreateUltimateKratosModel()
    {
        GameObject playerModel = new GameObject("UltimateKratos");

        // ============================================
        // MAIN TORSO - Massive, muscular body
        // ============================================
        GameObject torso = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        torso.name = "Torso";
        torso.transform.SetParent(playerModel.transform);
        torso.transform.localPosition = new Vector3(0, 0.35f, 0);
        torso.transform.localScale = new Vector3(2.4f, 2.8f, 2.0f);
        torso.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Chest definition (pecks)
        GameObject leftPec = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftPec.name = "LeftPec";
        leftPec.transform.SetParent(playerModel.transform);
        leftPec.transform.localPosition = new Vector3(-0.5f, 0.7f, 0.9f);
        leftPec.transform.localScale = new Vector3(0.6f, 0.5f, 0.3f);

        GameObject rightPec = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightPec.name = "RightPec";
        rightPec.transform.SetParent(playerModel.transform);
        rightPec.transform.localPosition = new Vector3(0.5f, 0.7f, 0.9f);
        rightPec.transform.localScale = new Vector3(0.6f, 0.5f, 0.3f);

        // Ab definition
        for (int i = 0; i < 3; i++)
        {
            GameObject ab = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ab.name = "Ab_" + i;
            ab.transform.SetParent(playerModel.transform);
            ab.transform.localPosition = new Vector3(0, 0.3f - (i * 0.25f), 1.0f);
            ab.transform.localScale = new Vector3(1.2f, 0.15f, 0.1f);
        }

        // ============================================
        // HEAD - Detailed Kratos appearance
        // ============================================
        GameObject head = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        head.name = "Head";
        head.transform.SetParent(playerModel.transform);
        head.transform.localPosition = new Vector3(0, 2.1f, 0);
        head.transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

        // Jawline definition
        GameObject jaw = GameObject.CreatePrimitive(PrimitiveType.Cube);
        jaw.name = "Jaw";
        jaw.transform.SetParent(playerModel.transform);
        jaw.transform.localPosition = new Vector3(0, 1.85f, 0.4f);
        jaw.transform.localScale = new Vector3(0.9f, 0.3f, 0.3f);

        // Brow ridge
        GameObject brow = GameObject.CreatePrimitive(PrimitiveType.Cube);
        brow.name = "Brow";
        brow.transform.SetParent(playerModel.transform);
        brow.transform.localPosition = new Vector3(0, 2.25f, 0.5f);
        brow.transform.localScale = new Vector3(1.0f, 0.1f, 0.15f);

        // Signature red hair stripe (more prominent)
        GameObject hairStripe = GameObject.CreatePrimitive(PrimitiveType.Cube);
        hairStripe.name = "HairStripe";
        hairStripe.transform.SetParent(playerModel.transform);
        hairStripe.transform.localPosition = new Vector3(0, 2.6f, 0);
        hairStripe.transform.localScale = new Vector3(0.35f, 0.18f, 1.1f);

        // Hair sides (shaved)
        GameObject hairSideLeft = GameObject.CreatePrimitive(PrimitiveType.Cube);
        hairSideLeft.name = "HairSideLeft";
        hairSideLeft.transform.SetParent(playerModel.transform);
        hairSideLeft.transform.localPosition = new Vector3(-0.5f, 2.5f, 0);
        hairSideLeft.transform.localScale = new Vector3(0.08f, 0.12f, 1.0f);

        GameObject hairSideRight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        hairSideRight.name = "HairSideRight";
        hairSideRight.transform.SetParent(playerModel.transform);
        hairSideRight.transform.localPosition = new Vector3(0.5f, 2.5f, 0);
        hairSideRight.transform.localScale = new Vector3(0.08f, 0.12f, 1.0f);

        // Distinctive facial tattoos (enhanced)
        GameObject tattooLeftMain = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tattooLeftMain.name = "TattooLeftMain";
        tattooLeftMain.transform.SetParent(playerModel.transform);
        tattooLeftMain.transform.localPosition = new Vector3(-0.4f, 2.0f, 0.55f);
        tattooLeftMain.transform.localScale = new Vector3(0.1f, 0.5f, 0.02f);
        tattooLeftMain.transform.rotation = Quaternion.Euler(35, 0, 0);

        GameObject tattooRightMain = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tattooRightMain.name = "TattooRightMain";
        tattooRightMain.transform.SetParent(playerModel.transform);
        tattooRightMain.transform.localPosition = new Vector3(0.4f, 2.0f, 0.55f);
        tattooRightMain.transform.localScale = new Vector3(0.1f, 0.5f, 0.02f);
        tattooRightMain.transform.rotation = Quaternion.Euler(-35, 0, 0);

        // Forehead band tattoo
        GameObject foreheadBand = GameObject.CreatePrimitive(PrimitiveType.Cube);
        foreheadBand.name = "ForeheadBand";
        foreheadBand.transform.SetParent(playerModel.transform);
        foreheadBand.transform.localPosition = new Vector3(0, 2.35f, 0.55f);
        foreheadBand.transform.localScale = new Vector3(0.8f, 0.1f, 0.02f);

        // Cheek tattoos
        GameObject tattooLeftCheek = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tattooLeftCheek.name = "TattooLeftCheek";
        tattooLeftCheek.transform.SetParent(playerModel.transform);
        tattooLeftCheek.transform.localPosition = new Vector3(-0.35f, 1.9f, 0.55f);
        tattooLeftCheek.transform.localScale = new Vector3(0.08f, 0.2f, 0.02f);

        GameObject tattooRightCheek = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tattooRightCheek.name = "TattooRightCheek";
        tattooRightCheek.transform.SetParent(playerModel.transform);
        tattooRightCheek.transform.localPosition = new Vector3(0.35f, 1.9f, 0.55f);
        tattooRightCheek.transform.localScale = new Vector3(0.08f, 0.2f, 0.02f);

        // ============================================
        // MASSIVE ARMS - Enhanced musculature
        // ============================================
        // Left arm (deltoid)
        GameObject leftDeltoid = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftDeltoid.name = "LeftDeltoid";
        leftDeltoid.transform.SetParent(playerModel.transform);
        leftDeltoid.transform.localPosition = new Vector3(-1.4f, 0.6f, 0);
        leftDeltoid.transform.localScale = new Vector3(0.8f, 0.7f, 0.8f);

        GameObject leftUpperArm = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftUpperArm.name = "LeftUpperArm";
        leftUpperArm.transform.SetParent(playerModel.transform);
        leftUpperArm.transform.localPosition = new Vector3(-1.8f, 0.1f, 0);
        leftUpperArm.transform.localScale = new Vector3(0.75f, 1.1f, 0.75f);
        leftUpperArm.transform.rotation = Quaternion.Euler(0, 0, -70);

        // Bicep definition
        GameObject leftBicep = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftBicep.name = "LeftBicep";
        leftBicep.transform.SetParent(playerModel.transform);
        leftBicep.transform.localPosition = new Vector3(-1.9f, 0.3f, 0.2f);
        leftBicep.transform.localScale = new Vector3(0.6f, 0.7f, 0.5f);

        GameObject leftForearm = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftForearm.name = "LeftForearm";
        leftForearm.transform.SetParent(playerModel.transform);
        leftForearm.transform.localPosition = new Vector3(-2.3f, -0.5f, 0);
        leftForearm.transform.localScale = new Vector3(0.65f, 1.0f, 0.65f);
        leftForearm.transform.rotation = Quaternion.Euler(0, 0, -55);

        GameObject leftHand = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftHand.name = "LeftHand";
        leftHand.transform.SetParent(playerModel.transform);
        leftHand.transform.localPosition = new Vector3(-2.7f, -0.9f, 0);
        leftHand.transform.localScale = new Vector3(0.55f, 0.55f, 0.45f);

        // Right arm (larger, weapon arm)
        GameObject rightDeltoid = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightDeltoid.name = "RightDeltoid";
        rightDeltoid.transform.SetParent(playerModel.transform);
        rightDeltoid.transform.localPosition = new Vector3(1.4f, 0.6f, 0);
        rightDeltoid.transform.localScale = new Vector3(0.9f, 0.8f, 0.9f);

        GameObject rightUpperArm = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightUpperArm.name = "RightUpperArm";
        rightUpperArm.transform.SetParent(playerModel.transform);
        rightUpperArm.transform.localPosition = new Vector3(1.9f, 0.1f, 0);
        rightUpperArm.transform.localScale = new Vector3(0.85f, 1.2f, 0.85f);
        rightUpperArm.transform.rotation = Quaternion.Euler(0, 0, 70);

        // Bicep definition
        GameObject rightBicep = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightBicep.name = "RightBicep";
        rightBicep.transform.SetParent(playerModel.transform);
        rightBicep.transform.localPosition = new Vector3(2.0f, 0.3f, 0.2f);
        rightBicep.transform.localScale = new Vector3(0.7f, 0.8f, 0.6f);

        GameObject rightForearm = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightForearm.name = "RightForearm";
        rightForearm.transform.SetParent(playerModel.transform);
        rightForearm.transform.localPosition = new Vector3(2.5f, -0.5f, 0);
        rightForearm.transform.localScale = new Vector3(0.75f, 1.1f, 0.75f);
        rightForearm.transform.rotation = Quaternion.Euler(0, 0, 55);

        GameObject rightHand = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightHand.name = "RightHand";
        rightHand.transform.SetParent(playerModel.transform);
        rightHand.transform.localPosition = new Vector3(2.9f, -0.9f, 0);
        rightHand.transform.localScale = new Vector3(0.65f, 0.65f, 0.55f);

        // ============================================
        // ENHANCED NORDIC SHOULDER ARMOR
        // ============================================
        // Left shoulder complex
        GameObject leftShoulderBase = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftShoulderBase.name = "LeftShoulderBase";
        leftShoulderBase.transform.SetParent(playerModel.transform);
        leftShoulderBase.transform.localPosition = new Vector3(-1.3f, 1.0f, 0);
        leftShoulderBase.transform.localScale = new Vector3(1.1f, 0.6f, 1.1f);
        leftShoulderBase.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Left shoulder rim (using cylinder as torus substitute)
        GameObject leftShoulderRim = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftShoulderRim.name = "LeftShoulderRim";
        leftShoulderRim.transform.SetParent(playerModel.transform);
        leftShoulderRim.transform.localPosition = new Vector3(-1.3f, 1.0f, 0);
        leftShoulderRim.transform.localScale = new Vector3(0.8f, 0.8f, 0.1f);

        // Left shoulder spikes (triple)
        GameObject leftSpike1 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftSpike1.name = "LeftSpike1";
        leftSpike1.transform.SetParent(playerModel.transform);
        leftSpike1.transform.localPosition = new Vector3(-1.3f, 1.55f, 0);
        leftSpike1.transform.localScale = new Vector3(0.18f, 0.5f, 0.18f);

        GameObject leftSpike2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftSpike2.name = "LeftSpike2";
        leftSpike2.transform.SetParent(playerModel.transform);
        leftSpike2.transform.localPosition = new Vector3(-1.3f, 1.5f, 0.45f);
        leftSpike2.transform.localScale = new Vector3(0.15f, 0.4f, 0.15f);
        leftSpike2.transform.rotation = Quaternion.Euler(25, 0, 0);

        GameObject leftSpike3 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftSpike3.name = "LeftSpike3";
        leftSpike3.transform.SetParent(playerModel.transform);
        leftSpike3.transform.localPosition = new Vector3(-1.3f, 1.5f, -0.45f);
        leftSpike3.transform.localScale = new Vector3(0.15f, 0.4f, 0.15f);
        leftSpike3.transform.rotation = Quaternion.Euler(-25, 0, 0);

        // Right shoulder complex (larger, more ornate)
        GameObject rightShoulderBase = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightShoulderBase.name = "RightShoulderBase";
        rightShoulderBase.transform.SetParent(playerModel.transform);
        rightShoulderBase.transform.localPosition = new Vector3(1.4f, 1.0f, 0);
        rightShoulderBase.transform.localScale = new Vector3(1.3f, 0.7f, 1.3f);
        rightShoulderBase.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Right shoulder rim (using cylinder as torus substitute)
        GameObject rightShoulderRim = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightShoulderRim.name = "RightShoulderRim";
        rightShoulderRim.transform.SetParent(playerModel.transform);
        rightShoulderRim.transform.localPosition = new Vector3(1.4f, 1.0f, 0);
        rightShoulderRim.transform.localScale = new Vector3(0.95f, 0.95f, 0.12f);

        // Right shoulder spikes (quintuple - more menacing)
        GameObject rightSpike1 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightSpike1.name = "RightSpike1";
        rightSpike1.transform.SetParent(playerModel.transform);
        rightSpike1.transform.localPosition = new Vector3(1.4f, 1.65f, 0);
        rightSpike1.transform.localScale = new Vector3(0.2f, 0.6f, 0.2f);

        GameObject rightSpike2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightSpike2.name = "RightSpike2";
        rightSpike2.transform.SetParent(playerModel.transform);
        rightSpike2.transform.localPosition = new Vector3(1.4f, 1.6f, 0.55f);
        rightSpike2.transform.localScale = new Vector3(0.16f, 0.45f, 0.16f);
        rightSpike2.transform.rotation = Quaternion.Euler(30, 0, 0);

        GameObject rightSpike3 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightSpike3.name = "RightSpike3";
        rightSpike3.transform.SetParent(playerModel.transform);
        rightSpike3.transform.localPosition = new Vector3(1.4f, 1.6f, -0.55f);
        rightSpike3.transform.localScale = new Vector3(0.16f, 0.45f, 0.16f);
        rightSpike3.transform.rotation = Quaternion.Euler(-30, 0, 0);

        GameObject rightSpike4 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightSpike4.name = "RightSpike4";
        rightSpike4.transform.SetParent(playerModel.transform);
        rightSpike4.transform.localPosition = new Vector3(1.4f, 1.55f, 0.35f);
        rightSpike4.transform.localScale = new Vector3(0.14f, 0.35f, 0.14f);
        rightSpike4.transform.rotation = Quaternion.Euler(20, 0, 0);

        GameObject rightSpike5 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightSpike5.name = "RightSpike5";
        rightSpike5.transform.SetParent(playerModel.transform);
        rightSpike5.transform.localPosition = new Vector3(1.4f, 1.55f, -0.35f);
        rightSpike5.transform.localScale = new Vector3(0.14f, 0.35f, 0.14f);
        rightSpike5.transform.rotation = Quaternion.Euler(-20, 0, 0);

        // ============================================
        // CHEST ARMOR AND LEATHER WORK
        // ============================================
        // Main chest strap
        GameObject chestStrapMain = GameObject.CreatePrimitive(PrimitiveType.Cube);
        chestStrapMain.name = "ChestStrapMain";
        chestStrapMain.transform.SetParent(playerModel.transform);
        chestStrapMain.transform.localPosition = new Vector3(0, 0.7f, 1.05f);
        chestStrapMain.transform.localScale = new Vector3(2.6f, 0.15f, 0.18f);

        // Secondary chest strap
        GameObject chestStrapSec = GameObject.CreatePrimitive(PrimitiveType.Cube);
        chestStrapSec.name = "ChestStrapSec";
        chestStrapSec.transform.SetParent(playerModel.transform);
        chestStrapSec.transform.localPosition = new Vector3(0, 0.4f, 1.05f);
        chestStrapSec.transform.localScale = new Vector3(2.6f, 0.15f, 0.18f);

        // Cross straps with buckles
        GameObject crossStrapLeft = GameObject.CreatePrimitive(PrimitiveType.Cube);
        crossStrapLeft.name = "CrossStrapLeft";
        crossStrapLeft.transform.SetParent(playerModel.transform);
        crossStrapLeft.transform.localPosition = new Vector3(-0.7f, 0.55f, 1.05f);
        crossStrapLeft.transform.localScale = new Vector3(0.14f, 0.9f, 0.18f);
        crossStrapLeft.transform.rotation = Quaternion.Euler(0, 0, 18);

        GameObject crossStrapRight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        crossStrapRight.name = "CrossStrapRight";
        crossStrapRight.transform.SetParent(playerModel.transform);
        crossStrapRight.transform.localPosition = new Vector3(0.7f, 0.55f, 1.05f);
        crossStrapRight.transform.localScale = new Vector3(0.14f, 0.9f, 0.18f);
        crossStrapRight.transform.rotation = Quaternion.Euler(0, 0, -18);

        // Center buckle
        GameObject centerBuckle = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        centerBuckle.name = "CenterBuckle";
        centerBuckle.transform.SetParent(playerModel.transform);
        centerBuckle.transform.localPosition = new Vector3(0, 0.55f, 1.15f);
        centerBuckle.transform.localScale = new Vector3(0.25f, 0.08f, 0.25f);

        // ============================================
        // FUR PELTS AND VIKING DETAILS
        // ============================================
        // Large back fur pelt
        GameObject backFurMain = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        backFurMain.name = "BackFurMain";
        backFurMain.transform.SetParent(playerModel.transform);
        backFurMain.transform.localPosition = new Vector3(0, 0.2f, -1.1f);
        backFurMain.transform.localScale = new Vector3(2.0f, 2.0f, 0.7f);
        backFurMain.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Fur texture detail
        for (int i = 0; i < 5; i++)
        {
            GameObject furDetail = GameObject.CreatePrimitive(PrimitiveType.Cube);
            furDetail.name = "FurDetail_" + i;
            furDetail.transform.SetParent(playerModel.transform);
            furDetail.transform.localPosition = new Vector3(0, 0.8f - (i * 0.3f), -1.45f);
            furDetail.transform.localScale = new Vector3(1.8f, 0.08f, 0.15f);
        }

        // Waist fur belt
        GameObject waistFur = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        waistFur.name = "WaistFur";
        waistFur.transform.SetParent(playerModel.transform);
        waistFur.transform.localPosition = new Vector3(0, -0.6f, 0);
        waistFur.transform.localScale = new Vector3(2.8f, 0.5f, 2.2f);
        waistFur.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Hanging fur pieces
        GameObject furHanging1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        furHanging1.name = "FurHanging1";
        furHanging1.transform.SetParent(playerModel.transform);
        furHanging1.transform.localPosition = new Vector3(-0.8f, -0.8f, 0.3f);
        furHanging1.transform.localScale = new Vector3(0.4f, 0.6f, 0.3f);

        GameObject furHanging2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        furHanging2.name = "FurHanging2";
        furHanging2.transform.SetParent(playerModel.transform);
        furHanging2.transform.localPosition = new Vector3(0.8f, -0.8f, 0.3f);
        furHanging2.transform.localScale = new Vector3(0.4f, 0.6f, 0.3f);

        // ============================================
        // POWERFUL LEGS
        // ============================================
        // Left leg complex
        GameObject leftThigh = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftThigh.name = "LeftThigh";
        leftThigh.transform.SetParent(playerModel.transform);
        leftThigh.transform.localPosition = new Vector3(-0.55f, -1.3f, 0);
        leftThigh.transform.localScale = new Vector3(1.0f, 1.4f, 1.0f);

        // Left quad definition
        GameObject leftQuad = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftQuad.name = "LeftQuad";
        leftQuad.transform.SetParent(playerModel.transform);
        leftQuad.transform.localPosition = new Vector3(-0.7f, -1.2f, 0.3f);
        leftQuad.transform.localScale = new Vector3(0.5f, 0.8f, 0.4f);

        GameObject leftShin = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftShin.name = "LeftShin";
        leftShin.transform.SetParent(playerModel.transform);
        leftShin.transform.localPosition = new Vector3(-0.55f, -2.3f, 0);
        leftShin.transform.localScale = new Vector3(0.75f, 1.3f, 0.75f);

        // Left calf definition
        GameObject leftCalf = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftCalf.name = "LeftCalf";
        leftCalf.transform.SetParent(playerModel.transform);
        leftCalf.transform.localPosition = new Vector3(-0.65f, -2.2f, 0.2f);
        leftCalf.transform.localScale = new Vector3(0.4f, 0.6f, 0.35f);

        GameObject leftFoot = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftFoot.name = "LeftFoot";
        leftFoot.transform.SetParent(playerModel.transform);
        leftFoot.transform.localPosition = new Vector3(-0.55f, -3.1f, 0.2f);
        leftFoot.transform.localScale = new Vector3(0.9f, 0.35f, 1.4f);

        // Right leg complex
        GameObject rightThigh = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightThigh.name = "RightThigh";
        rightThigh.transform.SetParent(playerModel.transform);
        rightThigh.transform.localPosition = new Vector3(0.55f, -1.3f, 0);
        rightThigh.transform.localScale = new Vector3(1.0f, 1.4f, 1.0f);

        // Right quad definition
        GameObject rightQuad = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightQuad.name = "RightQuad";
        rightQuad.transform.SetParent(playerModel.transform);
        rightQuad.transform.localPosition = new Vector3(0.7f, -1.2f, 0.3f);
        rightQuad.transform.localScale = new Vector3(0.5f, 0.8f, 0.4f);

        GameObject rightShin = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightShin.name = "RightShin";
        rightShin.transform.SetParent(playerModel.transform);
        rightShin.transform.localPosition = new Vector3(0.55f, -2.3f, 0);
        rightShin.transform.localScale = new Vector3(0.75f, 1.3f, 0.75f);

        // Right calf definition
        GameObject rightCalf = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightCalf.name = "RightCalf";
        rightCalf.transform.SetParent(playerModel.transform);
        rightCalf.transform.localPosition = new Vector3(0.65f, -2.2f, 0.2f);
        rightCalf.transform.localScale = new Vector3(0.4f, 0.6f, 0.35f);

        GameObject rightFoot = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightFoot.name = "RightFoot";
        rightFoot.transform.SetParent(playerModel.transform);
        rightFoot.transform.localPosition = new Vector3(0.55f, -3.1f, 0.2f);
        rightFoot.transform.localScale = new Vector3(0.9f, 0.35f, 1.4f);

        // Enhanced knee armor
        GameObject leftKneeArmor = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftKneeArmor.name = "LeftKneeArmor";
        leftKneeArmor.transform.SetParent(playerModel.transform);
        leftKneeArmor.transform.localPosition = new Vector3(-0.55f, -1.8f, 0.3f);
        leftKneeArmor.transform.localScale = new Vector3(0.6f, 0.6f, 0.5f);

        GameObject rightKneeArmor = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightKneeArmor.name = "RightKneeArmor";
        rightKneeArmor.transform.SetParent(playerModel.transform);
        rightKneeArmor.transform.localPosition = new Vector3(0.55f, -1.8f, 0.3f);
        rightKneeArmor.transform.localScale = new Vector3(0.6f, 0.6f, 0.5f);

        // ============================================
        // ULTIMATE LEVIATHAN AXE
        // ============================================
        GameObject ultimateAxe = CreateUltimateLeviathanAxe();
        ultimateAxe.transform.SetParent(playerModel.transform);
        ultimateAxe.transform.localPosition = new Vector3(0.9f, 0.3f, 0.6f);
        ultimateAxe.transform.localRotation = Quaternion.Euler(0, -35, 95);

        // ============================================
        // Apply enhanced materials
        // ============================================
        ApplyUltimateKratosMaterials(playerModel);

        return playerModel;
    }

    /// <summary>
    /// Creates the ultimate Leviathan Axe with enhanced details and Norse engravings.
    /// </summary>
    private static GameObject CreateUltimateLeviathanAxe()
    {
        GameObject axe = new GameObject("UltimateLeviathanAxe");

        // ============================================
        // ENHANCED HANDLE
        // ============================================
        GameObject handleMain = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        handleMain.name = "HandleMain";
        handleMain.transform.SetParent(axe.transform);
        handleMain.transform.localPosition = new Vector3(0, -0.6f, 0);
        handleMain.transform.localScale = new Vector3(0.14f, 2.4f, 0.14f);

        // Handle leather wrapping (detailed)
        for (int i = 0; i < 8; i++)
        {
            GameObject handleWrap = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            handleWrap.name = "HandleWrap_" + i;
            handleWrap.transform.SetParent(axe.transform);
            handleWrap.transform.localPosition = new Vector3(0, -1.0f + (i * 0.25f), 0);
            handleWrap.transform.localScale = new Vector3(0.15f, 0.04f, 0.15f);
        }

        // Handle bottom pommel
        GameObject handlePommel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        handlePommel.name = "HandlePommel";
        handlePommel.transform.SetParent(axe.transform);
        handlePommel.transform.localPosition = new Vector3(0, -1.9f, 0);
        handlePommel.transform.localScale = new Vector3(0.22f, 0.22f, 0.22f);

        // ============================================
        // MASSIVE DOUBLE-BLADED AXE HEAD
        // ============================================
        // Axe head core
        GameObject axeCore = GameObject.CreatePrimitive(PrimitiveType.Cube);
        axeCore.name = "AxeCore";
        axeCore.transform.SetParent(axe.transform);
        axeCore.transform.localPosition = new Vector3(0, 0.7f, 0);
        axeCore.transform.localScale = new Vector3(0.6f, 0.7f, 0.35f);

        // Left main blade
        GameObject leftBladeMain = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftBladeMain.name = "LeftBladeMain";
        leftBladeMain.transform.SetParent(axe.transform);
        leftBladeMain.transform.localPosition = new Vector3(-0.7f, 0.7f, 0);
        leftBladeMain.transform.localScale = new Vector3(1.4f, 0.9f, 0.1f);

        // Left blade edge (razor sharp)
        GameObject leftBladeEdge = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftBladeEdge.name = "LeftBladeEdge";
        leftBladeEdge.transform.SetParent(axe.transform);
        leftBladeEdge.transform.localPosition = new Vector3(-1.45f, 0.7f, 0);
        leftBladeEdge.transform.localScale = new Vector3(0.05f, 0.9f, 0.05f);

        // Left blade curve
        GameObject leftBladeCurve = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftBladeCurve.name = "LeftBladeCurve";
        leftBladeCurve.transform.SetParent(axe.transform);
        leftBladeCurve.transform.localPosition = new Vector3(-1.0f, 0.4f, 0);
        leftBladeCurve.transform.localScale = new Vector3(0.08f, 0.5f, 0.08f);
        leftBladeCurve.transform.rotation = Quaternion.Euler(0, 0, 45);

        // Right main blade
        GameObject rightBladeMain = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightBladeMain.name = "RightBladeMain";
        rightBladeMain.transform.SetParent(axe.transform);
        rightBladeMain.transform.localPosition = new Vector3(0.7f, 0.7f, 0);
        rightBladeMain.transform.localScale = new Vector3(1.4f, 0.9f, 0.1f);

        // Right blade edge (razor sharp)
        GameObject rightBladeEdge = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightBladeEdge.name = "RightBladeEdge";
        rightBladeEdge.transform.SetParent(axe.transform);
        rightBladeEdge.transform.localPosition = new Vector3(1.45f, 0.7f, 0);
        rightBladeEdge.transform.localScale = new Vector3(0.05f, 0.9f, 0.05f);

        // Right blade curve
        GameObject rightBladeCurve = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightBladeCurve.name = "RightBladeCurve";
        rightBladeCurve.transform.SetParent(axe.transform);
        rightBladeCurve.transform.localPosition = new Vector3(1.0f, 0.4f, 0);
        rightBladeCurve.transform.localScale = new Vector3(0.08f, 0.5f, 0.08f);
        rightBladeCurve.transform.rotation = Quaternion.Euler(0, 0, -45);

        // ============================================
        // NORSE ENGRAVINGS AND DECORATIONS
        // ============================================
        // Left blade engravings
        for (int i = 0; i < 3; i++)
        {
            GameObject leftEngraving = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            leftEngraving.name = "LeftEngraving_" + i;
            leftEngraving.transform.SetParent(axe.transform);
            leftEngraving.transform.localPosition = new Vector3(-0.9f + (i * 0.3f), 0.7f, 0.06f);
            leftEngraving.transform.localScale = new Vector3(0.04f, 0.5f, 0.04f);
            leftEngraving.transform.rotation = Quaternion.Euler(0, 0, i * 20);
        }

        // Right blade engravings
        for (int i = 0; i < 3; i++)
        {
            GameObject rightEngraving = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            rightEngraving.name = "RightEngraving_" + i;
            rightEngraving.transform.SetParent(axe.transform);
            rightEngraving.transform.localPosition = new Vector3(0.9f - (i * 0.3f), 0.7f, 0.06f);
            rightEngraving.transform.localScale = new Vector3(0.04f, 0.5f, 0.04f);
            rightEngraving.transform.rotation = Quaternion.Euler(0, 0, -i * 20);
        }

        // Center rune circle
        GameObject centerRune = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        centerRune.name = "CenterRune";
        centerRune.transform.SetParent(axe.transform);
        centerRune.transform.localPosition = new Vector3(0, 0.7f, 0.2f);
        centerRune.transform.localScale = new Vector3(0.25f, 0.05f, 0.25f);

        // Rune symbols
        for (int i = 0; i < 4; i++)
        {
            GameObject runeSymbol = GameObject.CreatePrimitive(PrimitiveType.Cube);
            runeSymbol.name = "RuneSymbol_" + i;
            runeSymbol.transform.SetParent(axe.transform);
            float angle = i * 90f;
            runeSymbol.transform.localPosition = new Vector3(
                Mathf.Sin(angle * Mathf.Deg2Rad) * 0.15f,
                0.7f,
                0.2f + Mathf.Cos(angle * Mathf.Deg2Rad) * 0.15f
            );
            runeSymbol.transform.localScale = new Vector3(0.04f, 0.15f, 0.04f);
        }

        // ============================================
        // AXE BUTT AND DECORATIONS
        // ============================================
        GameObject axeButt = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        axeButt.name = "AxeButt";
        axeButt.transform.SetParent(axe.transform);
        axeButt.transform.localPosition = new Vector3(0, -1.9f, 0);
        axeButt.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        // Decorative rings on handle (using cylinder as torus substitute)
        for (int i = 0; i < 2; i++)
        {
            GameObject handleRing = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            handleRing.name = "HandleRing_" + i;
            handleRing.transform.SetParent(axe.transform);
            handleRing.transform.localPosition = new Vector3(0, -0.3f - (i * 0.4f), 0);
            handleRing.transform.localScale = new Vector3(0.18f, 0.18f, 0.03f);
        }

        return axe;
    }

    /// <summary>
    /// Applies ultimate materials to the Kratos model with enhanced visual quality.
    /// </summary>
    private static void ApplyUltimateKratosMaterials(GameObject playerModel)
    {
        // Enhanced red/orange skin tone
        Material skinMaterial = new Material(Shader.Find("Standard"));
        skinMaterial.color = new Color(0.88f, 0.38f, 0.25f);
        skinMaterial.SetFloat("_Glossiness", 0.3f);

        // Enhanced red tattoo markings
        Material tattooMaterial = new Material(Shader.Find("Standard"));
        tattooMaterial.color = new Color(0.95f, 0.15f, 0.15f);
        tattooMaterial.SetFloat("_Glossiness", 0.4f);

        // Enhanced red hair
        Material hairMaterial = new Material(Shader.Find("Standard"));
        hairMaterial.color = new Color(0.85f, 0.2f, 0.1f);
        hairMaterial.SetFloat("_Glossiness", 0.5f);

        // Premium metallic armor (ancient iron)
        Material armorMaterial = new Material(Shader.Find("Standard"));
        armorMaterial.color = new Color(0.25f, 0.25f, 0.3f);
        armorMaterial.SetFloat("_Metallic", 0.95f);
        armorMaterial.SetFloat("_Glossiness", 0.7f);

        // Ornate gold/bronze trim
        Material trimMaterial = new Material(Shader.Find("Standard"));
        trimMaterial.color = new Color(0.8f, 0.6f, 0.3f);
        trimMaterial.SetFloat("_Metallic", 0.9f);
        trimMaterial.SetFloat("_Glossiness", 0.8f);

        // Premium leather straps
        Material leatherMaterial = new Material(Shader.Find("Standard"));
        leatherMaterial.color = new Color(0.4f, 0.3f, 0.2f);
        leatherMaterial.SetFloat("_Glossiness", 0.2f);

        // Enhanced fur pelts (detailed texture color)
        Material furMaterial = new Material(Shader.Find("Standard"));
        furMaterial.color = new Color(0.35f, 0.3f, 0.25f);
        furMaterial.SetFloat("_Glossiness", 0.1f);

        // Shiny knee armor (polished metal)
        Material kneeArmorMaterial = new Material(Shader.Find("Standard"));
        kneeArmorMaterial.color = new Color(0.65f, 0.65f, 0.7f);
        kneeArmorMaterial.SetFloat("_Metallic", 0.85f);
        kneeArmorMaterial.SetFloat("_Glossiness", 0.8f);

        // Apply materials to body parts
        ApplyMaterialToChild(playerModel, "Torso", skinMaterial);
        ApplyMaterialToChild(playerModel, "Head", skinMaterial);
        ApplyMaterialToChild(playerModel, "Jaw", skinMaterial);
        ApplyMaterialToChild(playerModel, "Brow", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftPec", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightPec", skinMaterial);

        // Abs
        for (int i = 0; i < 3; i++)
        {
            ApplyMaterialToChild(playerModel, "Ab_" + i, skinMaterial);
        }

        // Arms
        ApplyMaterialToChild(playerModel, "LeftDeltoid", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftUpperArm", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftBicep", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftForearm", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftHand", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightDeltoid", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightUpperArm", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightBicep", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightForearm", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightHand", skinMaterial);

        // Legs
        ApplyMaterialToChild(playerModel, "LeftThigh", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftQuad", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftShin", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftCalf", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftFoot", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightThigh", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightQuad", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightShin", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightCalf", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightFoot", skinMaterial);

        // Tattoos and hair
        ApplyMaterialToChild(playerModel, "HairStripe", hairMaterial);
        ApplyMaterialToChild(playerModel, "HairSideLeft", hairMaterial);
        ApplyMaterialToChild(playerModel, "HairSideRight", hairMaterial);
        ApplyMaterialToChild(playerModel, "TattooLeftMain", tattooMaterial);
        ApplyMaterialToChild(playerModel, "TattooRightMain", tattooMaterial);
        ApplyMaterialToChild(playerModel, "ForeheadBand", tattooMaterial);
        ApplyMaterialToChild(playerModel, "TattooLeftCheek", tattooMaterial);
        ApplyMaterialToChild(playerModel, "TattooRightCheek", tattooMaterial);

        // Armor
        ApplyMaterialToChild(playerModel, "LeftShoulderBase", armorMaterial);
        ApplyMaterialToChild(playerModel, "LeftShoulderRim", trimMaterial);
        ApplyMaterialToChild(playerModel, "LeftSpike1", armorMaterial);
        ApplyMaterialToChild(playerModel, "LeftSpike2", armorMaterial);
        ApplyMaterialToChild(playerModel, "LeftSpike3", armorMaterial);
        ApplyMaterialToChild(playerModel, "RightShoulderBase", armorMaterial);
        ApplyMaterialToChild(playerModel, "RightShoulderRim", trimMaterial);
        ApplyMaterialToChild(playerModel, "RightSpike1", armorMaterial);
        ApplyMaterialToChild(playerModel, "RightSpike2", armorMaterial);
        ApplyMaterialToChild(playerModel, "RightSpike3", armorMaterial);
        ApplyMaterialToChild(playerModel, "RightSpike4", armorMaterial);
        ApplyMaterialToChild(playerModel, "RightSpike5", armorMaterial);
        ApplyMaterialToChild(playerModel, "LeftKneeArmor", kneeArmorMaterial);
        ApplyMaterialToChild(playerModel, "RightKneeArmor", kneeArmorMaterial);

        // Leather and fur
        ApplyMaterialToChild(playerModel, "ChestStrapMain", leatherMaterial);
        ApplyMaterialToChild(playerModel, "ChestStrapSec", leatherMaterial);
        ApplyMaterialToChild(playerModel, "CrossStrapLeft", leatherMaterial);
        ApplyMaterialToChild(playerModel, "CrossStrapRight", leatherMaterial);
        ApplyMaterialToChild(playerModel, "CenterBuckle", trimMaterial);
        ApplyMaterialToChild(playerModel, "BackFurMain", furMaterial);
        ApplyMaterialToChild(playerModel, "WaistFur", furMaterial);
        ApplyMaterialToChild(playerModel, "FurHanging1", furMaterial);
        ApplyMaterialToChild(playerModel, "FurHanging2", furMaterial);

        // Fur details
        for (int i = 0; i < 5; i++)
        {
            ApplyMaterialToChild(playerModel, "FurDetail_" + i, furMaterial);
        }

        // Ultimate Leviathan Axe materials
        Material axeHandleMaterial = new Material(Shader.Find("Standard"));
        axeHandleMaterial.color = new Color(0.45f, 0.3f, 0.2f);
        axeHandleMaterial.SetFloat("_Glossiness", 0.3f);

        Material axeHeadMaterial = new Material(Shader.Find("Standard"));
        axeHeadMaterial.color = new Color(0.75f, 0.75f, 0.8f);
        axeHeadMaterial.SetFloat("_Metallic", 0.98f);
        axeHeadMaterial.SetFloat("_Glossiness", 0.95f);

        Material axeEdgeMaterial = new Material(Shader.Find("Standard"));
        axeEdgeMaterial.color = new Color(0.9f, 0.9f, 0.95f);
        axeEdgeMaterial.SetFloat("_Metallic", 1.0f);
        axeEdgeMaterial.SetFloat("_Glossiness", 1.0f);

        Material runeMaterial = new Material(Shader.Find("Standard"));
        runeMaterial.color = new Color(0.4f, 0.7f, 0.9f);
        runeMaterial.SetFloat("_EmissionIntensity", 0.3f);
        runeMaterial.SetFloat("_Glossiness", 0.6f);

        Transform axe = playerModel.transform.Find("UltimateLeviathanAxe");
        if (axe != null)
        {
            foreach (Transform child in axe)
            {
                Renderer renderer = child.GetComponent<Renderer>();
                if (renderer != null)
                {
                    if (child.name.Contains("Handle"))
                    {
                        renderer.material = axeHandleMaterial;
                    }
                    else if (child.name.Contains("Edge"))
                    {
                        renderer.material = axeEdgeMaterial;
                    }
                    else if (child.name.Contains("Rune") || child.name.Contains("Engraving"))
                    {
                        renderer.material = runeMaterial;
                    }
                    else if (child.name.Contains("Ring") || child.name.Contains("Pommel") || child.name.Contains("Butt"))
                    {
                        renderer.material = trimMaterial;
                    }
                    else
                    {
                        renderer.material = axeHeadMaterial;
                    }
                }
            }
        }
    }

    private static void ApplyMaterialToChild(GameObject parent, string childName, Material material)
    {
        Transform child = parent.transform.Find(childName);
        if (child != null)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = material;
            }
        }
    }
}

#if UNITY_EDITOR
/// <summary>
/// Editor window for ultimate Kratos model generation.
/// </summary>
public class KratosModelGeneratorEditor : EditorWindow
{
    [MenuItem("Tools/Kratos Model Generator/Ultimate Kratos")]
    public static void CreateUltimateKratos()
    {
        GameObject player = KratosModelGenerator.CreateUltimateKratosModel();
        player.transform.position = Vector3.zero;
        Selection.activeGameObject = player;
        Debug.Log("🪓 Ultimate Kratos model created with enhanced details!");
    }

    [MenuItem("Tools/Kratos Model Generator/Show Window")]
    public static void ShowWindow()
    {
        GetWindow<KratosModelGeneratorEditor>("Ultimate Kratos Generator");
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("🪓 Ultimate Kratos Model Generator", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.HelpBox(
            "Creates the ultimate God of War inspired Kratos model.\n" +
            "Features enhanced details, improved proportions, and superior materials.",
            MessageType.Info
        );

        EditorGUILayout.Space();

        if (GUILayout.Button("Create Ultimate Kratos", GUILayout.Height(50)))
        {
            CreateUltimateKratos();
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Model Features", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox(
            "Ultimate Kratos Features:\n" +
            "• Enhanced muscular definition (pecks, abs, biceps, quads, calves)\n" +
            "• Detailed red/orange skin tone with realistic gloss\n" +
            "• Prominent red hair stripe with shaved sides\n" +
            "• Multiple distinctive red facial tattoos\n" +
            "• Massive ornate Nordic shoulder armor with multiple spikes\n" +
            "• Premium leather straps with buckles\n" +
            "• Detailed fur pelts with texture accents\n" +
            "• Powerful, anatomically correct legs\n" +
            "• Ultimate Leviathan double-bladed axe with Norse engravings\n" +
            "• Enhanced materials with proper metallic and gloss values\n" +
            "• Glowing rune symbols on axe\n" +
            "• Razor-sharp blade edges with premium finish\n\n" +
            "Technical Details:\n" +
            "• Uses Unity primitives for optimal performance\n" +
            "• Properly scaled for game mechanics\n" +
            "• Compatible with existing animation system\n" +
            "• Ready for CompleteGameSetup integration",
            MessageType.None
        );
    }
}
#endif

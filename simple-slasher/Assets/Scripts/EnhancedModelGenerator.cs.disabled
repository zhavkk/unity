using UnityEngine;
using UnityEditor;

/// <summary>
/// Enhanced 3D model generator for God of War inspired characters.
/// Creates detailed Norse/Viking warrior models using Unity primitives.
/// </summary>
public class EnhancedModelGenerator
{
    /// <summary>
    /// Creates a detailed God of War inspired Norse warrior player model.
    /// Features: Red/orange skin, distinctive tattoos, Nordic armor, Leviathan Axe, red hair, fur pelts.
    /// </summary>
    public static GameObject CreateGodOfWarPlayerModel()
    {
        GameObject playerModel = new GameObject("GodOfWarPlayer");

        // ============================================
        // MAIN BODY - Massive and muscular
        // ============================================
        GameObject torso = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        torso.name = "Torso";
        torso.transform.SetParent(playerModel.transform);
        torso.transform.localPosition = new Vector3(0, 0.3f, 0);
        torso.transform.localScale = new Vector3(2.2f, 2.5f, 1.8f);
        torso.transform.rotation = Quaternion.Euler(0, 0, 90);

        // ============================================
        // HEAD - Red/orange skin with distinctive markings
        // ============================================
        GameObject head = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        head.name = "Head";
        head.transform.SetParent(playerModel.transform);
        head.transform.localPosition = new Vector3(0, 1.9f, 0);
        head.transform.localScale = new Vector3(1.1f, 1.2f, 1.0f);

        // Red hair (shaved sides with stripe)
        GameObject hair = GameObject.CreatePrimitive(PrimitiveType.Cube);
        hair.name = "Hair";
        hair.transform.SetParent(playerModel.transform);
        hair.transform.localPosition = new Vector3(0, 2.4f, 0);
        hair.transform.localScale = new Vector3(0.3f, 0.15f, 1.0f);

        // Distinctive red facial tattoos/markings
        GameObject tattooLeft = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tattooLeft.name = "TattooLeft";
        tattooLeft.transform.SetParent(playerModel.transform);
        tattooLeft.transform.localPosition = new Vector3(-0.35f, 1.9f, 0.5f);
        tattooLeft.transform.localScale = new Vector3(0.08f, 0.4f, 0.02f);
        tattooLeft.transform.rotation = Quaternion.Euler(30, 0, 0);

        GameObject tattooRight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tattooRight.name = "TattooRight";
        tattooRight.transform.SetParent(playerModel.transform);
        tattooRight.transform.localPosition = new Vector3(0.35f, 1.9f, 0.5f);
        tattooRight.transform.localScale = new Vector3(0.08f, 0.4f, 0.02f);
        tattooRight.transform.rotation = Quaternion.Euler(-30, 0, 0);

        // Forehead marking
        GameObject foreheadMark = GameObject.CreatePrimitive(PrimitiveType.Cube);
        foreheadMark.name = "ForeheadMark";
        foreheadMark.transform.SetParent(playerModel.transform);
        foreheadMark.transform.localPosition = new Vector3(0, 2.3f, 0.5f);
        foreheadMark.transform.localScale = new Vector3(0.5f, 0.08f, 0.02f);

        // ============================================
        // MASSIVE ARMS
        // ============================================
        // Left arm
        GameObject leftUpperArm = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftUpperArm.name = "LeftUpperArm";
        leftUpperArm.transform.SetParent(playerModel.transform);
        leftUpperArm.transform.localPosition = new Vector3(-1.3f, 0.5f, 0);
        leftUpperArm.transform.localScale = new Vector3(0.7f, 1.0f, 0.7f);
        leftUpperArm.transform.rotation = Quaternion.Euler(0, 0, -70);

        GameObject leftForearm = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftForearm.name = "LeftForearm";
        leftForearm.transform.SetParent(playerModel.transform);
        leftForearm.transform.localPosition = new Vector3(-1.8f, -0.1f, 0);
        leftForearm.transform.localScale = new Vector3(0.6f, 0.9f, 0.6f);
        leftForearm.transform.rotation = Quaternion.Euler(0, 0, -60);

        GameObject leftHand = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftHand.name = "LeftHand";
        leftHand.transform.SetParent(playerModel.transform);
        leftHand.transform.localPosition = new Vector3(-2.2f, -0.4f, 0);
        leftHand.transform.localScale = new Vector3(0.5f, 0.5f, 0.4f);

        // Right arm (larger for wielding axe)
        GameObject rightUpperArm = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightUpperArm.name = "RightUpperArm";
        rightUpperArm.transform.SetParent(playerModel.transform);
        rightUpperArm.transform.localPosition = new Vector3(1.3f, 0.5f, 0);
        rightUpperArm.transform.localScale = new Vector3(0.8f, 1.1f, 0.8f);
        rightUpperArm.transform.rotation = Quaternion.Euler(0, 0, 70);

        GameObject rightForearm = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightForearm.name = "RightForearm";
        rightForearm.transform.SetParent(playerModel.transform);
        rightForearm.transform.localPosition = new Vector3(1.9f, -0.1f, 0);
        rightForearm.transform.localScale = new Vector3(0.7f, 1.0f, 0.7f);
        rightForearm.transform.rotation = Quaternion.Euler(0, 0, 60);

        GameObject rightHand = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightHand.name = "RightHand";
        rightHand.transform.SetParent(playerModel.transform);
        rightHand.transform.localPosition = new Vector3(2.3f, -0.4f, 0);
        rightHand.transform.localScale = new Vector3(0.6f, 0.6f, 0.5f);

        // ============================================
        // NORVIC SHOULDER ARMOR - Massive and intimidating
        // ============================================
        // Left shoulder pad
        GameObject leftShoulderPad = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftShoulderPad.name = "LeftShoulderPad";
        leftShoulderPad.transform.SetParent(playerModel.transform);
        leftShoulderPad.transform.localPosition = new Vector3(-1.2f, 0.9f, 0);
        leftShoulderPad.transform.localScale = new Vector3(1.0f, 0.5f, 1.0f);
        leftShoulderPad.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Left shoulder spikes
        GameObject leftShoulderSpike1 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftShoulderSpike1.name = "LeftShoulderSpike1";
        leftShoulderSpike1.transform.SetParent(playerModel.transform);
        leftShoulderSpike1.transform.localPosition = new Vector3(-1.2f, 1.4f, 0);
        leftShoulderSpike1.transform.localScale = new Vector3(0.15f, 0.4f, 0.15f);

        GameObject leftShoulderSpike2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftShoulderSpike2.name = "LeftShoulderSpike2";
        leftShoulderSpike2.transform.SetParent(playerModel.transform);
        leftShoulderSpike2.transform.localPosition = new Vector3(-1.2f, 1.4f, 0.4f);
        leftShoulderSpike2.transform.localScale = new Vector3(0.15f, 0.3f, 0.15f);
        leftShoulderSpike2.transform.rotation = Quaternion.Euler(20, 0, 0);

        // Right shoulder pad (larger)
        GameObject rightShoulderPad = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightShoulderPad.name = "RightShoulderPad";
        rightShoulderPad.transform.SetParent(playerModel.transform);
        rightShoulderPad.transform.localPosition = new Vector3(1.3f, 0.9f, 0);
        rightShoulderPad.transform.localScale = new Vector3(1.2f, 0.6f, 1.2f);
        rightShoulderPad.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Right shoulder spikes (more prominent)
        GameObject rightShoulderSpike1 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightShoulderSpike1.name = "RightShoulderSpike1";
        rightShoulderSpike1.transform.SetParent(playerModel.transform);
        rightShoulderSpike1.transform.localPosition = new Vector3(1.3f, 1.5f, 0);
        rightShoulderSpike1.transform.localScale = new Vector3(0.18f, 0.5f, 0.18f);

        GameObject rightShoulderSpike2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightShoulderSpike2.name = "RightShoulderSpike2";
        rightShoulderSpike2.transform.SetParent(playerModel.transform);
        rightShoulderSpike2.transform.localPosition = new Vector3(1.3f, 1.5f, 0.5f);
        rightShoulderSpike2.transform.localScale = new Vector3(0.15f, 0.4f, 0.15f);
        rightShoulderSpike2.transform.rotation = Quaternion.Euler(25, 0, 0);

        GameObject rightShoulderSpike3 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightShoulderSpike3.name = "RightShoulderSpike3";
        rightShoulderSpike3.transform.SetParent(playerModel.transform);
        rightShoulderSpike3.transform.localPosition = new Vector3(1.3f, 1.5f, -0.5f);
        rightShoulderSpike3.transform.localScale = new Vector3(0.15f, 0.4f, 0.15f);
        rightShoulderSpike3.transform.rotation = Quaternion.Euler(-25, 0, 0);

        // ============================================
        // LEATHER STRAPS across chest
        // ============================================
        GameObject chestStrap1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        chestStrap1.name = "ChestStrap1";
        chestStrap1.transform.SetParent(playerModel.transform);
        chestStrap1.transform.localPosition = new Vector3(0, 0.6f, 0.95f);
        chestStrap1.transform.localScale = new Vector3(2.4f, 0.12f, 0.15f);

        GameObject chestStrap2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        chestStrap2.name = "ChestStrap2";
        chestStrap2.transform.SetParent(playerModel.transform);
        chestStrap2.transform.localPosition = new Vector3(0, 0.3f, 0.95f);
        chestStrap2.transform.localScale = new Vector3(2.4f, 0.12f, 0.15f);

        // Cross straps
        GameObject crossStrapLeft = GameObject.CreatePrimitive(PrimitiveType.Cube);
        crossStrapLeft.name = "CrossStrapLeft";
        crossStrapLeft.transform.SetParent(playerModel.transform);
        crossStrapLeft.transform.localPosition = new Vector3(-0.6f, 0.5f, 0.95f);
        crossStrapLeft.transform.localScale = new Vector3(0.12f, 0.8f, 0.15f);
        crossStrapLeft.transform.rotation = Quaternion.Euler(0, 0, 15);

        GameObject crossStrapRight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        crossStrapRight.name = "CrossStrapRight";
        crossStrapRight.transform.SetParent(playerModel.transform);
        crossStrapRight.transform.localPosition = new Vector3(0.6f, 0.5f, 0.95f);
        crossStrapRight.transform.localScale = new Vector3(0.12f, 0.8f, 0.15f);
        crossStrapRight.transform.rotation = Quaternion.Euler(0, 0, -15);

        // ============================================
        // FUR PELTS and Nordic details
        // ============================================
        // Back fur pelt
        GameObject backFur = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        backFur.name = "BackFur";
        backFur.transform.SetParent(playerModel.transform);
        backFur.transform.localPosition = new Vector3(0, 0.2f, -1.0f);
        backFur.transform.localScale = new Vector3(1.8f, 1.8f, 0.6f);
        backFur.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Waist fur
        GameObject waistFur = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        waistFur.name = "WaistFur";
        waistFur.transform.SetParent(playerModel.transform);
        waistFur.transform.localPosition = new Vector3(0, -0.5f, 0);
        waistFur.transform.localScale = new Vector3(2.5f, 0.4f, 2.0f);
        waistFur.transform.rotation = Quaternion.Euler(0, 0, 90);

        // ============================================
        // LEGS - Powerful and muscular
        // ============================================
        // Left leg
        GameObject leftThigh = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftThigh.name = "LeftThigh";
        leftThigh.transform.SetParent(playerModel.transform);
        leftThigh.transform.localPosition = new Vector3(-0.5f, -1.2f, 0);
        leftThigh.transform.localScale = new Vector3(0.9f, 1.3f, 0.9f);

        GameObject leftShin = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftShin.name = "LeftShin";
        leftShin.transform.SetParent(playerModel.transform);
        leftShin.transform.localPosition = new Vector3(-0.5f, -2.1f, 0);
        leftShin.transform.localScale = new Vector3(0.7f, 1.2f, 0.7f);

        GameObject leftFoot = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftFoot.name = "LeftFoot";
        leftFoot.transform.SetParent(playerModel.transform);
        leftFoot.transform.localPosition = new Vector3(-0.5f, -2.8f, 0.15f);
        leftFoot.transform.localScale = new Vector3(0.8f, 0.3f, 1.2f);

        // Right leg
        GameObject rightThigh = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightThigh.name = "RightThigh";
        rightThigh.transform.SetParent(playerModel.transform);
        rightThigh.transform.localPosition = new Vector3(0.5f, -1.2f, 0);
        rightThigh.transform.localScale = new Vector3(0.9f, 1.3f, 0.9f);

        GameObject rightShin = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightShin.name = "RightShin";
        rightShin.transform.SetParent(playerModel.transform);
        rightShin.transform.localPosition = new Vector3(0.5f, -2.1f, 0);
        rightShin.transform.localScale = new Vector3(0.7f, 1.2f, 0.7f);

        GameObject rightFoot = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightFoot.name = "RightFoot";
        rightFoot.transform.SetParent(playerModel.transform);
        rightFoot.transform.localPosition = new Vector3(0.5f, -2.8f, 0.15f);
        rightFoot.transform.localScale = new Vector3(0.8f, 0.3f, 1.2f);

        // Knee armor plates
        GameObject leftKnee = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftKnee.name = "LeftKnee";
        leftKnee.transform.SetParent(playerModel.transform);
        leftKnee.transform.localPosition = new Vector3(-0.5f, -1.7f, 0.2f);
        leftKnee.transform.localScale = new Vector3(0.5f, 0.5f, 0.4f);

        GameObject rightKnee = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightKnee.name = "RightKnee";
        rightKnee.transform.SetParent(playerModel.transform);
        rightKnee.transform.localPosition = new Vector3(0.5f, -1.7f, 0.2f);
        rightKnee.transform.localScale = new Vector3(0.5f, 0.5f, 0.4f);

        // ============================================
        // LEVIATHAN AXE - The iconic double-bladed axe
        // ============================================
        GameObject leviathanAxe = CreateLeviathanAxe();
        leviathanAxe.transform.SetParent(playerModel.transform);
        leviathanAxe.transform.localPosition = new Vector3(0.8f, 0.2f, 0.5f);
        leviathanAxe.transform.localRotation = Quaternion.Euler(0, -30, 90);

        // ============================================
        // Apply materials
        // ============================================
        ApplyGodOfWarPlayerMaterials(playerModel);

        return playerModel;
    }

    /// <summary>
    /// Creates a menacing God of War inspired enemy model (Draugr/Undead Nordic warrior).
    /// Features: Rotting appearance, decayed armor, ghostly blue eyes, rusted weapons.
    /// </summary>
    public static GameObject CreateGodOfWarEnemyModel()
    {
        GameObject enemyModel = new GameObject("DraugrWarrior");

        // ============================================
        // TWISTED BODY - Decaying and hunched
        // ============================================
        GameObject torso = GameObject.CreatePrimitive(PrimitiveType.Cube);
        torso.name = "Torso";
        torso.transform.SetParent(enemyModel.transform);
        torso.transform.localPosition = new Vector3(0, 0.2f, 0);
        torso.transform.localScale = new Vector3(1.8f, 2.2f, 1.5f);

        // Rib cage details (exposed bones)
        for (int i = 0; i < 3; i++)
        {
            GameObject rib = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            rib.name = "Rib_" + i;
            rib.transform.SetParent(enemyModel.transform);
            rib.transform.localPosition = new Vector3(0, 0.8f - (i * 0.3f), 0.8f);
            rib.transform.localScale = new Vector3(0.08f, 0.8f, 0.08f);
            rib.transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        // ============================================
        // DECAYED HEAD - Skull-like appearance
        // ============================================
        GameObject head = GameObject.CreatePrimitive(PrimitiveType.Cube);
        head.name = "Head";
        head.transform.SetParent(enemyModel.transform);
        head.transform.localPosition = new Vector3(0, 1.6f, 0);
        head.transform.localScale = new Vector3(0.9f, 1.0f, 0.9f);

        // Ghostly blue eyes (glowing)
        GameObject leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftEye.name = "LeftEye";
        leftEye.transform.SetParent(enemyModel.transform);
        leftEye.transform.localPosition = new Vector3(-0.2f, 1.7f, 0.4f);
        leftEye.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

        GameObject rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightEye.name = "RightEye";
        rightEye.transform.SetParent(enemyModel.transform);
        rightEye.transform.localPosition = new Vector3(0.2f, 1.7f, 0.4f);
        rightEye.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

        // Decaying jaw
        GameObject jaw = GameObject.CreatePrimitive(PrimitiveType.Cube);
        jaw.name = "Jaw";
        jaw.transform.SetParent(enemyModel.transform);
        jaw.transform.localPosition = new Vector3(0, 1.4f, 0.3f);
        jaw.transform.localScale = new Vector3(0.6f, 0.25f, 0.3f);

        // Cracked skull detail
        GameObject skullCrack = GameObject.CreatePrimitive(PrimitiveType.Cube);
        skullCrack.name = "SkullCrack";
        skullCrack.transform.SetParent(enemyModel.transform);
        skullCrack.transform.localPosition = new Vector3(0, 1.9f, 0.45f);
        skullCrack.transform.localScale = new Vector3(0.05f, 0.4f, 0.05f);

        // ============================================
        // BROKEN ARMOR - Decayed Nordic pieces
        // ============================================
        // Left shoulder armor (broken)
        GameObject leftShoulder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftShoulder.name = "LeftShoulder";
        leftShoulder.transform.SetParent(enemyModel.transform);
        leftShoulder.transform.localPosition = new Vector3(-1.0f, 0.6f, 0);
        leftShoulder.transform.localScale = new Vector3(0.7f, 0.4f, 0.7f);
        leftShoulder.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Broken armor piece
        GameObject leftArmorPiece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftArmorPiece.name = "LeftArmorPiece";
        leftArmorPiece.transform.SetParent(enemyModel.transform);
        leftArmorPiece.transform.localPosition = new Vector3(-1.0f, 0.6f, 0.5f);
        leftArmorPiece.transform.localScale = new Vector3(0.6f, 0.15f, 0.15f);

        // Right shoulder armor (larger, intact)
        GameObject rightShoulder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightShoulder.name = "RightShoulder";
        rightShoulder.transform.SetParent(enemyModel.transform);
        rightShoulder.transform.localPosition = new Vector3(1.0f, 0.6f, 0);
        rightShoulder.transform.localScale = new Vector3(0.9f, 0.5f, 0.9f);
        rightShoulder.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Nordic runes on shoulder
        GameObject rune1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rune1.name = "Rune1";
        rune1.transform.SetParent(enemyModel.transform);
        rune1.transform.localPosition = new Vector3(1.0f, 0.6f, 0.5f);
        rune1.transform.localScale = new Vector3(0.08f, 0.25f, 0.08f);

        GameObject rune2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rune2.name = "Rune2";
        rune2.transform.SetParent(enemyModel.transform);
        rune2.transform.localPosition = new Vector3(1.0f, 0.6f, -0.5f);
        rune2.transform.localScale = new Vector3(0.08f, 0.25f, 0.08f);

        // ============================================
        // TWISTED ARMS - Bony and clawed
        // ============================================
        // Left arm
        GameObject leftUpperArm = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftUpperArm.name = "LeftUpperArm";
        leftUpperArm.transform.SetParent(enemyModel.transform);
        leftUpperArm.transform.localPosition = new Vector3(-1.1f, 0.2f, 0);
        leftUpperArm.transform.localScale = new Vector3(0.4f, 0.8f, 0.4f);
        leftUpperArm.transform.rotation = Quaternion.Euler(0, 0, -60);

        GameObject leftForearm = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftForearm.name = "LeftForearm";
        leftForearm.transform.SetParent(enemyModel.transform);
        leftForearm.transform.localPosition = new Vector3(-1.5f, -0.3f, 0);
        leftForearm.transform.localScale = new Vector3(0.35f, 0.7f, 0.35f);
        leftForearm.transform.rotation = Quaternion.Euler(0, 0, -50);

        // Left claw hand
        GameObject leftClaw = CreateDraugrClaw();
        leftClaw.transform.SetParent(enemyModel.transform);
        leftClaw.transform.localPosition = new Vector3(-1.9f, -0.6f, 0);
        leftClaw.transform.localRotation = Quaternion.Euler(0, 0, -50);

        // Right arm
        GameObject rightUpperArm = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightUpperArm.name = "RightUpperArm";
        rightUpperArm.transform.SetParent(enemyModel.transform);
        rightUpperArm.transform.localPosition = new Vector3(1.1f, 0.2f, 0);
        rightUpperArm.transform.localScale = new Vector3(0.45f, 0.9f, 0.45f);
        rightUpperArm.transform.rotation = Quaternion.Euler(0, 0, 60);

        GameObject rightForearm = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightForearm.name = "RightForearm";
        rightForearm.transform.SetParent(enemyModel.transform);
        rightForearm.transform.localPosition = new Vector3(1.6f, -0.3f, 0);
        rightForearm.transform.localScale = new Vector3(0.4f, 0.8f, 0.4f);
        rightForearm.transform.rotation = Quaternion.Euler(0, 0, 50);

        // Right claw hand (larger)
        GameObject rightClaw = CreateDraugrClaw();
        rightClaw.transform.SetParent(enemyModel.transform);
        rightClaw.transform.localPosition = new Vector3(2.0f, -0.6f, 0);
        rightClaw.transform.localRotation = Quaternion.Euler(0, 0, 50);

        // ============================================
        // DECAYED LEGS - Bony and twisted
        // ============================================
        // Left leg
        GameObject leftThigh = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftThigh.name = "LeftThigh";
        leftThigh.transform.SetParent(enemyModel.transform);
        leftThigh.transform.localPosition = new Vector3(-0.4f, -1.0f, 0);
        leftThigh.transform.localScale = new Vector3(0.5f, 1.1f, 0.5f);

        GameObject leftShin = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftShin.name = "LeftShin";
        leftShin.transform.SetParent(enemyModel.transform);
        leftShin.transform.localPosition = new Vector3(-0.4f, -1.8f, 0);
        leftShin.transform.localScale = new Vector3(0.4f, 1.0f, 0.4f);

        GameObject leftFoot = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftFoot.name = "LeftFoot";
        leftFoot.transform.SetParent(enemyModel.transform);
        leftFoot.transform.localPosition = new Vector3(-0.4f, -2.4f, 0.1f);
        leftFoot.transform.localScale = new Vector3(0.5f, 0.25f, 0.8f);

        // Right leg
        GameObject rightThigh = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightThigh.name = "RightThigh";
        rightThigh.transform.SetParent(enemyModel.transform);
        rightThigh.transform.localPosition = new Vector3(0.4f, -1.0f, 0);
        rightThigh.transform.localScale = new Vector3(0.5f, 1.1f, 0.5f);

        GameObject rightShin = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightShin.name = "RightShin";
        rightShin.transform.SetParent(enemyModel.transform);
        rightShin.transform.localPosition = new Vector3(0.4f, -1.8f, 0);
        rightShin.transform.localScale = new Vector3(0.4f, 1.0f, 0.4f);

        GameObject rightFoot = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightFoot.name = "RightFoot";
        rightFoot.transform.SetParent(enemyModel.transform);
        rightFoot.transform.localPosition = new Vector3(0.4f, -2.4f, 0.1f);
        rightFoot.transform.localScale = new Vector3(0.5f, 0.25f, 0.8f);

        // ============================================
        // RUSTED WEAPON - Norse sword
        // ============================================
        GameObject rustedSword = CreateRustedSword();
        rustedSword.transform.SetParent(enemyModel.transform);
        rustedSword.transform.localPosition = new Vector3(1.5f, -0.2f, 0.4f);
        rustedSword.transform.localRotation = Quaternion.Euler(0, -20, 100);

        // ============================================
        // DECAY DETAILS - Holes and cracks
        // ============================================
        // Torso decay holes
        GameObject decayHole1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        decayHole1.name = "DecayHole1";
        decayHole1.transform.SetParent(enemyModel.transform);
        decayHole1.transform.localPosition = new Vector3(0.3f, 0.3f, 0.8f);
        decayHole1.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        GameObject decayHole2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        decayHole2.name = "DecayHole2";
        decayHole2.transform.SetParent(enemyModel.transform);
        decayHole2.transform.localPosition = new Vector3(-0.4f, -0.2f, 0.8f);
        decayHole2.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        // ============================================
        // Apply materials
        // ============================================
        ApplyGodOfWarEnemyMaterials(enemyModel);

        return enemyModel;
    }

    /// <summary>
    /// Creates the iconic Leviathan Axe - double-bladed Nordic axe with intricate details.
    /// </summary>
    private static GameObject CreateLeviathanAxe()
    {
        GameObject axe = new GameObject("LeviathanAxe");

        // ============================================
        // HANDLE - Long wooden shaft
        // ============================================
        GameObject handle = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        handle.name = "Handle";
        handle.transform.SetParent(axe.transform);
        handle.transform.localPosition = new Vector3(0, -0.5f, 0);
        handle.transform.localScale = new Vector3(0.12f, 2.0f, 0.12f);

        // Handle wrapping detail
        for (int i = 0; i < 4; i++)
        {
            GameObject handleWrap = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            handleWrap.name = "HandleWrap_" + i;
            handleWrap.transform.SetParent(axe.transform);
            handleWrap.transform.localPosition = new Vector3(0, -0.8f + (i * 0.3f), 0);
            handleWrap.transform.localScale = new Vector3(0.13f, 0.05f, 0.13f);
        }

        // ============================================
        // AXE HEAD - Massive double blade
        // ============================================
        GameObject axeHeadBase = GameObject.CreatePrimitive(PrimitiveType.Cube);
        axeHeadBase.name = "AxeHeadBase";
        axeHeadBase.transform.SetParent(axe.transform);
        axeHeadBase.transform.localPosition = new Vector3(0, 0.6f, 0);
        axeHeadBase.transform.localScale = new Vector3(0.5f, 0.6f, 0.3f);

        // Main left blade
        GameObject leftBlade = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftBlade.name = "LeftBlade";
        leftBlade.transform.SetParent(axe.transform);
        leftBlade.transform.localPosition = new Vector3(-0.6f, 0.6f, 0);
        leftBlade.transform.localScale = new Vector3(1.2f, 0.8f, 0.08f);

        // Left blade edge (sharp)
        GameObject leftBladeEdge = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftBladeEdge.name = "LeftBladeEdge";
        leftBladeEdge.transform.SetParent(axe.transform);
        leftBladeEdge.transform.localPosition = new Vector3(-1.2f, 0.6f, 0);
        leftBladeEdge.transform.localScale = new Vector3(0.04f, 0.8f, 0.04f);

        // Main right blade
        GameObject rightBlade = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightBlade.name = "RightBlade";
        rightBlade.transform.SetParent(axe.transform);
        rightBlade.transform.localPosition = new Vector3(0.6f, 0.6f, 0);
        rightBlade.transform.localScale = new Vector3(1.2f, 0.8f, 0.08f);

        // Right blade edge (sharp)
        GameObject rightBladeEdge = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightBladeEdge.name = "RightBladeEdge";
        rightBladeEdge.transform.SetParent(axe.transform);
        rightBladeEdge.transform.localPosition = new Vector3(1.2f, 0.6f, 0);
        rightBladeEdge.transform.localScale = new Vector3(0.04f, 0.8f, 0.04f);

        // Blade decorations (Norse patterns)
        for (int i = 0; i < 2; i++)
        {
            GameObject leftDeco = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            leftDeco.name = "LeftDeco_" + i;
            leftDeco.transform.SetParent(axe.transform);
            leftDeco.transform.localPosition = new Vector3(-0.8f + (i * 0.3f), 0.6f, 0.05f);
            leftDeco.transform.localScale = new Vector3(0.05f, 0.4f, 0.05f);
            leftDeco.transform.rotation = Quaternion.Euler(0, 0, i * 30);

            GameObject rightDeco = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            rightDeco.name = "RightDeco_" + i;
            rightDeco.transform.SetParent(axe.transform);
            rightDeco.transform.localPosition = new Vector3(0.8f - (i * 0.3f), 0.6f, 0.05f);
            rightDeco.transform.localScale = new Vector3(0.05f, 0.4f, 0.05f);
            rightDeco.transform.rotation = Quaternion.Euler(0, 0, i * -30);
        }

        // ============================================
        // AXE BUTT - Decorative end piece
        // ============================================
        GameObject axeButt = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        axeButt.name = "AxeButt";
        axeButt.transform.SetParent(axe.transform);
        axeButt.transform.localPosition = new Vector3(0, -1.6f, 0);
        axeButt.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        return axe;
    }

    /// <summary>
    /// Creates a Draugr claw hand with sharp, bony fingers.
    /// </summary>
    private static GameObject CreateDraugrClaw()
    {
        GameObject claw = new GameObject("DraugrClaw");

        // Palm base
        GameObject palm = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        palm.name = "Palm";
        palm.transform.SetParent(claw.transform);
        palm.transform.localScale = new Vector3(0.3f, 0.25f, 0.15f);

        // Sharp claw fingers
        for (int i = -1; i <= 1; i++)
        {
            GameObject finger = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            finger.name = "Finger_" + i;
            finger.transform.SetParent(claw.transform);
            finger.transform.localPosition = new Vector3(i * 0.12f, 0.15f, 0);
            finger.transform.localScale = new Vector3(0.04f, 0.25f, 0.04f);
            finger.transform.rotation = Quaternion.Euler(0, 0, -90);

            // Sharp tip (using cylinder as cone substitute)
            GameObject tip = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            tip.name = "Tip_" + i;
            tip.transform.SetParent(claw.transform);
            tip.transform.localPosition = new Vector3(i * 0.12f, 0.28f, 0);
            tip.transform.localScale = new Vector3(0.04f, 0.12f, 0.04f);
            tip.transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        return claw;
    }

    /// <summary>
    /// Creates a rusted Nordic sword.
    /// </summary>
    private static GameObject CreateRustedSword()
    {
        GameObject sword = new GameObject("RustedSword");

        // Handle
        GameObject handle = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        handle.name = "Handle";
        handle.transform.SetParent(sword.transform);
        handle.transform.localPosition = new Vector3(0, -0.3f, 0);
        handle.transform.localScale = new Vector3(0.08f, 0.6f, 0.08f);

        // Guard
        GameObject guard = GameObject.CreatePrimitive(PrimitiveType.Cube);
        guard.name = "Guard";
        guard.transform.SetParent(sword.transform);
        guard.transform.localPosition = new Vector3(0, 0, 0);
        guard.transform.localScale = new Vector3(0.5f, 0.08f, 0.12f);

        // Pommel
        GameObject pommel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        pommel.name = "Pommel";
        pommel.transform.SetParent(sword.transform);
        pommel.transform.localPosition = new Vector3(0, -0.7f, 0);
        pommel.transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);

        // Blade (rusted)
        GameObject blade = GameObject.CreatePrimitive(PrimitiveType.Cube);
        blade.name = "Blade";
        blade.transform.SetParent(sword.transform);
        blade.transform.localPosition = new Vector3(0, 0.7f, 0);
        blade.transform.localScale = new Vector3(0.15f, 1.4f, 0.05f);

        // Blade tip
        GameObject bladeTip = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        bladeTip.name = "BladeTip";
        bladeTip.transform.SetParent(sword.transform);
        bladeTip.transform.localPosition = new Vector3(0, 1.45f, 0);
        bladeTip.transform.localScale = new Vector3(0.15f, 0.2f, 0.05f);

        return sword;
    }

    /// <summary>
    /// Applies God of War player materials - red/orange skin, metallic armor, fur textures.
    /// </summary>
    private static void ApplyGodOfWarPlayerMaterials(GameObject playerModel)
    {
        // Red/orange skin tone
        Material skinMaterial = new Material(Shader.Find("Standard"));
        skinMaterial.color = new Color(0.85f, 0.35f, 0.2f);

        // Red tattoo markings
        Material tattooMaterial = new Material(Shader.Find("Standard"));
        tattooMaterial.color = new Color(0.9f, 0.1f, 0.1f);

        // Red hair
        Material hairMaterial = new Material(Shader.Find("Standard"));
        hairMaterial.color = new Color(0.8f, 0.15f, 0.05f);

        // Metallic armor (dark iron)
        Material armorMaterial = new Material(Shader.Find("Standard"));
        armorMaterial.color = new Color(0.2f, 0.2f, 0.25f);
        armorMaterial.SetFloat("_Metallic", 0.9f);
        armorMaterial.SetFloat("_Glossiness", 0.6f);

        // Leather straps
        Material leatherMaterial = new Material(Shader.Find("Standard"));
        leatherMaterial.color = new Color(0.35f, 0.25f, 0.15f);

        // Fur pelts (dark brown/grey)
        Material furMaterial = new Material(Shader.Find("Standard"));
        furMaterial.color = new Color(0.3f, 0.25f, 0.2f);

        // Knee armor (shiny metal)
        Material kneeMaterial = new Material(Shader.Find("Standard"));
        kneeMaterial.color = new Color(0.6f, 0.6f, 0.65f);
        kneeMaterial.SetFloat("_Metallic", 0.8f);
        kneeMaterial.SetFloat("_Glossiness", 0.7f);

        // Apply materials
        // Body parts
        ApplyMaterialToChild(playerModel, "Torso", skinMaterial);
        ApplyMaterialToChild(playerModel, "Head", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftUpperArm", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftForearm", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftHand", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightUpperArm", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightForearm", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightHand", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftThigh", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftShin", skinMaterial);
        ApplyMaterialToChild(playerModel, "LeftFoot", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightThigh", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightShin", skinMaterial);
        ApplyMaterialToChild(playerModel, "RightFoot", skinMaterial);

        // Tattoos and hair
        ApplyMaterialToChild(playerModel, "TattooLeft", tattooMaterial);
        ApplyMaterialToChild(playerModel, "TattooRight", tattooMaterial);
        ApplyMaterialToChild(playerModel, "ForeheadMark", tattooMaterial);
        ApplyMaterialToChild(playerModel, "Hair", hairMaterial);

        // Armor
        ApplyMaterialToChild(playerModel, "LeftShoulderPad", armorMaterial);
        ApplyMaterialToChild(playerModel, "LeftShoulderSpike1", armorMaterial);
        ApplyMaterialToChild(playerModel, "LeftShoulderSpike2", armorMaterial);
        ApplyMaterialToChild(playerModel, "RightShoulderPad", armorMaterial);
        ApplyMaterialToChild(playerModel, "RightShoulderSpike1", armorMaterial);
        ApplyMaterialToChild(playerModel, "RightShoulderSpike2", armorMaterial);
        ApplyMaterialToChild(playerModel, "RightShoulderSpike3", armorMaterial);
        ApplyMaterialToChild(playerModel, "LeftKnee", kneeMaterial);
        ApplyMaterialToChild(playerModel, "RightKnee", kneeMaterial);

        // Leather and fur
        ApplyMaterialToChild(playerModel, "ChestStrap1", leatherMaterial);
        ApplyMaterialToChild(playerModel, "ChestStrap2", leatherMaterial);
        ApplyMaterialToChild(playerModel, "CrossStrapLeft", leatherMaterial);
        ApplyMaterialToChild(playerModel, "CrossStrapRight", leatherMaterial);
        ApplyMaterialToChild(playerModel, "BackFur", furMaterial);
        ApplyMaterialToChild(playerModel, "WaistFur", furMaterial);

        // Axe materials
        Material axeHandleMaterial = new Material(Shader.Find("Standard"));
        axeHandleMaterial.color = new Color(0.4f, 0.25f, 0.15f);

        Material axeHeadMaterial = new Material(Shader.Find("Standard"));
        axeHeadMaterial.color = new Color(0.7f, 0.7f, 0.75f);
        axeHeadMaterial.SetFloat("_Metallic", 0.95f);
        axeHeadMaterial.SetFloat("_Glossiness", 0.9f);

        Transform axe = playerModel.transform.Find("LeviathanAxe");
        if (axe != null)
        {
            foreach (Transform child in axe)
            {
                if (child.name.Contains("Handle"))
                {
                    child.GetComponent<Renderer>().material = axeHandleMaterial;
                }
                else
                {
                    child.GetComponent<Renderer>().material = axeHeadMaterial;
                }
            }
        }
    }

    /// <summary>
    /// Applies God of War enemy materials - decaying flesh, ghostly eyes, rusted armor.
    /// </summary>
    private static void ApplyGodOfWarEnemyMaterials(GameObject enemyModel)
    {
        // Decaying flesh (grey-green)
        Material fleshMaterial = new Material(Shader.Find("Standard"));
        fleshMaterial.color = new Color(0.4f, 0.45f, 0.4f);

        // Bone material
        Material boneMaterial = new Material(Shader.Find("Standard"));
        boneMaterial.color = new Color(0.85f, 0.8f, 0.7f);

        // Ghostly blue glowing eyes
        Material eyeMaterial = new Material(Shader.Find("Standard"));
        eyeMaterial.color = new Color(0.3f, 0.8f, 1.0f);
        eyeMaterial.SetFloat("_EmissionIntensity", 1.0f);

        // Rusted armor
        Material rustedArmorMaterial = new Material(Shader.Find("Standard"));
        rustedArmorMaterial.color = new Color(0.4f, 0.3f, 0.2f);
        rustedArmorMaterial.SetFloat("_Metallic", 0.5f);
        rustedArmorMaterial.SetFloat("_Glossiness", 0.3f);

        // Nordic runes (glowing)
        Material runeMaterial = new Material(Shader.Find("Standard"));
        runeMaterial.color = new Color(0.6f, 0.2f, 0.8f);
        runeMaterial.SetFloat("_EmissionIntensity", 0.5f);

        // Rusted weapon
        Material rustedWeaponMaterial = new Material(Shader.Find("Standard"));
        rustedWeaponMaterial.color = new Color(0.5f, 0.35f, 0.25f);
        rustedWeaponMaterial.SetFloat("_Metallic", 0.4f);
        rustedWeaponMaterial.SetFloat("_Glossiness", 0.2f);

        // Decay holes (dark)
        Material decayMaterial = new Material(Shader.Find("Standard"));
        decayMaterial.color = new Color(0.15f, 0.1f, 0.1f);

        // Apply materials
        // Body parts
        ApplyMaterialToChild(enemyModel, "Torso", fleshMaterial);
        ApplyMaterialToChild(enemyModel, "Head", fleshMaterial);
        ApplyMaterialToChild(enemyModel, "Jaw", boneMaterial);
        ApplyMaterialToChild(enemyModel, "SkullCrack", decayMaterial);

        // Eyes
        ApplyMaterialToChild(enemyModel, "LeftEye", eyeMaterial);
        ApplyMaterialToChild(enemyModel, "RightEye", eyeMaterial);

        // Ribs
        for (int i = 0; i < 3; i++)
        {
            ApplyMaterialToChild(enemyModel, "Rib_" + i, boneMaterial);
        }

        // Arms and legs
        ApplyMaterialToChild(enemyModel, "LeftUpperArm", fleshMaterial);
        ApplyMaterialToChild(enemyModel, "LeftForearm", fleshMaterial);
        ApplyMaterialToChild(enemyModel, "RightUpperArm", fleshMaterial);
        ApplyMaterialToChild(enemyModel, "RightForearm", fleshMaterial);
        ApplyMaterialToChild(enemyModel, "LeftThigh", fleshMaterial);
        ApplyMaterialToChild(enemyModel, "LeftShin", fleshMaterial);
        ApplyMaterialToChild(enemyModel, "LeftFoot", fleshMaterial);
        ApplyMaterialToChild(enemyModel, "RightThigh", fleshMaterial);
        ApplyMaterialToChild(enemyModel, "RightShin", fleshMaterial);
        ApplyMaterialToChild(enemyModel, "RightFoot", fleshMaterial);

        // Armor
        ApplyMaterialToChild(enemyModel, "LeftShoulder", rustedArmorMaterial);
        ApplyMaterialToChild(enemyModel, "LeftArmorPiece", rustedArmorMaterial);
        ApplyMaterialToChild(enemyModel, "RightShoulder", rustedArmorMaterial);
        ApplyMaterialToChild(enemyModel, "Rune1", runeMaterial);
        ApplyMaterialToChild(enemyModel, "Rune2", runeMaterial);

        // Claws
        Transform leftClaw = enemyModel.transform.Find("DraugrClaw");
        if (leftClaw != null)
        {
            foreach (Transform child in leftClaw)
            {
                child.GetComponent<Renderer>().material = boneMaterial;
            }
        }

        Transform rightClaw = enemyModel.transform.Find("DraugrClaw(1)");
        if (rightClaw != null)
        {
            foreach (Transform child in rightClaw)
            {
                child.GetComponent<Renderer>().material = boneMaterial;
            }
        }

        // Weapon
        Transform sword = enemyModel.transform.Find("RustedSword");
        if (sword != null)
        {
            foreach (Transform child in sword)
            {
                child.GetComponent<Renderer>().material = rustedWeaponMaterial;
            }
        }

        // Decay holes
        ApplyMaterialToChild(enemyModel, "DecayHole1", decayMaterial);
        ApplyMaterialToChild(enemyModel, "DecayHole2", decayMaterial);
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
/// Editor window for enhanced God of War model generation.
/// </summary>
public class EnhancedModelGeneratorEditor : EditorWindow
{
    [MenuItem("Tools/Enhanced Model Generator/God of War Player")]
    public static void CreateGodOfWarPlayer()
    {
        GameObject player = EnhancedModelGenerator.CreateGodOfWarPlayerModel();
        player.transform.position = Vector3.zero;
        Selection.activeGameObject = player;
        Debug.Log("✅ God of War inspired Norse warrior created!");
    }

    [MenuItem("Tools/Enhanced Model Generator/Draugr Enemy")]
    public static void CreateDraugrEnemy()
    {
        GameObject enemy = EnhancedModelGenerator.CreateGodOfWarEnemyModel();
        enemy.transform.position = new Vector3(3, 0, 0);
        Selection.activeGameObject = enemy;
        Debug.Log("✅ Draugr enemy created!");
    }

    [MenuItem("Tools/Enhanced Model Generator/Show Window")]
    public static void ShowWindow()
    {
        GetWindow<EnhancedModelGeneratorEditor>("Enhanced Model Generator");
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("🪓 God of War Model Generator", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.HelpBox(
            "Creates detailed procedural models inspired by God of War.\n" +
            "Uses Unity primitives arranged artistically.",
            MessageType.Info
        );

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Player Models", EditorStyles.boldLabel);
        if (GUILayout.Button("Create Norse Warrior (Kratos-style)", GUILayout.Height(40)))
        {
            CreateGodOfWarPlayer();
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Enemy Models", EditorStyles.boldLabel);
        if (GUILayout.Button("Create Draugr Warrior", GUILayout.Height(40)))
        {
            CreateDraugrEnemy();
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Model Details", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox(
            "Norse Warrior Features:\n" +
            "• Red/orange skin tone\n" +
            "• Distinctive red facial tattoos\n" +
            "• Red hair stripe\n" +
            "• Massive Nordic armor\n" +
            "• Leviathan double-bladed axe\n" +
            "• Fur pelts and leather straps\n" +
            "• Powerful, muscular build\n\n" +
            "Draugr Enemy Features:\n" +
            "• Decaying flesh appearance\n" +
            "• Ghostly blue glowing eyes\n" +
            "• Rusted Nordic armor\n" +
            "• Sharp bony claws\n" +
            "• Rusted sword weapon\n" +
            "• Exposed rib cage details",
            MessageType.None
        );
    }
}
#endif

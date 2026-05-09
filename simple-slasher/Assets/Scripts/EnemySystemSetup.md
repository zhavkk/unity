# Enemy System Setup Guide

## Overview
This enemy system includes:
- **EnemyController**: Handles enemy AI, health, and attacks
- **PlayerHealth**: Manages player health and damage
- **PlayerAttract**: Handles attraction/dash mechanic
- **EnemySpawner**: Spawns enemies around the player

## Setup Instructions

### 1. Create Enemy Prefab
1. Create a new 3D object (e.g., Cube or Capsule)
2. Add `CapsuleCollider` component
3. Add `Rigidbody` component (use gravity, freeze rotation)
4. Add `EnemyController` script
5. Tag the object as "Enemy" (create this tag if needed)
6. Set layer to "Enemy" (create this layer if needed)
7. Save as prefab

**EnemyController Settings:**
- Max Health: 30
- Damage: 10
- Move Speed: 2
- Attack Range: 1.5
- Attack Cooldown: 1
- Health Bar Prefab: (optional) Create a UI Slider prefab
- Health Bar Offset: 1.5
- Hit Color: Red
- Hit Duration: 0.2

### 2. Setup Player
1. Find your player object
2. Tag it as "Player" (if not already)
3. Add `PlayerHealth` script
4. Add `PlayerAttract` script

**PlayerAttract Settings:**
- Dash Speed: 15
- Dash Duration: 0.3
- Attract Range: 20
- Enemy Layer: Set to "Enemy" layer
- Character Controller: Reference to player's CharacterController
- Player Input: Reference to player's PlayerInput component

**PlayerHealth Settings:**
- Max Health: 100

### 3. Create Enemy Spawner (Optional)
1. Create an empty GameObject called "EnemySpawner"
2. Add `EnemySpawner` script

**EnemySpawner Settings:**
- Enemy Prefab: Reference to your enemy prefab
- Spawn Count: 5
- Spawn Radius: 20
- Min Distance From Player: 5
- Auto Respawn: true
- Respawn Delay: 3

### 4. Setup Camera
Ensure your main camera has:
- Proper tagging as "MainCamera"
- The scene has a Camera component that can raycast

### 5. Input System Requirements
The attraction system uses the existing Input System:
- **Right Click** action (from UI map) - Click on enemy to dash toward it
- Make sure enemies are on the correct layer for raycasting

## How to Use

### Combat System
1. **Enemy Behavior**: Enemies automatically follow the player and attack when in range
2. **Player Damage**: When enemies attack, player health decreases (shown in console)
3. **Enemy Health**: Each enemy has 30 HP, displayed above them

### Attraction Mechanic (Key Feature)
1. **Right-click** on any enemy to dash toward it
2. The player quickly moves to the enemy's position
3. This allows chaining attacks by right-clicking on different enemies
4. Dash duration is 0.3 seconds at 15 units/second speed

### Enemy Death
1. When enemy health reaches 0, they flash red then despawn
2. If using EnemySpawner, new enemies respawn after 3 seconds

## Tips

### Visual Feedback
- Enemies flash red when hit
- Health bars appear above enemies
- Console logs show damage events

### Customization
- Adjust enemy stats in EnemyController
- Change dash speed/duration in PlayerAttract
- Modify spawn rate in EnemySpawner

### Troubleshooting
- **Enemies not moving**: Check if player has "Player" tag
- **Attraction not working**: Verify enemies are on correct layer
- **No health bars**: Assign a health bar prefab or create a simple one
- **Raycast issues**: Check camera setup and enemy layer mask

## Example Scene Setup

1. Create a ground plane
2. Place player with PlayerHealth and PlayerAttract components
3. Place EnemySpawner in scene
4. Add enemy prefab to spawner
5. Run scene and test!

## Notes
- The attraction system works with Unity's new Input System
- Enemy AI is simple and direct - they move straight toward the player
- Health system uses simple UI Sliders for display
- All scripts include debug logging for easy troubleshooting

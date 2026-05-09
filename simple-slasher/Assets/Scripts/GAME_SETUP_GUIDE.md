# Complete Game Setup Guide

## Overview
This guide will help you set up a complete wave-based combat game with rage mechanics and enemy attraction system.

## What You Have

All scripts are already created in `Assets/Scripts/`:
- `PlayerController.cs` - Player movement, attacks, and stats
- `PlayerAttract.cs` - Enemy attraction/dash system
- `EnemyController.cs` - Enemy AI and combat
- `RageSystem.cs` - Rage meter and bonuses
- `WaveManager.cs` - Wave spawning and progression
- `PlayerHealth.cs` - Player health component
- `EnemyHealth.cs` - Enemy health component

## Step-by-Step Setup (15 minutes)

### Step 1: Create Player GameObject (5 min)

1. **Create Player:**
   ```
   1. Right-click in Hierarchy → 3D Object → Capsule
   2. Name it "Player"
   3. Set scale to (1, 2, 1)
   4. Tag as "Player"
   ```

2. **Add Components:**
   ```
   1. Add Component → CharacterController
   2. Set Radius: 0.5, Height: 2
   3. Add Component → PlayerController
   4. Add Component → PlayerAttract
   5. Add Component → RageSystem
   6. Add Component → PlayerHealth
   ```

3. **Configure PlayerController:**
   ```
   - Walk Speed: 5
   - Sprint Speed: 8
   - Jump Force: 8
   - Base Damage: 10
   - Base Attack Speed: 1
   - Attack Range: 2
   - Enemy Layer: Create "Enemy" layer and assign it
   - Attack Point: Create empty child object, position at (0, 1, 1.5)
   ```

4. **Configure PlayerAttract:**
   ```
   - Dash Speed: 15
   - Dash Duration: 0.3
   - Dash Range: 20
   - Enemy Layer: "Enemy" layer
   ```

5. **Configure RageSystem:**
   ```
   - Max Rage: 100
   - Default values work fine
   ```

6. **Add Visuals (Optional):**
   ```
   1. Create child GameObject "AttackVisual"
   2. Add MeshRenderer (red sphere or cube)
   3. Scale: (1, 1, 1)
   4. Position: (0, 1, 1.5)
   5. Disable initially (toggle in Inspector)
   ```
   Then modify PlayerController.cs to enable/disable this visual during attacks.

### Step 2: Create Enemy Prefab (5 min)

1. **Create Enemy GameObject:**
   ```
   1. Right-click in Hierarchy → 3D Object → Capsule
   2. Name it "Enemy"
   3. Set scale to (1, 1.5, 1)
   4. Tag as "Enemy"
   5. Set Layer to "Enemy"
   ```

2. **Add Components:**
   ```
   1. Add Component → CapsuleCollider (default is fine)
   2. Add Component → Rigidbody
   3. Configure Rigidbody:
      - Mass: 1
      - Drag: 0
      - Angular Drag: 0.05
      - Use Gravity: Yes
      - Is Kinematic: No
      - Constraints: Freeze Rotation X, Y, Z
   4. Add Component → EnemyController
   ```

3. **Configure EnemyController:**
   ```
   - Health: 30
   - Damage: 10
   - Speed: 2
   - Attack Range: 1.5
   - Attack Cooldown: 1
   - Damage Cooldown: 0.5
   - Detection Range: 50
   ```

4. **Save as Prefab:**
   ```
   1. Drag "Enemy" from Hierarchy to Assets/Scripts/ (or create Assets/Prefabs/)
   2. Delete Enemy from scene (only use prefab)
   ```

### Step 3: Create Wave Manager (3 min)

1. **Create WaveManager GameObject:**
   ```
   1. Right-click in Hierarchy → Create Empty
   2. Name it "WaveManager"
   ```

2. **Add WaveManager Component:**
   ```
   1. Add Component → WaveManager
   2. Configure:
      - Player: Assign your Player GameObject
      - Enemy Prefab: Assign the Enemy prefab you created
      - Initial Enemy Count: 3
      - Enemy Count Increase: 2
      - Spawn Radius Min: 10
      - Spawn Radius Max: 20
      - Delay Between Waves: 5
   ```

### Step 4: Set Up Camera (1 min)

1. **Configure Main Camera:**
   ```
   1. Select Main Camera
   2. Set Position: (0, 5, -10)
   3. Set Rotation: (15, 0, 0)
   4. Tag: "MainCamera" (important for raycasting)
   ```

### Step 5: Create Ground (1 min)

1. **Create Ground:**
   ```
   1. Right-click in Hierarchy → 3D Object → Plane
   2. Name it "Ground"
   3. Scale: (20, 1, 20)
   4. Position: (0, 0, 0)
   ```

## Testing the Game

### Basic Movement Test:
1. Press Play
2. Use WASD to move
3. Hold Left Shift to sprint
4. Press Space to jump
5. Left-click to attack (check Console for damage messages)

### Combat Test:
1. WaveManager spawns enemies automatically
2. Enemies will follow and attack you
3. Left-click enemies to deal damage
4. Right-click enemies to dash toward them (attraction mechanic)

### Rage System Test:
1. Attack enemies repeatedly to build rage
2. Watch rage increase (check Console)
3. Notice damage and attack speed increase
4. Get hit by enemies to see rage decrease
5. Stop attacking for 3+ seconds to see rage decay

### Wave System Test:
1. Defeat all enemies in current wave
2. Wait 5 seconds
3. Next wave spawns with more enemies
4. Continue until player dies

## Integration Notes

### Connecting Systems:
All systems are already integrated through:
- **PlayerController** ↔ **RageSystem**: OnStart() finds RageSystem on same GameObject
- **PlayerController** ↔ **PlayerAttract**: Both reference same CharacterController
- **WaveManager** ↔ **EnemyController**: WaveManager spawns prefabs with EnemyController
- **EnemyController** ↔ **PlayerHealth**: Enemy attacks call PlayerHealth.TakeDamage()

### Input System:
All scripts use the existing Input System configuration:
- **PlayerController**: Uses "Player" action map
- **PlayerAttract**: Uses "UI.RightClick" action

### Debug Information:
All scripts output to Console:
- "Player attacked for X damage"
- "Enemy attacked player for X damage"
- "Rage: X, Damage Multiplier: Y"
- "Dashing to enemy at position"
- "Wave X started"

## Troubleshooting

### Player can't move:
- Check CharacterController is attached
- Ensure ground has collider
- Check Console for errors

### Enemies don't follow player:
- Verify Player is tagged "Player"
- Check EnemyController is attached
- Ensure Enemy has Rigidbody with gravity

### Attraction not working:
- Check Camera has "MainCamera" tag
- Verify Enemy layer is set correctly
- Ensure PlayerAttract component is attached
- Check Console for "Dashing to enemy" messages

### Rage system not working:
- Ensure RageSystem is on same GameObject as PlayerController
- Check Console for rage updates
- Verify OnStart() in PlayerController finds RageSystem

### Wave manager not working:
- Ensure Enemy prefab is assigned
- Check Player is assigned to WaveManager
- Verify Player has Health component
- Check Console for wave start messages

## Customization Options

### Adjust Difficulty:
```
EnemyController:
- Health: Increase for harder enemies
- Damage: Increase for more challenge
- Speed: Increase for faster enemies

WaveManager:
- Initial Enemy Count: Start with more enemies
- Enemy Count Increase: Make waves scale faster
- Spawn Radius: Change enemy spawn distance
- Delay Between Waves: Shorten for faster pace
```

### Adjust Rage System:
```
RageSystem:
- Max Rage: Increase for longer rage buildup
- Rage Increase Per Attack: More = faster rage build
- Rage Decay Per Second: Lower = rage lasts longer
- Damage On Taking Hit: Increase for more rage penalty
```

### Adjust Player Combat:
```
PlayerController:
- Base Damage: Increase for easier combat
- Base Attack Speed: Higher = faster attacks
- Attack Range: Increase for easier hits
```

## Next Steps for Improvement

1. **Visual Feedback:** Add attack animations, particles, or screen shake
2. **UI:** Create rage bar, health bar, and wave counter UI
3. **Enemy Variety:** Create different enemy types with different stats
4. **Audio:** Add sound effects for attacks, hits, and rage buildup
5. **Skills:** Add special attacks that consume rage
6. **Level Design:** Create different arenas with obstacles

## Summary

You now have a complete wave-based combat game with:
- ✅ Dynamic player movement (WASD, sprint, jump)
- ✅ Enemy attraction system (right-click dash)
- ✅ Rage mechanics (buildup, bonuses, decay)
- ✅ Wave spawning and progression
- ✅ Basic combat (attack, damage, health)

All systems are integrated and ready to play!

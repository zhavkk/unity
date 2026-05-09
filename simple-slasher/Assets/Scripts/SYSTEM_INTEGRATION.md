# Complete Game System Integration Guide

## Game Overview
A wave-based 3D action game featuring dynamic enemy attraction and rage mechanics.

## Core Mechanics

### 1. Dynamic Movement & Combat
- **Movement**: WASD with sprint (Left Shift) and jump (Space)
- **Combat**: Left-click to attack enemies within range
- **Enemy Attraction**: Right-click on enemies to dash toward them quickly

### 2. Rage System
- **Build Rage**: Attacking enemies increases rage (+5 per attack)
- **Rage Bonuses**:
  - 0-100 rage scale
  - Damage: 1x to 3x (at max rage)
  - Attack Speed: 1x to 2x (at max rage)
- **Rage Decay**:
  - -10 per second after 3 seconds of inactivity
  - -20 when taking damage

### 3. Wave System
- **Progressive Difficulty**: Waves start with 3 enemies, increase by 2 each wave
- **Automatic Spawning**: 5-second delay between waves
- **Game Over**: When player health reaches 0

## System Architecture

### Component Hierarchy

```
Player GameObject:
├── PlayerController.cs          # Movement, attacks, stats
├── PlayerAttract.cs            # Enemy attraction/dash system
├── RageSystem.cs              # Rage meter and bonuses
├── PlayerHealth.cs             # Player health management
└── GameIntegrator.cs           # System integration hub

WaveManager GameObject:
└── WaveManager.cs             # Wave spawning and progression

Enemy Prefab:
├── EnemyController.cs          # Enemy AI and behavior
└── EnemyHealth.cs             # Enemy health management
```

### Event System

**PlayerController Events:**
- `OnPlayerAttack` - Triggered when player performs attack
- `OnPlayerTakeDamage` - Triggered with damage amount when hit
- `OnPlayerDeath` - Triggered when player dies

**PlayerHealth Events:**
- `OnPlayerDeath` - Triggered when health reaches 0

**Integration Flow:**
1. Player attacks → OnPlayerAttack → RageSystem.OnPlayerAttack()
2. Player hit → OnPlayerTakeDamage → RageSystem.OnPlayerTakeDamage()
3. Rage changes → RageSystem.ModifyRage() → PlayerController.ApplyRageBonuses()
4. Player dies → OnPlayerDeath → GameIntegrator.HandlePlayerDeath() → WaveManager.StopGame()

## Setup Instructions

### Step 1: Create Player (5 minutes)

```
1. Create Capsule, name it "Player", tag as "Player"
2. Add CharacterController (Radius: 0.5, Height: 2)
3. Add Components:
   - PlayerController
   - PlayerAttract
   - RageSystem
   - PlayerHealth
   - GameIntegrator
4. Create child "AttackPoint" at (0, 1, 1.5)
5. Configure PlayerController:
   - Attack Range: 2
   - Enemy Layer: "Enemy"
   - Attack Point: Assign AttackPoint
```

### Step 2: Create Enemy Prefab (3 minutes)

```
1. Create Capsule, name it "Enemy", tag as "Enemy", layer "Enemy"
2. Add Components:
   - CapsuleCollider
   - Rigidbody (Freeze Rotation X/Y/Z)
   - EnemyController
   - EnemyHealth
3. Drag to Assets/Scripts/ to create prefab
4. Delete from scene
```

### Step 3: Create Wave Manager (2 minutes)

```
1. Create Empty GameObject "WaveManager"
2. Add WaveManager component
3. Configure:
   - Player: Assign Player GameObject
   - Enemy Prefab: Assign Enemy prefab
```

### Step 4: Environment (1 minute)

```
1. Create Plane "Ground" (scale: 20, 1, 20)
2. Configure Main Camera:
   - Position: (0, 5, -10)
   - Rotation: (15, 0, 0)
   - Tag: "MainCamera"
```

## Testing the Integration

### Test 1: Basic Movement
- Press Play
- Use WASD to move
- Press Space to jump
- Hold Left Shift to sprint
- Console should show movement events

### Test 2: Combat System
- WaveManager spawns 3 enemies
- Enemies follow player
- Left-click enemies to attack
- Check Console for "Attack performed!" and damage messages
- Enemies flash red and die when health reaches 0

### Test 3: Attraction Mechanic
- Right-click on any enemy
- Check Console for "Dashing to enemy at position..."
- Player quickly moves toward target enemy
- Can chain attacks between multiple enemies

### Test 4: Rage System
- Attack enemies repeatedly
- Check GUI (top-left) for rage progression
- Watch damage multipliers increase
- Get hit by enemies → rage decreases
- Stop attacking for 3+ seconds → rage decays

### Test 5: Wave System
- Defeat all enemies in wave
- Wait 5 seconds
- Next wave spawns with 2 more enemies
- Defeat player → game over
- UI shows "Waves Survived"

## Troubleshooting

### Integration Issues

**Events not firing:**
- Ensure GameIntegrator is on Player GameObject
- Check that PlayerController has event declarations
- Verify OnEnable/OnDisable are calling event subscriptions

**Rage system not working:**
- Check RageSystem is on same GameObject as PlayerController
- Verify SetPlayerController() is called in GameIntegrator.Start()
- Check Console for "Rage bonuses applied!" messages

**Wave manager not detecting player death:**
- Ensure Player has PlayerHealth component
- Check that PlayerHealth has OnPlayerDeath event
- Verify GameIntegrator subscribes to OnPlayerDeath

**Enemy attraction not working:**
- Check Camera has "MainCamera" tag
- Verify Enemy layer is set correctly in PlayerAttract
- Ensure enemy is within 20 units

### Component Dependencies

**PlayerController requires:**
- CharacterController
- Transform (attack point)

**PlayerAttract requires:**
- CharacterController
- Main Camera (for raycasting)
- Enemy layer (for targeting)

**RageSystem requires:**
- PlayerController (for applying bonuses)
- Optional: Slider and Image for UI

**WaveManager requires:**
- Player GameObject with "Player" tag
- PlayerHealth component on player
- Enemy prefab with EnemyHealth

## Default Stats

### Player
- Health: 100
- Base Damage: 10
- Base Attack Speed: 1.0 attacks/sec
- Movement Speed: 5 (walk), 8 (sprint)
- Jump Force: 8
- Attack Range: 2 units

### Rage System
- Max Rage: 100
- Rage per Attack: +5
- Rage Decay: -10/sec (inactive)
- Rage on Damage: -20
- Max Damage Multiplier: 3x
- Max Attack Speed Multiplier: 2x

### Enemy
- Health: 30
- Damage: 10 per hit
- Speed: 2 units/sec
- Attack Range: 1.5 units
- Attack Cooldown: 1 second
- Detection Range: 50 units

### Wave System
- Starting Enemies: 3
- Enemy Increase: 2 per wave
- Wave Delay: 5 seconds
- Spawn Radius: 10-20 units

## Debug Information

All systems provide Console output:

**PlayerController:**
- "Attack performed! Damage: X (Base: Y x Z)"
- "Player took X damage! Current health: Y"
- "Player died!"

**PlayerAttract:**
- "Dashing to enemy at position: X, Y, Z"
- "Dash completed!"

**RageSystem:**
- "Rage bonuses applied! Damage: xY, Speed: xZ"
- GUI shows rage, damage multiplier, attack speed

**WaveManager:**
- "Wave X starting with Y enemies"
- "Game Over! You survived X waves."

**EnemyController:**
- "EnemyName took X damage. Health: Y/Z"
- "EnemyName died!"

## Customization

### Adjust Difficulty

**Easier:**
- Reduce enemy damage (EnemyController)
- Increase player damage (PlayerController)
- Increase rage gain rate (RageSystem)

**Harder:**
- Increase enemy speed and damage
- Reduce player base damage
- Decrease rage bonuses

### Modify Gameplay

**Faster Combat:**
- Increase base attack speed
- Reduce attack cooldown on enemies
- Shorten wave delay

**Slower Combat:**
- Decrease base attack speed
- Increase enemy attack cooldown
- Lengthen wave delay

### Custom Enemies

Create different enemy types by:
1. Duplicating Enemy prefab
2. Changing stats in EnemyController
3. Modifying visuals (scale, color, materials)
4. Adjusting AI behavior (speed, range, damage)

## Integration Checklist

Before testing, verify:
- [ ] Player is tagged "Player"
- [ ] Enemy is tagged "Enemy" and on "Enemy" layer
- [ ] Camera is tagged "MainCamera"
- [ ] All components are properly assigned
- [ ] No Console errors
- [ ] Ground plane exists with collider
- [ ] AttackPoint child exists on Player

## Next Development Steps

1. **UI Enhancement**: Add rage bar, health bar, wave counter to Canvas
2. **Visual Feedback**: Attack animations, particle effects, screen shake
3. **Audio**: Sound effects for attacks, hits, rage buildup
4. **Enemy Variety**: Different enemy types with unique behaviors
5. **Skills**: Special abilities that consume rage
6. **Progression**: Unlockable skills, upgrades, character stats
7. **Level Design**: Multiple arenas with obstacles and terrain

## Summary

This game system provides:
- ✅ Fully integrated combat with dynamic movement
- ✅ Enemy attraction system for combo chaining
- ✅ Rage mechanics with offensive bonuses
- ✅ Wave-based progression with increasing difficulty
- ✅ Complete event system for system communication
- ✅ Debug output for troubleshooting

All systems are production-ready and can be customized to suit your game design needs!

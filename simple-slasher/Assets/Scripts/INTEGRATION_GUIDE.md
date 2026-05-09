# Enemy Controller System - Integration Guide

## Overview
This document explains how the new Enemy Controller system integrates with the existing PlayerController and RageSystem.

## Created Files

### Core Enemy Scripts
1. **EnemyController.cs** - Complete enemy AI with health, movement, and attacks
2. **PlayerAttract.cs** - Attraction/dash mechanic (right-click to dash to enemies)
3. **PlayerHealth.cs** - Standalone player health component
4. **EnemySpawner.cs** - Enemy spawning system

### Documentation
5. **EnemySystemSetup.md** - Complete setup instructions
6. **INTEGRATION_GUIDE.md** - This file

## Integration with Existing Scripts

### PlayerController Integration
The existing `PlayerController.cs` already has:
- Health system (maxHealth, currentHealth)
- Attack system (baseDamage, attackRange)
- Rage system integration
- Input system setup

**Compatibility**: The new EnemyController works with PlayerController's existing attack system.

### EnemyController Features
- **Health System**: 30 HP default, with visual health bar display
- **Movement**: Simple AI that follows player at 2 units/second
- **Attacks**: 10 damage per hit, 1.5 unit range, 1 second cooldown
- **Visual Feedback**: Red flash when hit, health bar above enemy
- **Death**: Despawns when health reaches 0

### PlayerAttract (Key Feature)
- **Input**: Uses Unity Input System's "RightClick" action
- **Mechanic**: Right-click on any enemy to dash toward them
- **Stats**: 15 units/second dash speed, 0.3 second duration
- **Range**: 20 unit detection radius
- **Purpose**: Enables dynamic combo chains by quickly closing distance to enemies

## Setup Instructions

### Step 1: Enemy Prefab Setup
1. Create a 3D object (Cube/Capsule)
2. Add components:
   - CapsuleCollider
   - Rigidbody (Gravity enabled, Freeze Rotation)
   - EnemyController script
3. Tag: "Enemy" (create if needed)
4. Layer: "Enemy" (create if needed)
5. Save as prefab

**EnemyController Settings:**
- Max Health: 30
- Damage: 10
- Move Speed: 2
- Attack Range: 1.5
- Attack Cooldown: 1

### Step 2: Player Integration
Your PlayerController already has most functionality. Add:

**Option A: Use Existing PlayerController Health**
The PlayerController already has a TakeDamage method. Modify EnemyController to use it:

```csharp
// In EnemyController.cs, modify the AttackPlayer method:
private void AttackPlayer()
{
    lastAttackTime = Time.time;

    PlayerController player = playerTransform.GetComponent<PlayerController>();
    if (player != null)
    {
        player.TakeDamage(damage);
    }
}
```

**Option B: Use Separate PlayerHealth Component**
Add the PlayerHealth script as a separate component on the player.

### Step 3: Add PlayerAttract Component
1. Select your player object
2. Add `PlayerAttract` script
3. Configure settings:
   - Dash Speed: 15
   - Dash Duration: 0.3
   - Attract Range: 20
   - Enemy Layer: Set to "Enemy" layer
   - Character Controller: Drag reference
   - Player Input: Drag reference

### Step 4: Enemy Spawner (Optional)
1. Create empty GameObject "EnemySpawner"
2. Add `EnemySpawner` script
3. Assign enemy prefab
4. Configure spawn settings

## Gameplay Mechanics

### Combat Flow
1. Enemies spawn and move toward player
2. Player can attack enemies (using PlayerController's existing attack system)
3. When enemies attack player, damage is dealt
4. When player attacks enemies, damage is dealt and visual feedback shown

### Attraction Combo System
This is the key mechanic that makes combat dynamic:

1. **Right-click** on Enemy A → Player dashes to Enemy A
2. **Attack** Enemy A (left-click or attack key) → Deal damage
3. **Right-click** on Enemy B → Player dashes to Enemy B
4. **Attack** Enemy B → Deal damage
5. Repeat to chain combos across multiple enemies

### Advantages of Attraction System
- **Fast Combat**: Quickly close distance to enemies
- **Strategic Positioning**: Move between enemies efficiently
- **Combo Potential**: Chain attacks across multiple targets
- **Skill Expression**: Mastery of timing and target selection

## Enemy Stats Reference

### EnemyController
| Stat | Value | Description |
|------|-------|-------------|
| Max Health | 30 | Total health points |
| Damage | 10 | Damage dealt to player per hit |
| Move Speed | 2 | Movement speed toward player |
| Attack Range | 1.5 | Range to attack player |
| Attack Cooldown | 1 | Seconds between attacks |

### PlayerAttract
| Stat | Value | Description |
|------|-------|-------------|
| Dash Speed | 15 | Speed of dash movement |
| Dash Duration | 0.3 | Seconds dash lasts |
| Attract Range | 20 | Max distance to detect enemies |

## Input System Integration

The attraction system uses Unity's Input System:

**Required Actions:**
- `RightClick` (from UI map) - Used for attraction dash
- `Point` (from UI map) - Used for mouse position tracking

**Note:** The existing PlayerController uses Player map actions (Move, Jump, Sprint, Attack).
The PlayerAttract uses UI map actions (RightClick, Point).

## Visual Feedback System

### Enemy Hit Feedback
- **Color Change**: Enemies flash red when hit
- **Duration**: 0.2 seconds
- **Auto-Restore**: Original color returns automatically

### Health Display
- **Position**: Above enemy (1.5 units offset)
- **Type**: UI Slider (can use prefab or simple creation)
- **Real-time**: Updates immediately when damage taken

## Troubleshooting

### Common Issues

**Attraction not working:**
- Check if PlayerAttract component is on player
- Verify enemy layer is set correctly
- Ensure camera can raycast to enemies
- Check if RightClick action exists in Input System

**Enemies not attacking player:**
- Verify player has "Player" tag
- Check if PlayerController has TakeDamage method
- Ensure enemies are in attack range (1.5 units)

**Enemies not moving:**
- Check Rigidbody settings (gravity on, freeze rotation)
- Verify player has "Player" tag
- Ensure move speed is not zero

**Health bars not showing:**
- Assign health bar prefab in EnemyController
- Or let it create simple health bar automatically
- Check camera position

## Performance Notes

### Optimization Tips
- Limit active enemies (10-20 recommended)
- Use object pooling for frequent spawning/despawning
- Simple AI keeps performance cost low
- Health bars use efficient UI system

### Scalability
- Current system supports 5-20 enemies easily
- More enemies may require:
  - Simple collision detection
  - Object pooling
  - Spatial partitioning

## Future Enhancements

### Potential Additions
1. **Enemy Types**: Different stats and behaviors
2. **Attack Animations**: Visual flair for attacks
3. **Particle Effects**: Death/hit particles
4. **Sound Effects**: Combat audio
5. **Boss Enemies**: Special mechanics
6. **Enemy Pathfinding**: A* for complex environments
7. **Combo System**: Track and reward combos

### Integration with RageSystem
The existing RageSystem can be enhanced with the attraction mechanic:
- Each successful attract adds rage
- Chain attracts for bonus rage
- Spend rage for special attacks
- Visual feedback for rage buildup

## Summary

The Enemy Controller system provides:
- Complete enemy AI with health and attacks
- Dynamic attraction mechanic for combo-based combat
- Visual feedback for all interactions
- Easy integration with existing PlayerController
- Scalable performance for multiple enemies

The attraction system is the key feature that makes combat engaging and skill-based, allowing players to create dynamic combos by strategically dashing between enemies.

# Enemy Controller - Quick Start

## What Was Created

### Core Scripts
- **EnemyController.cs** (292 lines) - Complete enemy AI with health, movement, and attacks
- **PlayerAttract.cs** (160 lines) - Attraction/dash mechanic (right-click to enemies)
- **PlayerHealth.cs** (45 lines) - Standalone player health component
- **EnemySpawner.cs** (91 lines) - Enemy spawning system

### Documentation
- **EnemySystemSetup.md** - Detailed setup instructions
- **INTEGRATION_GUIDE.md** - Integration with existing systems
- **QUICKSTART.md** - This file

## Quick Setup (5 Minutes)

### 1. Create Enemy Prefab
```
1. Create Cube/Capsule
2. Add: CapsuleCollider, Rigidbody, EnemyController
3. Tag: "Enemy", Layer: "Enemy"
4. Save as prefab
```

### 2. Update Player
```
1. Find your PlayerController
2. Add PlayerAttract component
3. Set: Dash Speed=15, Duration=0.3, Range=20
4. Assign: CharacterController, PlayerInput, Enemy Layer
```

### 3. Test
```
1. Place enemy prefab in scene
2. Run game
3. Enemy follows you and attacks
4. Right-click on enemy to dash toward it
```

## Key Features

### Enemy Behavior
- Auto-follows player (2 units/sec)
- Attacks when close (1.5 range, 10 damage, 1 sec cooldown)
- 30 HP with health bar display
- Flashes red when hit
- Dies when health reaches 0

### Attraction System (Main Feature)
- Right-click any enemy to dash toward them
- Fast dash (15 units/sec, 0.3 sec duration)
- 20 unit detection range
- Enables combo chains between enemies

## Integration Notes

- Works with existing PlayerController's health system
- Uses Unity Input System (RightClick action from UI map)
- Compatible with existing RageSystem
- No conflicts with existing EnemyHealth.cs

## Default Stats

**Enemy:**
- Health: 30
- Damage: 10
- Speed: 2
- Attack Range: 1.5
- Cooldown: 1s

**Attract:**
- Dash Speed: 15
- Duration: 0.3s
- Range: 20

## Important Setup Points

1. **Tags**: Player must be tagged "Player", Enemy must be tagged "Enemy"
2. **Layers**: Enemy layer must be set for raycasting
3. **Input System**: Ensure "RightClick" and "Point" actions exist
4. **Camera**: MainCamera tag required for raycasting

## Common Issues

**Attraction not working?**
- Check enemy layer in PlayerAttract
- Verify camera has MainCamera tag
- Ensure enemy is within 20 units

**Enemies not moving?**
- Check Rigidbody (gravity on, freeze rotation)
- Verify player has "Player" tag
- Ensure enemy isn't blocked

**No health bars?**
- Assign health bar prefab OR
- Let system create simple bar automatically

## Next Steps

1. Test basic combat
2. Test attraction mechanic
3. Try chaining attacks between enemies
4. Add EnemySpawner for continuous combat
5. Customize stats for game balance

## Documentation Files

- **EnemySystemSetup.md** - Full setup with screenshots details
- **INTEGRATION_GUIDE.md** - How it works with existing systems
- **QUICKSTART.md** - This quick reference

## Support

All scripts include debug logging:
- "Enemy attacked player for X damage"
- "Dashing to enemy at position"
- "Dash completed"

Check Console for troubleshooting!

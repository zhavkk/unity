# Enemy Models - Quick Start Guide

## Immediate Usage

### In Unity Editor:
1. **Open Model Generator Window:**
   - Menu: `Tools > Model Generator > Show Window`

2. **Create Enemy Models:**
   - Click "Create Normal Enemy (Demon)" for standard melee enemy
   - Click "Create Fast Enemy (Feral)" for quick, agile enemy
   - Click "Create Tank Enemy (Armored)" for big, slow enemy
   - Click "Create Ranged Enemy (Archer)" for distance attacker

### Alternative Menu Access:
- `Tools > Model Generator > Create Normal Enemy`
- `Tools > Model Generator > Create Fast Enemy`
- `Tools > Model Generator > Create Tank Enemy`
- `Tools > Model Generator > Create Ranged Enemy`

### In Code:
```csharp
// Create complete enemy with AI
GameObject enemy = EnemyFactory.CreateEnemy(EnemyFactory.EnemyType.Fast, position);

// Create just the visual model
GameObject model = ModelGenerator.CreateEnemyModel(EnemyFactory.EnemyType.Tank);
```

## Visual Reference

| Type | Colors | Key Features | Height |
|------|--------|--------------|---------|
| **Normal** | Red/Black | Horns, claws, armor | Medium |
| **Fast** | Yellow/Brown | Pointed ears, tail, sharp claws | Tall/Thin |
| **Tank** | Dark Red/Gray | Helmet, spikes, massive mace | Very Tall |
| **Ranged** | Cyan/Purple | Three eyes, crossbow, crystals | Tall |

## Testing

### Quick Test:
1. Create empty GameObject
2. Add `EnemyModelTest.cs` component
3. Press Play
4. All 4 enemy types spawn automatically

### Manual Test:
- Press `1` - Spawn Normal Enemy
- Press `2` - Spawn Fast Enemy
- Press `3` - Spawn Tank Enemy
- Press `4` - Spawn Ranged Enemy

## Enemy Behaviors

- **Normal**: Balanced melee attacker
- **Fast**: Quick, strafing, rapid attacks
- **Tank**: Slow, charging, devastating damage
- **Ranged**: Keeps distance, fires projectiles

## Common Issues

**Models don't appear:**
- Check Console for compilation errors
- Verify `ModelGenerator.cs` is in `Assets/Scripts/`

**Wrong colors:**
- Ensure URP is active in Project Settings
- Check that Standard shader is available

**Scale problems:**
- Models auto-scale with enemy `modelScale` parameter
- Adjust in enemy class if needed

## Tips

- Use Scene view to inspect model hierarchy
- Check materials in Inspector for color tuning
- Test in Play mode to see full enemy behavior
- Models work with existing enemy AI and combat systems

## Support

See `ENEMY_MODELS_README.md` for detailed documentation.

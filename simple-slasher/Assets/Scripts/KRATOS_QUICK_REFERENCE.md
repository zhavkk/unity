# Kratos Model Quick Reference

## 🎯 Quick Start (3 Ways)

### Method 1: Automatic (Easiest)
1. Open your scene
2. Create empty GameObject
3. Add `CompleteGameSetup` component
4. Press Play
5. ✅ Kratos model appears automatically

### Method 2: Manual Integration
1. Select your Player GameObject
2. Add `KratosModelIntegrator` component
3. Click "Integrate Kratos Model" button
4. ✅ Model added to your player

### Method 3: Editor Tool
1. Go to `Tools > Kratos Model Generator > Ultimate Kratos`
2. ✅ Model created at scene origin
3. Drag to position as needed

## 📁 Files Created

```
Assets/Scripts/
├── KratosModelGenerator.cs          # Main model generator
├── KratosModelIntegrator.cs         # Easy integration component
├── KratosModelTest.cs               # Testing & verification
├── KRATOS_MODEL_GUIDE.md            # Complete documentation
├── KRATOS_MODEL_IMPLEMENTATION_SUMMARY.md  # Technical details
└── KRATOS_QUICK_REFERENCE.md        # This file
```

## 🪓 Model Features

- **80+ Components**: Highly detailed procedural model
- **Muscular Build**: Defined pecks, abs, biceps, quads, calves
- **Kratos Face**: Red skin, tattoos, red hair stripe
- **Nordic Armor**: Massive shoulder armor with spikes
- **Leather & Fur**: Straps, buckles, pelts
- **Leviathan Axe**: Double-bladed with Norse runes
- **10 Materials**: Premium PBR materials

## 🎮 Integration Points

### PlayerController
```csharp
// Model works with these animations:
animator.SetFloat("Speed", moveSpeed);
animator.SetTrigger("Jump");
animator.SetTrigger("Attack");
animator.SetTrigger("TakeDamage");
animator.SetBool("IsGrounded", isGrounded);
```

### CharacterController
```csharp
// Recommended settings:
height = 2.0f;
radius = 0.5f;
center = new Vector3(0, 1, 0);
```

### Combat System
```csharp
// Access axe for combat:
KratosModelIntegrator integrator = GetComponent<KratosModelIntegrator>();
Transform axe = integrator.GetAxeTransform();
```

## 🔧 Common Tasks

### Change Model Scale
```csharp
// In Inspector, set localScale to:
(1.2, 1.2, 1.2) // 20% larger
(0.8, 0.8, 0.8) // 20% smaller
```

### Access Body Parts
```csharp
KratosModelIntegrator integrator = GetComponent<KratosModelIntegrator>();
Transform head = integrator.GetHeadTransform();
Transform rightHand = integrator.GetRightHandTransform();
Transform axe = integrator.GetAxeTransform();
```

### Test Model
1. Create empty GameObject
2. Add `KratosModelTest` component
3. Press Play
4. Use on-screen GUI to test

### Remove Model
```csharp
KratosModelIntegrator integrator = GetComponent<KratosModelIntegrator>();
integrator.RemoveKratosModel();
```

## 🎨 Customization

### Change Colors
Edit `KratosModelGenerator.cs`:
```csharp
// Line ~685 - Skin color
skinMaterial.color = new Color(0.88f, 0.38f, 0.25f);

// Line ~691 - Tattoo color
tattooMaterial.color = new Color(0.95f, 0.15f, 0.15f);
```

### Add Accessories
```csharp
GameObject helmet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
helmet.name = "Helmet";
helmet.transform.SetParent(playerModel.transform);
helmet.transform.localPosition = new Vector3(0, 2.5f, 0);
```

## 🐛 Troubleshooting

### Model Not Appearing
- Check Unity Console for errors
- Verify `KratosModelGenerator.cs` is in `Assets/Scripts/`
- Ensure no compilation errors

### Materials Look Wrong
- Verify using URP or Standard Shader
- Check scene lighting
- Confirm Graphics settings

### Animation Issues
- Check Animator component is present
- Verify parameter names match
- Ensure model hierarchy is intact

## 📊 Model Specs

- **Height**: 3.1 units (~2.0m)
- **Width**: 2.8 units
- **Components**: 80+
- **Materials**: 10 unique
- **Draw Calls**: ~80
- **Load Time**: Instant

## 🚀 Performance Tips

1. **Use LOD System**: Different detail levels at distances
2. **Combine Meshes**: Reduce draw calls for static models
3. **Material Batching**: Already optimized (few materials)
4. **Occlusion Culling**: Enable for large scenes

## 📚 Documentation

- **Complete Guide**: `KRATOS_MODEL_GUIDE.md`
- **Technical Details**: `KRATOS_MODEL_IMPLEMENTATION_SUMMARY.md`
- **Quick Reference**: This file

## 🎯 Best Practices

1. **Use KratosModelIntegrator**: Easiest integration method
2. **Test First**: Use KratosModelTest for verification
3. **Scale Carefully**: Model is sized for gameplay
4. **Preserve Hierarchy**: Don't reorder model components
5. **Backup**: Save scene before major changes

## 🔗 Related Systems

- **CompleteGameSetup**: Auto-integration
- **PlayerController**: Animation control
- **EnhancedPlayerController**: Enhanced features
- **CharacterController**: Physics movement
- **AnimationController**: Animation system

## 💡 Pro Tips

1. **Rage Mode**: Change material colors for visual feedback
2. **Damage Effects**: Darken skin based on health
3. **Weapon Swap**: Access axe transform for changes
4. **Procedural Animation**: Rotate body parts dynamically
5. **Sound Effects**: Add to key body parts

## 🆘 Need Help?

1. Check `KRATOS_MODEL_GUIDE.md` for detailed info
2. Use `KratosModelTest` for diagnostics
3. Examine `KratosModelGenerator.cs` for implementation
4. Review Unity Console for errors

---

**Status**: ✅ Production Ready
**Compatibility**: Unity 6000.4.2f1+, URP
**Performance**: Optimized for gameplay
**Documentation**: Comprehensive

*Last Updated: April 26, 2026*
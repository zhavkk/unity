# 🚀 Быстрая шпаргалка - Quick Reference

## ⚡ С чего начать (ОТКРОЙТЕ ЭТО ПЕРВЫМ!)

### 📄 Главный файл для настройки:
**`SCENE_SETUP_MANUAL.md`** - Пошаговая инструкция за 5 минут

---

## 🎮 Управление в игре

| Клавиша | Действие |
|----------|----------|
| WASD | Движение |
| Space | Прыжок |
| Left Shift | Спринт |
| ЛКМ | Атака |
| ПКМ | Притяжение к врагу |

---

## 🔧 Быстрая настройка сцены

### 1. Создайте слой "Enemy"
`Edit → Project Settings → Tags and Layers → Назовите пустой слой "Enemy"`

### 2. Создайте игрока
```
- Создайте Capsule → назовите "Player", тег "Player"
- Добавьте: CharacterController, PlayerController, PlayerAttract, RageSystem, PlayerHealth, GameIntegrator
- Создайте дочерний "AttackPoint" (0, 1, 1.5)
- В PlayerController: Attack Point = AttackPoint, Enemy Layer = Enemy
```

### 3. Создайте префаб врага
```
- Создайте Capsule → назовите "Enemy", тег "Enemy", слой "Enemy"
- Добавьте: CapsuleCollider, Rigidbody (заморозьте вращение), EnemyController, EnemyHealth
- Сохраните как префаб, удалите из сцены
```

### 4. Создайте WaveManager
```
- Создайте Empty → назовите "WaveManager"
- Добавьте: WaveManager
- Player = ваш игрок, Enemy Prefab = ваш префаб врага
```

### 5. Окружение
```
- Создайте Plane → назовите "Ground", масштаб (20, 1, 20)
- Main Camera: позиция (0, 5, -10), тег "MainCamera"
- Создайте Directional Light
```

---

## 📁 Важные файлы

### Для настройки:
- ⭐ **`SCENE_SETUP_MANUAL.md`** - Главное руководство (с НАЧАЛА!)
- `PROJECT_SUMMARY_RU.md` - Обзор проекта

### Для решения проблем:
- 🔧 **`TROUBLESHOOTING_RU.md`** - Решение всех проблем

### Для понимания системы:
- `SYSTEM_INTEGRATION.md` - Архитектура (EN)
- `GAME_SETUP_GUIDE.md` - Детальная настройка (EN)

---

## 🎯 Основные механики

### Система ярости:
- **Накопление:** +5 за атаку
- **Бонусы:** Урон до 3x, Скорость атак до 2x
- **Распад:** -10/сек (бездействие), -20 (получение урона)

### Притяжение:
- **Действие:** ПКМ на врага → рывок к нему
- **Диапазон:** 20 единиц
- **Скорость:** 15 единиц/сек

### Волны:
- **Начало:** 3 врага
- **Увеличение:** +2 врага на волну
- **Пауза:** 5 секунд

---

## 🐛 Частые проблемы

| Проблема | Быстрое решение |
|----------|----------------|
| Не движется | Проверьте CharacterController и Ground |
| Враги не спавнятся | Проверьте тег Player и PlayerHealth |
| Атака не работает | Проверьте AttackPoint и слой Enemy |
| Притяжение не работает | Проверьте тег MainCamera |
| Rage не работает | Проверьте GameIntegrator на игроке |

---

## 🔍 Диагностика

### 1. Проверьте консоль Unity
`Window → General → Console`
- Ищите красные ошибки
- Исправьте первые ошибки

### 2. Проверьте компоненты на Player:
- [ ] CharacterController
- [ ] PlayerController
- [ ] PlayerAttract
- [ ] RageSystem
- [ ] PlayerHealth
- [ ] GameIntegrator
- [ ] AttackPoint (дочерний объект)

### 3. Проверьте слои и теги:
- [ ] Слой "Enemy" создан
- [ ] Player тег = "Player"
- [ ] Враг тег = "Enemy", слой = "Enemy"

### 4. Проверьте WaveManager:
- [ ] Player назначен
- [ ] Enemy Prefab назначен

---

## 🎨 Настройка сложности

### Проще:
```csharp
// EnemyController
damage = 5;           // Меньше урона
moveSpeed = 1;         // Медленнее

// PlayerController
baseDamage = 20;       // Больше урона
baseAttackSpeed = 1.5f; // Быстрее атаки
```

### Сложнее:
```csharp
// EnemyController
damage = 20;          // Больше урона
moveSpeed = 3;         // Быстрее

// PlayerController
baseDamage = 5;        // Меньше урона
baseAttackSpeed = 0.5f; // Медленнее атаки
```

---

## ✅ Чеклист перед запуском

**Сцена:**
- [ ] Player создан с правильными компонентами
- [ ] Enemy префаб создан
- [ ] WaveManager создан
- [ ] Ground, Camera, Light существуют

**Слои/теги:**
- [ ] Слой Enemy создан
- [ ] Player тег = Player
- [ ] Враги тег = Enemy, слой = Enemy

**Настройки:**
- [ ] AttackPoint создан и назначен
- [ ] Enemy Layer выбран везде
- [ ] Camera тег = MainCamera

---

## 📞 Где найти помощь

### Проблемы с настройкой:
1. **`SCENE_SETUP_MANUAL.md`** - следуйте инструкции
2. **`TROUBLESHOOTING_RU.md`** - ищите решение
3. Консоль Unity - читайте ошибки

### Ничего не помогает:
- Проверьте компоненты (выше)
- Проверьте слои и теги (выше)
- Попробуйте создать сцену заново
- Проверьте версию Unity (6000.4.2f1)

---

## 🎉 Готово!

**Ваш проект полностью готов!**

1. Откройте `SCENE_SETUP_MANUAL.md`
2. Выполните шаги (5 минут)
3. Нажмите Play и играйте!

**Удачи!** 🚀🎮

# 🔧 Исправление ошибки InputSystem_Actions

## ❌ Ошибка:
```
Assets/Scripts/PlayerController.cs(39,13): error CS0246:
The type or namespace name 'InputSystem_Actions' could not be found
```

## ✅ Решение (2 способа)

### Способ 1: Автоматическая генерация (Рекомендуется)

**Шаг 1: Найдите файл InputSystem_Actions.inputactions**
В Unity Project найдите:
```
Assets/InputSystem_Actions.inputactions
```

**Шаг 2: Откройте его**
Двойной клик на файле → откроется редактор Input System

**Шаг 3: Сгенерируйте C# класс**
В редакторе Input System:
1. Найдите кнопку **"Generate C# Class"** или **"Generate"**
2. Нажмите на неё
3. Выберите место сохранения (по умолчанию `Assets/`)
4. Нажмите **Save**

**Шаг 4: Подтвердите генерацию**
Unity создаст файл:
```
Assets/InputSystem_Actions.cs
```

**Шаг 5: Проверьте компиляцию**
Ошибка должна исчезнуть!

---

### Способ 2: Настройка через Project Settings

**Шаг 1: Откройте Project Settings**
```
Edit → Project Settings
```

**Шаг 2: Перейдите к Input System**
В левой панели найдите и выберите:
```
XR Plug-in Management → Input System Package (Windows)
```

**Шаг 3: Настройте генерацию**
Найдите раздел **"Generate C# Classes"**:
- ✅ Убедитесь, что галочка включена
- ✅ Путь должен быть `Assets/`

**Шаг 4: Сохраните и перезапустите Unity**
1. Сохраните Project Settings
2. Закройте Unity
3. Откройте Unity снова
4. Файл `InputSystem_Actions.cs` будет сгенерирован автоматически

---

## 🔍 Проверка результата

После генерации проверьте:

**В Project должен быть файл:**
- [ ] `Assets/InputSystem_Actions.cs`

**В консоли не должно быть ошибок:**
- [ ] Нет красных ошибок
- [ ] Ошибка CS0246 исчезла

**PlayerController должен компилироваться:**
- [ ] В инспекторе PlayerController виден без ошибок

---

## 🎯 Быстрая проверка

**Откройте файл `Assets/InputSystem_Actions.cs`** и проверьте, что он существует и содержит класс:

```csharp
using UnityEngine;
using UnityEngine.InputSystem;

#if UNITY_EDITOR
[UnityEditor.InitializeOnLoad]
#endif
public class InputSystem_Actions : IInputActionCollection2
{
    // ... много кода ...
}
```

Если файл существует и содержит этот класс - всё правильно! ✅

---

## 🐛 Если всё равно не работает

### Проблема: Нет кнопки "Generate C# Class"

**Решение:**
1. Убедитесь, что установлен пакет Input System:
   ```
   Window → Package Manager
   → Input System
   → Нажмите Install (если не установлен)
   ```
2. Убедитесь, что включен Input System:
   ```
   Edit → Project Settings → Player
   → Active Input Handling: Both или Input System Package (New)
   ```

### Проблема: Файл генерируется, но ошибка остаётся

**Решение:**
1. Перезапустите Unity полностью
2. Удалите `Library` папку (кроме asmdef файлов)
3. Откройте Unity снова
4. Попробуйте снова сгенерировать

### Проблема: Не могу открыть .inputactions файл

**Решение:**
1. Убедитесь, что установлен Input System Package
2. Проверьте Package Manager:
   ```
   Window → Package Manager
   → Packages: In Project
   → Input System (версия 1.x.x)
   ```
3. Если не установлен - установите

---

## 📋 Полный процесс исправления

### Быстрый чеклист:

1. [ ] Открыл файл `Assets/InputSystem_Actions.inputactions`
2. [ ] Открылся редактор Input System
3. [ ] Нашёл кнопку "Generate C# Class"
4. [ ] Нажал на кнопку
5. [ ] Файл `Assets/InputSystem_Actions.cs` создан
6. [ ] Ошибка CS0246 исчезла из консоли
7. [ ] Скрипты компилируются без ошибок

---

## 🎮 После исправления

Когда ошибка исправлена:

1. ✅ Консоль не показывает красных ошибок
2. ✅ Все скрипты компилируются
3. ✅ Можно запускать авто-настройку сцены
4. ✅ Можно играть!

---

## 💡 Дополнительная информация

**Что такое InputSystem_Actions.cs?**
Это автоматически сгенерированный C# класс, который предоставляет код для управления через Unity Input System.

**Зачем он нужен?**
Все скрипты (PlayerController, PlayerAttract и т.д.) используют этот класс для обработки ввода (WASD, мышь, геймпад).

**Как он создаётся?**
Unity генерирует его автоматически из файла `.inputactions`, когда вы нажимаете кнопку "Generate C# Class".

---

## 📞 Если ничего не помогает

Попробуйте:

1. **Переустановить Input System:**
   ```
   Window → Package Manager
   → Input System
   → Remove
   → Install снова
   ```

2. **Создать новый проект Input System:**
   ```
   Edit → Project Settings → XR Plug-in Management
   → Input System Package (New)
   → Tick "Create new Input System Actions asset"
   → Generate C# Class
   ```

3. **Временное решение:**
   Если ничего не помогает, можете использовать старую систему ввода (потребует переписать PlayerController), но это не рекомендуется.

---

## ✅ Успех!

После генерации `InputSystem_Actions.cs`:

1. ✅ Ошибка CS0246 исчезнет
2. ✅ Все скрипты будут компилироваться
3. ✅ Можно использовать авто-настройку сцены
4. ✅ Можно играть в игру!

**Попробуйте снова запустить авто-настройку сцены!** 🚀

---

**Если возникнут другие проблемы, читайте `TROUBLESHOOTING_RU.md`** 📚

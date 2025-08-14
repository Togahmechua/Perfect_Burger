# Perfect Burger

<!-- App Icon + Description -->
<p align="center">
  <img width="180" height="180" alt="app icon" src="https://github.com/user-attachments/assets/3c1bd135-10ba-457e-918f-b22aafd79311" />
</p>

**Perfect Burger** is a fast-paced, satisfying cooking game where you stack buns, meat, cheese, veggies, and sauces **in the exact order** customers request.  
Nail the recipe to earn points and boost satisfaction; miss a layer and you’ll have to recover fast.  
As levels rise, ingredients drop faster and orders get trickier—can you keep the rhythm and become the **Burger King**?

---

## ✨ Features
- 🧱 Precision stacking with recipe-by-index validation  
- ⚡ Increasing difficulty: faster drops, tougher orders  
- 🏆 Combos, score multipliers, and level progression  
- 🎨 Crisp 2D visuals, juicy feedback, and haptics (mobile)  
- 📱 Optimized for portrait screens (iPhone & iPad)

## 🎮 How to Play
1. Watch the order card and remember the sequence.  
2. Tap/drag to add the correct ingredient for the current index.  
3. Build the perfect stack to complete the burger and score big!

---

## 📸 Screenshots (1080 × 1920)

| | | | | |
|---|---|---|---|---|
| <img width="140" height="336" src="https://github.com/user-attachments/assets/cbc5fb78-72b5-4fa2-84fe-0f4eaafaa3ce" /> | <img width="140" height="336" src="https://github.com/user-attachments/assets/946194fe-6452-453a-82c7-b5faf01baadb" /> | <img width="140" height="336" src="https://github.com/user-attachments/assets/fc96f79d-c2fd-4b16-ac1b-7b06734c6e80" /> | <img width="140" height="336" src="https://github.com/user-attachments/assets/032fdce3-a6aa-49cc-94bf-da29717d7050" /> | <img width="140" height="336" src="https://github.com/user-attachments/assets/b09ab241-d77c-4ff4-a9f4-222a29924b72" /> |
| <img width="140" height="336" src="https://github.com/user-attachments/assets/fbb29b32-fd01-427f-b1b2-e9bb90b85cc3" /> | <img width="140" height="336" src="https://github.com/user-attachments/assets/267d99eb-49e9-4da5-88d5-517304f9ddc3" /> | <img width="140" height="336" src="https://github.com/user-attachments/assets/05a761ea-db03-4178-92a7-7e31bf0cdd09" /> | <img width="140" height="336" src="https://github.com/user-attachments/assets/60254b61-3083-495f-b75d-40844e2fd5d4" /> | <img width="140" height="336" src="https://github.com/user-attachments/assets/9a7ac60e-8c75-4821-a52f-b712e0d4be23" /> |

---

## 📦 Store Description (Short)
Create perfectly stacked burgers in a race against time!  
Match each ingredient to the order, score combos, and climb through challenging levels.  
Easy to play, hard to master—Perfect Burger will test your memory, speed, and precision.

---

## 🛠 Tech Notes (Unity)
- Portrait setup with dynamic `UnitsSize` based on aspect ratio  
- **Object Pooling** for spawning and reusing ingredients efficiently  
- **ScriptableObject** (`RecipeSO`) to store and manage burger recipes  
- **Mobile Haptics**: `Handheld.Vibrate()` for basic vibration + controller/XR haptics when available  
- **Screen Shake** effect to enhance impact feedback  
- Sprite sorting by stack index for correct ingredient layering  
- Recipe validation by comparing `currentIngredientIndex` against `RecipeSO.ingredients`

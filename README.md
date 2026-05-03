# 🛡️ SecurIT Memory

## 📌 Description

**SecurIT Memory** est un mini-jeu de Memory développé en **C# avec Windows Forms**.

Le projet a été réalisé dans le cadre du **Salon de l'Innovation Tech** pour une start-up fictive spécialisée en cybersécurité : **SecurIT**.

🎯 **Objectif :**
Retrouver toutes les paires de cartes représentant des éléments liés à la cybersécurité :

* 🔐 Mot de passe
* 🛡️ Pare-feu
* 🦠 Virus
* 🔒 Cadenas
* 🌐 Réseau
* 🔑 Chiffrement

---

## 🚀 Fonctionnalités

* 🎮 Menu principal (Jouer / Options / Quitter)
* 🧩 Grille dynamique
* 📏 Mode 4x4 et 6x6
* 🔀 Mélange aléatoire des cartes
* 🖱️ Interaction au clic
* 🔎 Détection automatique des paires
* ⏳ Timer pour cacher les erreurs
* ⏱️ Chronomètre de partie
* 🎯 Compteur d’essais
* 🏆 Détection de victoire
* 🖥️ Interface graphique WinForms

---

## 🛠️ Technologies utilisées

* C#
* .NET Framework
* Windows Forms
* Microsoft Visual Studio
* GitHub

---

## 📂 Structure du projet

```text
SecurITMemory/
├── Carte.cs
├── EtatCarte.cs
├── JeuMemory.cs
├── Form1.cs
├── Program.cs
└── README.md
```

---

## 🧠 Concepts utilisés

* Programmation orientée objet (POO)
* Classes et propriétés
* Enumérations
* Listes
* Événements WinForms
* Gestion des timers
* Génération dynamique d’interface

---

## 🧩 Classe principale : Carte

La classe **Carte** représente une carte du jeu.

Elle contient :

* un identifiant de paire
* un symbole cybersécurité
* un état : **Cachée / Révélée / Trouvée**

👉 Permet une architecture claire et modulaire.

---

## ⚙️ Logique du jeu

1. Génération des paires
2. Mélange aléatoire
3. Affichage dans la grille
4. Clic utilisateur → révélation
5. Comparaison :

   * ✔ Identiques → restent visibles
   * ❌ Différentes → cachées après délai
6. Fin de partie → toutes les paires trouvées

---

## ▶️ Lancer le projet

1. Ouvrir **Microsoft Visual Studio**
2. Ouvrir le fichier :

   ```
   SecurITMemory.sln
   ```
3. Lancer avec :

   ```
   F5
   ```

---

## 👨‍💻 Auteurs

Projet réalisé en binôme :

* **MVE Christ**
* **Chachou Amine**

---

## 🎤 Contexte

Ce projet répond à un besoin marketing de la start-up **SecurIT** :

👉 Créer un mini-jeu interactif pour attirer les visiteurs lors d’un salon tech.

✔ Simple
✔ Rapide
✔ Ludique
✔ Thématique cybersécurité

---

## 📈 Améliorations possibles

* 🏆 Classement des scores
* 💾 Base de données SQL
* 🔊 Effets sonores
* 🎨 Thèmes graphiques
* 🔥 Mode difficile

---

## 📊 Présentation

📎 La présentation du projet est disponible ici :

👉 **Presentation_SecurITMemory.pdf**

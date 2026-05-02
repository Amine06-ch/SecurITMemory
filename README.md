# SecurIT Memory

## Description

SecurIT Memory est un mini-jeu de cartes Memory développé en C# avec WinForms.  
Le projet a été réalisé dans le contexte du Salon de l'Innovation Tech pour une start-up fictive spécialisée en cybersécurité : SecurIT.

L'objectif du jeu est de retrouver toutes les paires de cartes représentant des éléments liés à la cybersécurité : mot de passe, pare-feu, virus, cadenas, réseau, chiffrement, etc.

## Fonctionnalités

- Menu principal avec les boutons Jouer, Options et Quitter
- Grille de cartes générée dynamiquement
- Mode 4x4
- Mode 6x6
- Mélange aléatoire des cartes
- Retournement des cartes au clic
- Comparaison automatique des paires
- Timer de délai pour cacher les mauvaises paires
- Chronomètre de partie
- Compteur d'essais
- Détection de victoire
- Interface graphique WinForms claire et simple

## Technologies utilisées

- C#
- Windows Forms
- .NET
- Visual Studio
- GitHub

## Structure du projet

```text
SecurITMemory/
│
├── Carte.cs
├── EtatCarte.cs
├── JeuMemory.cs
├── Form1.cs
├── Program.cs
└── README.md
Notions utilisées
Programmation orientée objet
Classes et propriétés
Enumération
Listes
Événements WinForms
PictureBox
Labels
Boutons
Timers
Génération dynamique d'interface
Classe Carte

La classe Carte représente une carte du jeu Memory.

Elle contient :

un identifiant de paire
un symbole cybersécurité
un état : Cachée, Révélée ou Trouvée

Cette classe permet de respecter une structure orientée objet propre.

Logique du jeu

Au lancement d'une partie, le jeu crée des paires de cartes, les mélange aléatoirement puis les affiche dans une grille.

Quand le joueur clique sur une carte, elle est révélée.
Lorsque deux cartes sont révélées, le programme compare leurs identifiants.

Si les identifiants sont identiques, la paire reste visible.
Sinon, un timer attend un court délai avant de cacher les deux cartes.

La partie se termine lorsque toutes les paires sont trouvées.

Lancer le projet
Ouvrir Visual Studio
Ouvrir la solution SecurITMemory
Lancer le projet avec le bouton Start
Jouer au Memory
Auteurs

Projet réalisé en binôme.

MVE Christ 
Chachou Amine 

Contexte oral

Nous avons développé ce projet pour répondre au besoin de SecurIT, une start-up spécialisée en cybersécurité.
L'équipe marketing voulait un mini-jeu interactif pour attirer les visiteurs sur son stand lors du Salon de l'Innovation Tech.

Notre choix s'est porté sur un jeu Memory car il est simple à comprendre, rapide à jouer et permet d'intégrer facilement des icônes liées à la cybersécurité.

Améliorations possibles
Ajouter un classement des scores
Ajouter une base de données SQL
Ajouter des effets sonores
Ajouter plusieurs thèmes graphiques
Ajouter un mode difficile



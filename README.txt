# Simulateur de Guichet Automatique (420-P11-ID Projet d'intégration 2024-06-12)

## Introduction

Ce projet est un simulateur de guichet automatique développé en [C# avec WPF .Net Framework] pour démontrer les compétences en programmation orientée objet et en gestion de base de données. Il vise à moderniser un ancien système en simulant les opérations d'un guichet automatique avec diverses fonctionnalités pour les clients et les administrateurs.

## Fonctionnalités

### Pour les Clients
- **Connexion Sécurisée :** Saisie du code client et du NIP avec verrouillage après trois essais infructueux.
- **Gestion des Comptes :** Création et gestion de comptes multiples incluant comptes chèques, épargne, hypothécaires, et marge de crédit.
- **Transactions :** 
  - Dépôts dans les comptes chèques, épargne, et hypothécaires.
  - Retraits depuis les comptes chèques et épargne (multiples de 10$ avec un maximum de 1000$ par transaction).
  - Transferts d'un compte chèque vers d'autres comptes.
  - Paiement de factures avec frais supplémentaires.
- **Consultation des Soldes :** Affichage des soldes de tous les comptes.
- **Historique des Transactions :** Enregistrement de chaque transaction individuelle.

### Pour les Administrateurs
- **Gestion des Clients et Comptes :** Création et gestion des clients et de leurs comptes.
- **Historique des Transactions :** Affichage de toutes les transactions par compte.
- **Contrôle du Guichet :** 
  - Ajouter de l'argent papier (jusqu'à 20 000$).
  - Fermer le guichet.
  - Payer des intérêts aux comptes épargne et augmenter les soldes des marges de crédit.
  - Prélever des montants des comptes hypothécaires avec ajustement de la marge de crédit si nécessaire.

## Installation

1. Clonez le dépôt :

   git clone https://github.com/votre-utilisateur/votre-repository.git

2. Configuration de la Base de Données :
   - Configurez votre base de données SQL Server en utilisant Entity Framework. Assurez-vous que la connexion à la base de données est correctement configurée dans les paramètres de l'application.

3. Compilation et Exécution :
   - Ouvrez le projet dans Visual Studio.
   - Assurez-vous que toutes les dépendances nécessaires sont installées (Entity Framework, bibliothèques .NET, etc.).
   - Compilez le projet en utilisant le menu Build dans Visual Studio.
   - Exécutez le projet à partir de Visual Studio pour démarrer l'application.

## Utilisation

1. Lancer l'Application :
   - Exécutez le fichier principal pour démarrer l'application.

2. Pour les Clients :
   - Connectez-vous avec votre code client et NIP pour accéder aux fonctionnalités.

3. Pour les Administrateurs :
   - Connectez-vous avec les identifiants d'administrateur pour accéder aux fonctionnalités de gestion.


# Tenisu API - Clean Architecture & Docker

## Description

Ce projet est une API ASP.NET Core 8 suivant les principes de l'**Architecture Propre (Clean Architecture)**, qui offre une structure modulaire, maintenable et testable. L'application utilise des concepts tels que les **Services**, les **Repositories**, les **Controllers** et inclut également la documentation **Swagger** pour une interface d'API conviviale. L'ensemble du projet est également **containerisé avec Docker**.

---

## Table des Matières

- [Architecture](#architecture)
- [Prérequis](#prérequis)
- [Installation](#installation)
- [Exécution de l'Application](#exécution-de-lapplication)
- [Tests Unitaires](#tests-unitaires)
- [Utilisation de Swagger](#utilisation-de-swagger)
- [Containerisation avec Docker](#containerisation-avec-docker)
  - [Créer une Image Docker](#créer-une-image-docker)
  - [Exécuter un Container Docker](#exécuter-un-container-docker)
- [Dépendances Principales](#dépendances-principales)

---

## Architecture

Ce projet suit les principes de **l'Architecture Propre** qui est divisée en différentes couches :

1. **Domain** : Contient les **Entités** et les **Modèles** de données.
2. **Application** : Contient les **Interfaces** (Services, Repositories), les **Logiques métiers**, et les **Services**.
3. **Infrastructure** : Gère la persistance des données (fichier, base de données) via des **Repositories** et des **Contexts**.
4. **API (Web)** : Couche de présentation qui contient les **Controllers** exposant les endpoints REST de l'API.

---

## Prérequis

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) ou version ultérieure
- [Docker](https://docs.docker.com/get-docker/) installé sur votre machine
- Un éditeur de code comme [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/)

---

## Installation

1. **Cloner le dépôt :**

   ```bash
   git clone https://github.com/slimbc/Tenisu.git
   cd tenisu

2. Restaurer les packages NuGet :
   dotnet restore

3.Construire la solution :
  dotnet build

## Exécution de l'Application
  dotnet run --project Tenisu

## Tests Unitaires
1. Accéder au projet de tests 
   cd Tenisu.Tests
2. Exécuter les tests 
   dotnet test

## Utilisation de Swagger
1. Accéder à Swagger UI 
   Une fois que l'application est en cours d'exécution, accédez à http://localhost:5000/swagger
2. Tester les endpoints 
   
## Containerisation avec Docker
1. Build
docker build -t tenisu .
2. Run
docker run -d -p 5000:80 --name tenisu-container tenisu

## Dépendances Principales
 - ASP.NET Core 8.0 : Framework principal pour le développement de l'API.
 - xUnit & Moq : Outils pour les tests unitaires.
 - Swashbuckle/Swagger : Génération automatique de la documentation et d'une interface utilisateur pour l'API.
 - Docker : Outil de containerisation pour exécuter l'application dans un environnement isolé.

 
  



# 📝 TodoList API - ASP.NET Core Web API

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-10.0-512BD4?logo=nuget)](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-CC2927?logo=microsoftsqlserver)](https://www.microsoft.com/sql-server)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](CONTRIBUTING.md)

Une API RESTful moderne pour la gestion de tâches (Todo List) construite avec ASP.NET Core 10.0, suivant les principes de **Clean Architecture** et les meilleures pratiques de développement.

## 🎯 Objectifs du Projet

Ce projet démontre :
- ✅ **Clean Architecture** avec séparation claire des responsabilités
- ✅ **Repository Pattern** pour l'abstraction de l'accès aux données
- ✅ **Service Layer** pour la logique métier
- ✅ **Entity Framework Core** avec Code-First Migrations
- ✅ **Dependency Injection** native d'ASP.NET Core
- ✅ **DTOs et Mappers** pour la transformation des données *(à venir)*
- ✅ **Authentification JWT** pour la sécurité *(à venir)*
- ✅ **Password Hashing** avec Argon2 *(à venir)*
- ✅ **API Documentation** avec Scalar

## 📋 Table des Matières

- [Architecture](#-architecture)
- [Technologies Utilisées](#-technologies-utilisées)
- [Structure du Projet](#-structure-du-projet)
- [Modèles de Données](#-modèles-de-données)
- [Endpoints API](#-endpoints-api)
- [Installation et Configuration](#-installation-et-configuration)
- [Concepts Clés](#-concepts-clés)
- [Fonctionnalités à Venir](#-fonctionnalités-à-venir)
- [Contribution](#-contribution)

## 🏗️ Architecture

Ce projet suit les principes de **Clean Architecture** (architecture en couches) pour garantir :
- **Maintenabilité** : Code organisé et facile à maintenir
- **Testabilité** : Séparation claire permettant les tests unitaires
- **Indépendance** : La logique métier ne dépend pas de l'infrastructure
- **Évolutivité** : Facilité d'ajout de nouvelles fonctionnalités

```
┌─────────────────────────────────────────────────────────┐
│                    API Layer (TodoList.API)             │
│  Controllers, DTOs, Middleware, Configuration           │
└────────────────────┬────────────────────────────────────┘
                     │ Depends on ↓
┌─────────────────────────────────────────────────────────┐
│              Application Layer (TodoList.Core)          │
│  Services, Interfaces, Business Logic                   │
└────────────────────┬────────────────────────────────────┘
                     │ Depends on ↓
┌─────────────────────────────────────────────────────────┐
│               Domain Layer (TodoList.Domain)            │
│  Entities, Enums, Domain Models (AUCUNE DEPENDANCES)    │
└─────────────────────────────────────────────────────────┘
                     ↑ Depends on
┌─────────────────────────────────────────────────────────┐
│         Infrastructure Layer (TodoList.Infrastructure)  │
│  Database Context, Repositories, Migrations             │
└─────────────────────────────────────────────────────────┘
```

## 🛠️ Technologies Utilisées

| Technologie | Version | Usage |
|------------|---------|-------|
| .NET | 10.0 | Framework principal |
| ASP.NET Core | 10.0 | API Web |
| Entity Framework Core | 10.0.2 | ORM et gestion de base de données |
| SQL Server LocalDB | - | Base de données de développement |
| Scalar | 2.12.13 | Documentation API interactive |
| C# | 13.0 | Langage de programmation |

### Packages NuGet Principaux

```xml
<!-- API -->
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.2" />
<PackageReference Include="Scalar.AspNetCore" Version="2.12.13" />

<!-- Entity Framework Core -->
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="10.0.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.2" />
```

## 📁 Structure du Projet

```
TodoList/
│
├── 📂 TodoList.API/                    # Couche Présentation
│   ├── Controllers/                    # Contrôleurs API
│   │   ├── TodosController.cs         # CRUD pour les tâches
│   │   ├── UsersController.cs         # CRUD pour les utilisateurs
│   │   └── AuthController.cs          # Authentification (à venir)
│   │
│   ├── DTOs/                          # Data Transfer Objects (à venir)
│   │   ├── Requests/                  # Requêtes entrantes
│   │   │   ├── TodoCreateDto.cs
│   │   │   ├── TodoUpdateDto.cs
│   │   │   ├── UserCreateDto.cs
│   │   │   └── UserUpdateDto.cs
│   │   └── Responses/                 # Réponses sortantes
│   │       ├── TodoResponseDto.cs
│   │       └── UserResponseDto.cs
│   │
│   ├── Mappers/                       # Conversion Entity ↔ DTO (à venir)
│   │   ├── TodoMapper.cs
│   │   └── UserMapper.cs
│   │
│   ├── Properties/
│   │   └── launchSettings.json        # Configuration de démarrage
│   │
│   ├── appsettings.json               # Configuration globale
│   ├── appsettings.Development.json   # Config développement
│   ├── appsettings.Production.json    # Config production
│   └── Program.cs                     # Point d'entrée + DI
│
├── 📂 TodoList.Core/                   # Couche Application
│   ├── Interfaces/
│   │   ├── Repositories/              # Contrats des repositories
│   │   │   ├── IBaseRepository.cs     # Interface générique CRUD
│   │   │   ├── ITodoRepository.cs
│   │   │   └── IUserRepository.cs
│   │   │
│   │   └── Services/                  # Contrats des services
│   │       ├── IBaseService.cs        # Service générique
│   │       ├── ITodoService.cs
│   │       ├── IUserService.cs
│   │       ├── IPasswordHasherService.cs  # (à venir)
│   │       └── IJwtService.cs             # (à venir)
│   │
│   └── Services/
│       ├── Data/                      # Services métier
│       │   ├── TodoService.cs         # Logique métier Todos
│       │   └── UserService.cs         # Logique métier Users
│       │
│       └── Tools/                     # Services utilitaires (à venir)
│           ├── PasswordHasherService.cs
│           └── JwtService.cs
│
├── 📂 TodoList.Domain/                 # Couche Domaine
│   ├── Entities/                      # Entités du domaine
│   │   ├── Todo.cs                    # Entité Tâche
│   │   └── User.cs                    # Entité Utilisateur
│   │
│   └── Enums/                         # Énumérations
│       ├── TodoStatus.cs              # NotStarted, InProgress, Completed
│       └── UserRole.cs                # User, Admin
│
└── 📂 TodoList.Infrastructure/         # Couche Infrastructure
    ├── Database/
    │   ├── Configurations/            # Configuration EF Core
    │   │   ├── TodoConfiguration.cs   # Fluent API pour Todo
    │   │   └── UserConfiguration.cs   # Fluent API pour User
    │   │
    │   ├── Migrations/                # Migrations EF Core
    │   │   ├── 20260122133201_InitialMigration.cs
    │   │   └── TodoListContextModelSnapshot.cs
    │   │
    │   └── TodoListContext.cs         # DbContext principal
    │
    └── Repositories/                  # Implémentations des repositories
        ├── BaseRepository.cs          # Repository générique
        ├── TodoRepository.cs
        └── UserRepository.cs
```

## 🗄️ Modèles de Données

### Entité `User`

```csharp
public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }            // Format validé en DB
    public string Password { get; set; }         // Sera hashé (à venir)
    public UserRole Role { get; set; }           // User ou Admin
    public string? Lastname { get; set; }
    public string? Firstname { get; set; }
    public ICollection<Todo> Todos { get; set; } // Relation 1-N
}
```

### Entité `Todo`

```csharp
public class Todo
{
    public Guid Id { get; set; }
    public string Title { get; set; }            // Max 100 caractères
    public string? Description { get; set; }     // Max 1000 caractères
    public TodoStatus Status { get; set; }       // NotStarted, InProgress, Completed
    public Guid UserId { get; set; }             // Clé étrangère
    public User User { get; set; }               // Navigation property
    public DateTime CreatedAt { get; set; }      // Défaut: GETDATE()
    public bool IsDeleted { get; set; }          // Soft delete
}
```

### Relations

```
User (1) ────────< Todos (N)
  │                    │
  └─ UserId (FK) ──────┘
  
  Cascade Delete activé
```

## 🌐 Endpoints API

### **Todos** (`/api/todos`)

| Méthode | Endpoint | Description | Status |
|---------|----------|-------------|--------|
| `GET` | `/api/todos` | Récupère toutes les tâches | ✅ Implémenté |
| `GET` | `/api/todos/{id}` | Récupère une tâche par ID | ✅ Implémenté |
| `POST` | `/api/todos` | Crée une nouvelle tâche | 🚧 À implémenter |
| `PUT` | `/api/todos/{id}` | Met à jour une tâche | 🚧 À implémenter |
| `DELETE` | `/api/todos/{id}` | Supprime une tâche | ✅ Implémenté |

### **Users** (`/api/users`)

| Méthode | Endpoint | Description | Status |
|---------|----------|-------------|--------|
| `GET` | `/api/users` | Récupère tous les utilisateurs | ✅ Implémenté |
| `GET` | `/api/users/{id}` | Récupère un utilisateur par ID | ✅ Implémenté |
| `POST` | `/api/users` | Crée un nouvel utilisateur | 🚧 À implémenter |
| `PUT` | `/api/users/{id}` | Met à jour un utilisateur | 🚧 À implémenter |
| `DELETE` | `/api/users/{id}` | Supprime un utilisateur | ✅ Implémenté |

### **Authentication** (`/api/auth`) *(À venir)*

| Méthode | Endpoint | Description | Status |
|---------|----------|-------------|--------|
| `POST` | `/api/auth/register` | Inscription | 📅 Planifié |
| `POST` | `/api/auth/login` | Connexion + JWT | 📅 Planifié |
| `POST` | `/api/auth/refresh` | Rafraîchir le token | 📅 Planifié |

## 🚀 Installation et Configuration

### Prérequis

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [SQL Server LocalDB](https://learn.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb)
- Un IDE : [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

### Installation

1. **Cloner le repository**
   ```bash
   git clone https://github.com/QuentinGeerts/TF_SAP250026_DevenirDev__WebAPI_Demo03.git
   cd TF_SAP250026_DevenirDev__WebAPI_Demo03
   ```

2. **Restaurer les packages NuGet**
   ```bash
   dotnet restore
   ```

3. **Configurer la chaîne de connexion**
   
   Modifier `appsettings.Development.json` si nécessaire :
   ```json
   {
     "ConnectionStrings": {
       "Default": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TodoListDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"
     }
   }
   ```

4. **Appliquer les migrations**
   ```bash
   cd TodoList.API
   dotnet ef database update --project ../TodoList.Infrastructure
   ```

5. **Lancer l'application**
   ```bash
   dotnet run --project TodoList.API
   ```

6. **Accéder à la documentation API**
   
   Ouvrir votre navigateur sur : `https://localhost:7028/scalar`

## 💡 Concepts Clés

### 1. **Clean Architecture**

La Clean Architecture organise le code en couches concentriques :

```
┌──────────────────────────────────────┐
│         API (Présentation)           │  ← Interface utilisateur
├──────────────────────────────────────┤
│        Core (Application)            │  ← Logique métier
├──────────────────────────────────────┤
│         Domain (Domaine)             │  ← Modèles et règles métier (aucune dépendance)
└──────────────────────────────────────┘
         ↑ dépend de
┌──────────────────────────────────────┐
│    Infrastructure (Données)          │  ← Accès aux données
└──────────────────────────────────────┘
```

**Règle d'or** : Les dépendances pointent toujours vers l'intérieur (vers le Domain).

### 2. **Repository Pattern**

Le Repository Pattern abstrait l'accès aux données :

```csharp
// Interface (Core)
public interface IUserRepository : IBaseRepository<User, Guid>
{
    Task<User?> GetUserByEmail(string email);
}

// Implémentation (Infrastructure)
public class UserRepository : BaseRepository<User, Guid>, IUserRepository
{
    public async Task<User?> GetUserByEmail(string email)
    {
        return await _entities.FirstOrDefaultAsync(e => e.Email == email);
    }
}
```

**Avantages** :
- ✅ Facilite les tests (mocking)
- ✅ Change le système de persistance sans toucher à la logique métier
- ✅ Centralise les requêtes DB

### 3. **Service Layer**

La couche Service contient la logique métier :

```csharp
public class UserService(IUserRepository _userRepository) : IUserService
{    
    public async Task DeleteAsync(Guid id)
    {
        // Validation métier
        var existingUser = await _userRepository.ExistsAsync(id);
        if (!existingUser) 
            throw new KeyNotFoundException("Id not found");
        
        // Opération
        await _userRepository.DeleteAsync(id);
    }
}
```

**Responsabilités** :
- ✅ Validation des règles métier
- ✅ Coordination entre plusieurs repositories
- ✅ Gestion des transactions
- ✅ Transformation des données

### 4. **Dependency Injection**

L'injection de dépendance est configurée dans `Program.cs` :

```csharp
// Enregistrement des services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();
```

**Pattern utilisé** : Constructor Injection
```csharp
public class TodosController(ITodoService _todoService) : ControllerBase
{
    // _todoService est automatiquement injecté
}
```

#### 📚 Les 3 Lifetimes d'Injection de Dépendance

ASP.NET Core propose 3 méthodes pour enregistrer les services, chacune avec un cycle de vie différent :

##### 1️⃣ **AddTransient** - Instance par injection

```csharp
builder.Services.AddTransient();
```

**Comportement** :
- ✅ Une **nouvelle instance** est créée **à chaque injection**
- ✅ Même au sein d'une même requête HTTP

**Cycle de vie** :
```
Requête HTTP
├── Controller créé
│   └── new EmailService() ← Instance A
├── Service appelé
│   └── new EmailService() ← Instance B
└── Repository utilisé
    └── new EmailService() ← Instance C
```

**Quand l'utiliser** :
- ✅ Services **légers et sans état** (stateless)
- ✅ Services qui ne doivent **pas être partagés**
- ✅ Opérations **courtes et indépendantes**

**Exemples** :
- Service d'envoi d'email
- Générateur de GUID
- Logger simple
- Service de validation

---

##### 2️⃣ **AddScoped** - Instance par requête HTTP ⭐ **(Recommandé pour les repositories et services)**

```csharp
builder.Services.AddScoped();
```

**Comportement** :
- ✅ Une **instance unique** par **requête HTTP**
- ✅ La même instance est réutilisée dans toute la requête
- ✅ Détruite à la fin de la requête

**Cycle de vie** :
```
Requête HTTP #1
├── Controller créé
│   └── UserService (Instance A)
│       └── UserRepository (Instance B)
│           └── DbContext (Instance C)
├── Autre injection dans la même requête
│   └── UserService (Instance A - réutilisée) ✅
│       └── UserRepository (Instance B - réutilisée) ✅
└── Fin de requête → Dispose(A, B, C)

Requête HTTP #2
└── Nouvelles instances créées
```

**Quand l'utiliser** :
- ✅ **Repositories** (accès aux données)
- ✅ **Services métier** (business logic)
- ✅ **DbContext** d'Entity Framework Core
- ✅ Services qui doivent **partager l'état durant une requête**

**Pourquoi c'est le choix par défaut** :
- ✅ **Performance** : Évite de créer trop d'instances
- ✅ **Cohérence** : Même DbContext dans toute la requête
- ✅ **Gestion mémoire** : Nettoyage automatique après chaque requête

---

##### 3️⃣ **AddSingleton** - Instance unique pour toute l'application

```csharp
builder.Services.AddSingleton(configuration);
```

**Comportement** :
- ✅ **Une seule instance** pour toute la durée de vie de l'application
- ✅ Partagée entre **toutes les requêtes** et **tous les threads**
- ✅ Créée au **premier usage** (ou au démarrage)
- ✅ Détruite uniquement à l'**arrêt de l'application**

**Cycle de vie** :
```
Application démarre
└── Singleton créé (Instance A)

Requête HTTP #1
└── Utilise Instance A

Requête HTTP #2
└── Utilise Instance A (même instance) ✅

Requête HTTP #1000
└── Utilise Instance A (toujours la même) ✅

Application s'arrête
└── Dispose(Instance A)
```

**Quand l'utiliser** :
- ✅ **Configuration** (IConfiguration, IOptions)
- ✅ **Cache en mémoire** (IMemoryCache)
- ✅ **Services coûteux** à initialiser
- ✅ **Services sans état** (stateless) et **thread-safe**

**Exemples** :
- Configuration de l'application
- Cache distribué
- Logger factory
- Service de métriques

---

#### 📊 Tableau Comparatif

| Lifetime | Durée de vie | Instance par requête | Thread-safe requis | Usage typique |
|----------|--------------|----------------------|--------------------|---------------|
| **Transient** | Par injection | ❌ Non (nouvelle à chaque fois) | ❌ Non | Services légers, stateless |
| **Scoped** | Par requête HTTP | ✅ Oui (partagée) | ❌ Non | Repositories, Services, DbContext |
| **Singleton** | Toute l'application | ✅ Oui (unique globale) | ✅ **OUI** | Configuration, Cache, Loggers |

#### 🎯 Règles de Décision Rapide

```
Ai-je besoin de partager l'état entre plusieurs injections ?
├─ Non → AddTransient
│   └─ Le service est-il très léger ? → AddTransient ✅
│
└─ Oui
    ├─ Uniquement dans une requête HTTP ? → AddScoped ✅
    │   └─ Repositories, Services, DbContext
    │
    └─ Dans toute l'application ?
        ├─ Est-ce thread-safe ? → AddSingleton ✅
        │   └─ Configuration, Cache
        │
        └─ Non thread-safe → Revoir l'architecture ⚠️
```

#### 💡 Exemple Concret dans Notre Projet

```csharp
// Program.cs
var builder = WebApplication.CreateBuilder(args);

// ✅ Singleton : Configuration (immutable, thread-safe)
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// ✅ Scoped : DbContext (lié à la requête HTTP)
builder.Services.AddDbContext<TodoListContext>(options =>
    options.UseSqlServer(connectionString));

// ✅ Scoped : Repositories (utilisent DbContext scoped)
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

// ✅ Scoped : Services métier (utilisent repositories scoped)
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITodoService, TodoService>();

// ✅ Transient : Services d'envoi d'email (stateless, léger)
builder.Services.AddTransient<IEmailService, EmailService>();

// ✅ Singleton : Cache (partagé, thread-safe)
builder.Services.AddSingleton<ICacheService, MemoryCacheService>();
```

#### ⚡ Performance et Mémoire

```csharp
// Scénario : 1000 requêtes HTTP

// ❌ AddTransient sur UserService
// = 1000 requêtes × 5 injections par requête = 5000 instances créées
builder.Services.AddTransient<IUserService, UserService>();

// ✅ AddScoped sur UserService
// = 1000 requêtes × 1 instance par requête = 1000 instances créées
builder.Services.AddScoped<IUserService, UserService>();

// ✅ AddSingleton sur CacheService
// = 1 seule instance pour les 1000 requêtes
builder.Services.AddSingleton<ICacheService, CacheService>();
```

### 5. **Entity Framework Core Configurations**

Les configurations utilisent **Fluent API** pour plus de contrôle :

```csharp
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Contrainte d'email
        builder.ToTable(t => 
            t.HasCheckConstraint("CK_User_Email_Format", "Email LIKE '%_@%_.%_'"));
        
        // Relation 1-N
        builder.HasMany(u => u.Todos)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
```

### 6. **Primary Constructor (C# 12)**

Syntaxe simplifiée pour l'injection de dépendance :

```csharp
// Ancienne syntaxe
public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    
    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }
}

// Nouvelle syntaxe (C# 12)
public class TodoService(ITodoRepository _todoRepository) : ITodoService
{
    // _todoRepository est directement disponible
}

// Avec héritage
public class UserRepository(TodoListContext context) : BaseRepository<User, Guid>(context), IUserRepository
{
    // ...
}
```

## 🔮 Fonctionnalités à Venir

### Phase 1 : DTOs et Mappers
- [ ] Création des DTOs (Requests/Responses)
- [ ] Implémentation des Mappers
- [ ] Mise à jour des contrôleurs pour utiliser les DTOs
- [ ] Validation des DTOs avec FluentValidation ou DataAnnotations

### Phase 2 : Sécurité
- [ ] **Password Hashing**
  - Interface `IPasswordHasherService`
  - Service `PasswordHasherService`
  - Implémentation avec Argon2 [Package NuGet](https://www.nuget.org/packages/Konscious.Security.Cryptography.Argon2)
  - Intégration dans UserService (Create/Update)
  
- [ ] **JWT Authentication**
  - Interface `IJwtService`
  - Génération de tokens JWT
  - Middleware d'authentification
  - AuthController (Register/Login/Refresh)
  - Protection des endpoints avec `[Authorize]`

### Phase 3 : Améliorations: [Voici des pistes d'amélioration si vous souhaitez aller plus loin de votre côté]
- [ ] Pagination pour les listes
- [ ] Filtres et recherche
- [ ] Logging avec Serilog
- [ ] Gestion globale des erreurs (Middleware)
- [ ] Rate Limiting
- [ ] Versioning de l'API
- [ ] Tests unitaires et d'intégration
- [ ] Dockerisation
- [ ] CI/CD avec GitHub Actions

## 📊 Schéma de la Base de Données

```sql
┌──────────────────────────────┐
│           Users              │
├──────────────────────────────┤
│ Id (PK)         GUID         │
│ Email           NVARCHAR(255)│
│ Password        NVARCHAR(100)│
│ Role            INT          │
│ Lastname        NVARCHAR(100)│
│ Firstname       NVARCHAR(100)│
└─────────────────┬────────────┘
                  │ 1
                  │
                  │ N
┌─────────────────┴─────────────┐
│           Todos               │
├───────────────────────────────┤
│ Id (PK)         GUID          │
│ Title           NVARCHAR(100) │
│ Description     NVARCHAR(1000)│
│ Status          INT           │
│ UserId (FK)     GUID          │
│ CreatedAt       DATETIME2     │
│ IsDeleted       BIT           │
└───────────────────────────────┘
```

## 📝 Licence

Ce projet est sous licence MIT - voir le fichier [LICENSE](LICENSE) pour plus de détails.

---

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [Clean Architecture par Uncle Bob](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Repository Pattern](https://docs.microsoft.com/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)

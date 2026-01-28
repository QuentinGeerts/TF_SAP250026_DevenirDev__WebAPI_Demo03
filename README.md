# 📝 TodoList API - ASP.NET Core Web API

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-10.0-512BD4?logo=nuget)](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-CC2927?logo=microsoftsqlserver)](https://www.microsoft.com/sql-server)
[![JWT](https://img.shields.io/badge/JWT-Auth-000000?logo=jsonwebtokens)](https://jwt.io/)
[![Argon2](https://img.shields.io/badge/Argon2id-Hashing-brightgreen)](https://www.argon2.com/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

Une API RESTful moderne et **sécurisée** pour la gestion de tâches (Todo List) construite avec ASP.NET Core 10.0, suivant les principes de **Clean Architecture** et les meilleures pratiques de développement.

## 🎯 Objectifs du Projet

Ce projet démontre :
- ✅ **Clean Architecture** avec séparation claire des responsabilités
- ✅ **Repository Pattern** pour l'abstraction de l'accès aux données
- ✅ **Service Layer** pour la logique métier
- ✅ **Entity Framework Core** avec Code-First Migrations
- ✅ **Dependency Injection** native d'ASP.NET Core
- ✅ **DTOs et Mappers** pour la transformation des données
- ✅ **Authentification JWT** (Bearer Token)
- ✅ **Password Hashing** avec Argon2id (OWASP recommandé)
- ✅ **Autorisation basée sur les rôles** (User/Admin)
- ✅ **Configuration CORS** sécurisée
- ✅ **API Documentation** avec Scalar + Bearer Authentication

## 🏗️ Architecture

Ce projet suit les principes de **Clean Architecture** (architecture en couches) pour garantir :
- **Maintenabilité** : Code organisé et facile à maintenir
- **Testabilité** : Séparation claire permettant les tests unitaires
- **Indépendance** : La logique métier ne dépend pas de l'infrastructure
- **Évolutivité** : Facilité d'ajout de nouvelles fonctionnalités

```
┌─────────────────────────────────────────────────────────┐
│                    API Layer (TodoList.API)             │
│            Controllers, Middleware, Config              │
└────────────────────┬────────────────────────────────────┘
                     │ Depends on ↓
┌─────────────────────────────────────────────────────────┐
│              Application Layer (TodoList.Core)          │
│  Services, Interfaces, Business Logic, DTOs, Mappers    │
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
| JWT Bearer Authentication | 10.0.2 | Authentification sécurisée |
| Argon2id | 1.3.1 | Hashing de mots de passe (OWASP) |
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

<!-- Sécurité -->
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="10.0.2" />
<PackageReference Include="Konscious.Security.Cryptography.Argon2" Version="1.3.1" />
```

## 📁 Structure du Projet

```
TodoList/
│
├── 📂 TodoList.API/                    # Couche Présentation
│   ├── Controllers/                    # Contrôleurs API
│   │   ├── AuthController.cs          # Authentification (Register/Login)
│   │   ├── TodosController.cs         # CRUD pour les tâches + [Authorize]
│   │   └── UsersController.cs         # CRUD pour les utilisateurs + [Authorize(Roles="Admin")]
│   │
│   ├── Extensions/                     # Extensions de configuration
│   │   ├── CorsPolicyExtensions.cs    # Configuration CORS
│   │   └── JwtAuthenticationExtensions.cs # Configuration JWT
│   │
│   ├── Scalar/                         # Configuration Scalar
│   │   └── BearerSecuritySchemeTransformer.cs # Intégration Bearer Token dans Scalar
│   │
│   ├── Properties/
│   │   └── launchSettings.json        # Configuration de démarrage
│   │
│   ├── appsettings.json               # Configuration globale
│   ├── appsettings.Development.json   # Config développement + JWT Settings
│   ├── appsettings.Production.json    # Config production
│   └── Program.cs                     # Point d'entrée + DI + Middleware
│
├── 📂 TodoList.Core/                   # Couche Application
│   ├── DTOs/                          # Data Transfer Objects
│   │   ├── Requests/
│   │   │   ├── AddTodoRequestDto.cs
│   │   │   ├── LoginRequestDto.cs
│   │   │   ├── RegisterRequestDto.cs
│   │   │   └── UpdateUserRequestDto.cs
│   │   └── Responses/
│   │       ├── LoginResponseDto.cs
│   │       └── UserResponseDto.cs
│   │
│   ├── Mappers/                       # Conversion Entity ↔ DTO
│   │   ├── TodoMapperExtensions.cs
│   │   └── UserMapperExtensions.cs
│   │
│   ├── Interfaces/
│   │   ├── Repositories/              # Contrats des repositories
│   │   │   ├── IBaseRepository.cs
│   │   │   ├── ITodoRepository.cs
│   │   │   └── IUserRepository.cs
│   │   │
│   │   └── Services/                  # Contrats des services
│   │       ├── IBaseService.cs
│   │       ├── ITodoService.cs
│   │       ├── IUserService.cs
│   │       ├── Auth/                  # Services d'authentification
│   │       │   ├── IAuthService.cs
│   │       │   └── IJwtService.cs
│   │       └── Tools/                 # Services utilitaires
│   │           └── IPasswordHasherService.cs
│   │
│   ├── Services/
│   │   ├── Data/                      # Services métier
│   │   │   ├── TodoService.cs
│   │   │   └── UserService.cs
│   │   ├── Auth/                      # Services d'authentification
│   │   │   ├── AuthService.cs         # Register + Login
│   │   │   └── JwtService.cs          # Génération JWT
│   │   └── Tools/                     # Services utilitaires
│   │       └── PasswordHasherService.cs # Argon2id
│   │
│   └── ServiceExtensions.cs           # Configuration DI pour Core
│
├── 📂 TodoList.Domain/                 # Couche Domaine
│   ├── Entities/
│   │   ├── Todo.cs
│   │   └── User.cs
│   │
│   └── Enums/
│       ├── TodoStatus.cs              # NotStarted, InProgress, Completed
│       └── UserRole.cs                # User, Admin
│
└── 📂 TodoList.Infrastructure/         # Couche Infrastructure
    ├── Database/
    │   ├── Context/
    │   │   └── TodoListContext.cs
    │   │
    │   ├── Configurations/            # Configuration EF Core
    │   │   ├── TodoConfiguration.cs
    │   │   └── UserConfiguration.cs
    │   │
    │   └── Migrations/                # Migrations EF Core
    │       ├── 20260123085454_InitialMigration.cs
    │       └── TodoListContextModelSnapshot.cs
    │
    ├── Repositories/                  # Implémentations des repositories
    │   ├── BaseRepository.cs
    │   ├── TodoRepository.cs
    │   └── UserRepository.cs
    │
    └── ServiceExtensions.cs           # Configuration DI pour Infrastructure
```

## 🗄️ Modèles de Données

### Entité `User`

```csharp
public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }            // Format validé en DB
    public string Password { get; set; }         // Hashé avec Argon2id
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

### **🔐 Authentication** (`/api/auth`) - Public

| Méthode | Endpoint | Description | Autorisation | Status |
|---------|----------|-------------|--------------|--------|
| `POST` | `/api/auth/register` | Inscription + génération utilisateur | Public | ✅ Implémenté |
| `POST` | `/api/auth/login` | Connexion + génération JWT Token | Public | ✅ Implémenté |

**Exemple de réponse `/login`** :
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiration": "2026-01-28T14:30:00Z"
}
```

### **📝 Todos** (`/api/todos`) - Requiert JWT Token

| Méthode | Endpoint | Description | Autorisation | Status |
|---------|----------|-------------|--------------|--------|
| `GET` | `/api/todos` | Récupère toutes les tâches | `[Authorize]` | ✅ Implémenté |
| `GET` | `/api/todos/{id}` | Récupère une tâche par ID | `[Authorize]` | ✅ Implémenté |
| `POST` | `/api/todos` | Crée une nouvelle tâche | `[Authorize]` | ✅ Implémenté |
| `PUT` | `/api/todos/{id}` | Met à jour une tâche | `[Authorize]` | 🚧 À implémenter |
| `DELETE` | `/api/todos/{id}` | Supprime une tâche | `[Authorize]` | ✅ Implémenté |

### **👥 Users** (`/api/users`) - Admin uniquement

| Méthode | Endpoint | Description | Autorisation | Status |
|---------|----------|-------------|--------------|--------|
| `GET` | `/api/users` | Récupère tous les utilisateurs | `[Authorize(Roles="Admin")]` | ✅ Implémenté |
| `GET` | `/api/users/{id}` | Récupère un utilisateur par ID | `[Authorize(Roles="Admin")]` | ✅ Implémenté |
| `PUT` | `/api/users/{id}` | Met à jour un utilisateur | `[Authorize(Roles="Admin")]` | ✅ Implémenté |
| `DELETE` | `/api/users/{id}` | Supprime un utilisateur | `[Authorize(Roles="Admin")]` | ✅ Implémenté |

## 🔐 Sécurité

### 🔑 Authentification JWT (JSON Web Token)

L'API implémente une authentification sécurisée basée sur **JWT Bearer Tokens** conformément aux standards RFC 7519.

#### 📋 Qu'est-ce qu'un JWT ?

Un JWT (JSON Web Token) est un standard ouvert qui définit une manière compacte et autonome de transmettre des informations entre parties sous forme d'objet JSON. Ces informations peuvent être vérifiées et approuvées car elles sont signées numériquement.

**Structure d'un JWT** :
```
[Header].[Payload].[Signature]
```

```json
// Header - Algorithme et type de token
{
  "alg": "HS256",
  "typ": "JWT"
}

// Payload - Claims (données utilisateur)
{
  "jti": "8f36c12f-...",           // JWT ID unique
  "sub": "3fa85f64-...",           // Subject (User ID)
  "email": "user@example.com",     // Email utilisateur
  "role": "User",                  // Rôle
  "exp": 1738069800                // Expiration timestamp
}

// Signature - Garantit l'intégrité
HMACSHA256(
  base64UrlEncode(header) + "." + base64UrlEncode(payload),
  secret
)
```

#### ⚙️ Configuration JWT (appsettings.Development.json)

```json
{
  "JwtSettings": {
    "SecretKey": "VotreClefSecreteTrèsLongueEtComplexeDeMinimum32Caractères!",
    "Issuer": "TodoListAPI",
    "Audience": "TodoListClient",
    "ExpirationMinutes": 30
  }
}
```

| Paramètre | Description | Recommandation |
|-----------|-------------|----------------|
| `SecretKey` | Clé de signature du token (HMAC-SHA256) | Minimum 32 caractères, stockée en **Azure Key Vault** en production |
| `Issuer` | Émetteur du token (qui a créé le token) | Nom de votre API |
| `Audience` | Destinataire du token (qui peut l'utiliser) | Nom de votre client (Angular, React, etc.) |
| `ExpirationMinutes` | Durée de validité du token | 30 minutes (équilibre sécurité/UX) |

⚠️ **CRITIQUE - Sécurité en Production** :
```csharp
// ❌ NE JAMAIS faire ça en production !
"SecretKey": "ma-cle-secrete"

// ✅ Utiliser Azure Key Vault ou Variables d'environnement
var secretKey = builder.Configuration["JwtSettings:SecretKey"] 
    ?? Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
```

#### 🔧 Paramètres de Validation

```csharp
options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,           // ✅ Vérifie que le token vient de notre API
    ValidateAudience = true,         // ✅ Vérifie que le token est destiné à notre client
    ValidateLifetime = true,         // ✅ Vérifie que le token n'est pas expiré
    ValidateIssuerSigningKey = true, // ✅ Vérifie la signature du token
    
    ValidIssuer = jwtSettings["Issuer"],
    ValidAudience = jwtSettings["Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!)
    ),
    
    ClockSkew = TimeSpan.Zero        // ⏱️ Pas de tolérance sur l'expiration
};
```

**Explication de `ClockSkew`** :
- Par défaut : 5 minutes de tolérance (le token reste valide 5 min après expiration)
- `TimeSpan.Zero` : Expiration stricte (meilleure sécurité)

#### 📦 Claims Inclus dans le Token

Les **claims** sont des paires clé-valeur qui contiennent les informations sur l'utilisateur :

```csharp
var claims = new[]
{
    // Claims standards JWT (RFC 7519)
    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JWT ID (identifiant unique du token)
    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),        // Subject (ID de l'utilisateur)
    new Claim(JwtRegisteredClaimNames.Email, user.Email),              // Email de l'utilisateur
    
    // Claims personnalisés
    new Claim("role", user.Role.ToString())                            // Rôle (User/Admin)
};
```

**Accès aux Claims dans les Controllers** :
```csharp
// Récupérer l'ID de l'utilisateur connecté
var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

// Récupérer l'email
var email = User.FindFirst(ClaimTypes.Email)?.Value;

// Vérifier le rôle
var isAdmin = User.IsInRole("Admin");
```

#### 🔄 Flux d'Authentification

```mermaid
sequenceDiagram
    participant Client
    participant API
    participant DB
    
    Client->>API: POST /api/auth/register (email, password)
    API->>API: Hash password (Argon2id)
    API->>DB: Sauvegarder utilisateur
    DB-->>API: Utilisateur créé
    API-->>Client: 201 Created (UserDto)
    
    Client->>API: POST /api/auth/login (email, password)
    API->>DB: Récupérer utilisateur par email
    DB-->>API: User
    API->>API: Vérifier password hash
    API->>API: Générer JWT Token
    API-->>Client: 200 OK (token + expiration)
    
    Client->>API: GET /api/todos (Authorization: Bearer <token>)
    API->>API: Valider JWT Token
    API->>API: Extraire User ID du token
    API->>DB: Récupérer todos de l'utilisateur
    DB-->>API: Liste des todos
    API-->>Client: 200 OK (todos)
```

#### 🛡️ Protection des Endpoints

```csharp
// 1. Accessible par tous (pas de [Authorize])
[HttpPost("register")]
public async Task<IActionResult> Register(RegisterRequestDto request) { }

// 2. Accessible uniquement aux utilisateurs authentifiés
[Authorize]
[HttpGet]
public async Task<ActionResult<IEnumerable<Todo>>> GetTodos() { }

// 3. Accessible uniquement aux administrateurs
[Authorize(Roles = "Admin")]
[HttpGet("users")]
public async Task<ActionResult<IEnumerable<User>>> GetUsers() { }

// 4. Accessible aux utilisateurs ET aux administrateurs
[Authorize(Roles = "User,Admin")]
[HttpGet("profile")]
public async Task<ActionResult<UserDto>> GetProfile() { }
```

#### 📊 Comparaison JWT vs Sessions

| Critère | JWT | Sessions |
|---------|-----|----------|
| **Stockage serveur** | ❌ Aucun (stateless) | ✅ Oui (en mémoire/DB) |
| **Scalabilité** | ✅ Excellente (pas d'état) | ⚠️ Limitée (état partagé) |
| **Révocation** | ⚠️ Difficile | ✅ Facile |
| **Taille** | ⚠️ ~200-1000 bytes | ✅ ~20 bytes (session ID) |
| **Sécurité** | ✅ Signature cryptographique | ✅ Cookie HttpOnly + Secure |
| **Mobile/SPA** | ✅ Parfait | ⚠️ Complexe |

---

### 🔒 Password Hashing avec Argon2id

L'API utilise **Argon2id**, l'algorithme de hashing recommandé par l'**OWASP** (Open Web Application Security Project) pour sécuriser les mots de passe.

#### 📚 Pourquoi Argon2id ?

**Argon2** est le vainqueur du **Password Hashing Competition (PHC)** de 2015. Il existe en 3 variantes :

| Variante | Usage | Protection |
|----------|-------|------------|
| **Argon2d** | Cryptomonnaies | ✅ GPU-resistant (haute mémoire) |
| **Argon2i** | Serveurs web | ✅ Side-channel resistant |
| **Argon2id** (⭐ recommandé) | Usage général | ✅ Hybride (GPU + side-channel resistant) |

**Argon2id** combine les avantages des deux autres :
- ✅ **Résistant aux attaques GPU** (coût mémoire élevé)
- ✅ **Résistant aux attaques par side-channel** (timing attacks)
- ✅ **Résistant aux rainbow tables** (sel unique par mot de passe)
- ✅ **Protection contre le brute-force** (coût CPU configurable)

#### ⚙️ Paramètres Argon2id (Recommandations OWASP 2024)

```csharp
public class PasswordHasherService : IPasswordHasherService
{
    // Paramètres recommandés par l'OWASP pour un équilibre sécurité/performance
    private const int SaltSize = 16;              // 16 bytes (128 bits) de sel unique
    private const int HashSize = 32;              // 32 bytes (256 bits) de hash final
    private const int Iterations = 4;             // 4 passes sur la mémoire
    private const int MemorySize = 65536;         // 64 MB de RAM (65536 KB)
    private const int DegreeOfParallelism = 2;    // 2 threads parallèles
}
```

| Paramètre | Valeur | Impact | Recommandation OWASP |
|-----------|--------|--------|---------------------|
| `SaltSize` | 16 bytes | Unicité du hash | ✅ Minimum 16 bytes |
| `HashSize` | 32 bytes | Sécurité cryptographique | ✅ 32 bytes (256 bits) |
| `Iterations` | 4 | Nombre de passes mémoire | ✅ Minimum 3 |
| `MemorySize` | 65536 KB | Résistance GPU | ✅ Minimum 64 MB |
| `DegreeOfParallelism` | 2 | Utilisation CPU | ✅ 1-4 selon ressources |

**Ajustement selon les ressources serveur** :
```csharp
// Serveur puissant (recommandé pour production)
MemorySize = 131072;      // 128 MB
Iterations = 5;

// Serveur standard (équilibre)
MemorySize = 65536;       // 64 MB
Iterations = 4;

// Serveur limité (minimum sécurisé)
MemorySize = 47104;       // 46 MB
Iterations = 3;
```

#### 🔐 Processus de Hashing

**1. Génération du Hash (Inscription)** :

```csharp
public string HashPassword(string password)
{
    // 1. Génération d'un sel cryptographiquement sécurisé
    byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
    
    // 2. Hashing du mot de passe avec le sel
    byte[] hash = HashPasswordWithSalt(password, salt);
    
    // 3. Combinaison [Salt + Hash]
    byte[] combined = new byte[SaltSize + HashSize];
    Array.Copy(salt, 0, combined, 0, SaltSize);          // Copie du sel
    Array.Copy(hash, 0, combined, SaltSize, HashSize);   // Copie du hash
    
    // 4. Encodage en Base64 pour stockage en DB
    return Convert.ToBase64String(combined);
}

private byte[] HashPasswordWithSalt(string password, byte[] salt)
{
    using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
    {
        Salt = salt,
        Iterations = Iterations,
        MemorySize = MemorySize,
        DegreeOfParallelism = DegreeOfParallelism
    };
    
    return argon2.GetBytes(HashSize);
}
```

**Exemple de hash généré** :
```
Base64: "kQJ5tG7xZ8n2M4pR6vL9wS1dF3hK7mN0qP8aB5cE9gT4yU6iO2jX7nV1bM3zW5sH8fG0=="
         |<------- Salt 16 bytes ------>||<--------- Hash 32 bytes ----------->|
```

**2. Vérification du Hash (Connexion)** :

```csharp
public bool VerifyPassword(string password, string storedPassword)
{
    // 1. Décodage depuis Base64
    byte[] hashWithSalt = Convert.FromBase64String(storedPassword);
    
    // 2. Extraction du sel (16 premiers bytes)
    byte[] salt = new byte[SaltSize];
    Array.Copy(hashWithSalt, 0, salt, 0, SaltSize);
    
    // 3. Extraction du hash stocké (32 bytes suivants)
    byte[] storedHash = new byte[HashSize];
    Array.Copy(hashWithSalt, SaltSize, storedHash, 0, HashSize);
    
    // 4. Re-hashing du mot de passe fourni avec le même sel
    byte[] computedHash = HashPasswordWithSalt(password, salt);
    
    // 5. Comparaison en temps constant (protection contre timing attacks)
    return CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
}
```

#### 🛡️ Protection contre les Attaques

| Type d'Attaque | Protection Argon2id | Explication |
|----------------|---------------------|-------------|
| **Rainbow Tables** | ✅ Sel unique | Chaque mot de passe a un hash différent même si identiques |
| **Brute Force** | ✅ Coût CPU/RAM élevé | ~100-500ms par tentative = 2-10 tentatives/seconde max |
| **GPU Cracking** | ✅ Coût mémoire | Nécessite 64MB RAM par thread (limite parallélisation) |
| **Timing Attacks** | ✅ Comparaison temps constant | `FixedTimeEquals()` prend le même temps quelle que soit la différence |
| **Dictionary Attacks** | ✅ Sel + Itérations | Chaque mot de passe doit être hashé individuellement |

#### 📊 Comparaison des Algorithmes de Hashing

| Algorithme | Année | Statut OWASP | Résistance GPU | Résistance Side-Channel | Recommandation |
|------------|-------|--------------|----------------|-------------------------|----------------|
| **MD5** | 1992 | ❌ Cassé | ❌ | ❌ | ⛔ Ne jamais utiliser |
| **SHA-1** | 1995 | ❌ Déprécié | ❌ | ❌ | ⛔ Ne jamais utiliser |
| **SHA-256** | 2001 | ⚠️ Non recommandé | ❌ | ❌ | ⚠️ Seulement avec salt + itérations |
| **bcrypt** | 1999 | ⚠️ Acceptable | ⚠️ Limité | ✅ | ⚠️ Si Argon2 indisponible |
| **scrypt** | 2009 | ✅ Recommandé | ✅ | ⚠️ | ✅ Alternative à Argon2 |
| **Argon2id** | 2015 | ✅ **Préféré** | ✅ | ✅ | ⭐ **Choix recommandé** |

#### ⚡ Performance et Sécurité

**Temps de hashing (serveur standard)** :
```csharp
// Configuration actuelle (64 MB, 4 itérations)
HashPassword("P@ssw0rd123!")  → ~150-200ms
VerifyPassword()              → ~150-200ms

// Configuration renforcée (128 MB, 5 itérations)
HashPassword()                → ~300-400ms
VerifyPassword()              → ~300-400ms
```

**Impact sur l'expérience utilisateur** :
- ✅ **Inscription** : 200ms négligeable (opération rare)
- ✅ **Connexion** : 200ms acceptable (1-2 fois par jour)
- ✅ **Protection** : Brute force à ~5 tentatives/seconde max

**Nombre de tentatives par jour pour craquer un mot de passe** :
```
Mot de passe faible (8 caractères, lettres) : 
- Sans hashing : ~1 seconde (26^8 = 208 milliards)
- Avec Argon2id : ~130 ans (200ms par tentative)

Mot de passe fort (12 caractères, mixte) :
- Sans hashing : ~1 jour
- Avec Argon2id : ~10^15 ans 🎉
```

---

### 🌐 Politique CORS

Configuration CORS sécurisée avec liste d'origines autorisées :

```csharp
// appsettings.Development.json
{
  "Cors": {
    "AllowedOrigins": [
      "http://localhost:4200",   // Angular
      "http://localhost:3000",   // React
      "http://127.0.0.1:5500"    // LiveServer
    ]
  }
}
```

**Implémentation** :
```csharp
public static void ConfigureCorsPolicy(this IServiceCollection services, IConfiguration configuration)
{
    var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
    
    services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", policy =>
        {
            policy
                .WithOrigins(allowedOrigins ?? Array.Empty<string>())
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();  // Nécessaire pour JWT dans cookies (si utilisé)
        });
    });
}
```

⚠️ **Sécurité CORS** :
```csharp
// ❌ NE JAMAIS faire ça en production !
policy.AllowAnyOrigin()

// ✅ Toujours spécifier les origines autorisées
policy.WithOrigins("https://monapp.com", "https://admin.monapp.com")
```

---

### 🔐 Autorisation par Rôles

```csharp
// Accessible uniquement aux utilisateurs authentifiés
[Authorize]
public class TodosController : ControllerBase { }

// Accessible uniquement aux administrateurs
[Authorize(Roles = "Admin")]
public class UsersController : ControllerBase { }

// Accessible aux utilisateurs ET administrateurs
[Authorize(Roles = "User,Admin")]
public class ProfileController : ControllerBase { }
```

**Vérification dans le code** :
```csharp
// Dans un controller
if (User.IsInRole("Admin"))
{
    // Code pour administrateur
}

// Dans un service (avec injection de IHttpContextAccessor)
var user = _httpContextAccessor.HttpContext?.User;
var isAdmin = user?.IsInRole("Admin") ?? false;
```

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

3. **Configurer la chaîne de connexion et JWT**
   
   Modifier `appsettings.Development.json` si nécessaire :
   ```json
   {
     "ConnectionStrings": {
       "Default": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TodoListDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"
     },
     "JwtSettings": {
       "SecretKey": "VotreClefSecreteDe32CaractèresMinimum!",
       "Issuer": "TodoListAPI",
       "Audience": "TodoListClient",
       "ExpirationMinutes": 30
     },
     "Cors": {
       "AllowedOrigins": ["http://localhost:4200"]
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

## 📖 Utilisation de l'API

### 1. Inscription d'un Utilisateur

```http
POST /api/auth/register
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "P@ssw0rd123!",
  "firstname": "John",
  "lastname": "Doe"
}
```

**Validation du mot de passe** :
- ✅ Minimum 8 caractères
- ✅ Au moins 1 majuscule
- ✅ Au moins 1 minuscule
- ✅ Au moins 1 chiffre
- ✅ Au moins 1 caractère spécial (@$!%*?=&)

**Réponse (201 Created)** :
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "email": "user@example.com",
  "firstname": "John",
  "lastname": "Doe"
}
```

### 2. Connexion et Obtention du Token

```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "P@ssw0rd123!"
}
```

**Réponse (200 OK)** :
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI4ZjM2YzEyZi...",
  "expiration": "2026-01-28T14:30:00Z"
}
```

### 3. Utiliser le Token pour Accéder aux Endpoints Protégés

#### Dans Scalar (Documentation Interactive)

1. Cliquer sur le bouton **"Authorize"** 🔓
2. Coller le token (sans "Bearer")
3. Toutes les requêtes incluront automatiquement le header

#### Avec cURL

```bash
curl -X GET "https://localhost:7028/api/todos" \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
```

#### Avec Postman

1. Onglet **Authorization**
2. Type : **Bearer Token**
3. Coller le token dans le champ **Token**

### 4. Créer une Tâche

```http
POST /api/todos
Authorization: Bearer <votre_token>
Content-Type: application/json

{
  "title": "Apprendre ASP.NET Core",
  "description": "Étudier les Web APIs et Clean Architecture"
}
```

**Réponse (201 Created)** :
```json
{
  "id": "a1b2c3d4-5678-90ab-cdef-1234567890ab",
  "title": "Apprendre ASP.NET Core",
  "description": "Étudier les Web APIs et Clean Architecture",
  "status": 0,
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "createdAt": "2026-01-28T12:00:00Z",
  "isDeleted": false
}
```

### 5. Récupérer Toutes les Tâches

```http
GET /api/todos
Authorization: Bearer <votre_token>
```

**Réponse (200 OK)** :
```json
[
  {
    "id": "a1b2c3d4-5678-90ab-cdef-1234567890ab",
    "title": "Apprendre ASP.NET Core",
    "description": "Étudier les Web APIs et Clean Architecture",
    "status": 0,
    "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "createdAt": "2026-01-28T12:00:00Z",
    "isDeleted": false
  }
]
```

## 💡 Concepts Clés

### 1. **Clean Architecture**

La Clean Architecture organise le code en couches concentriques :

```
┌──────────────────────────────────────┐
│         API (Présentation)           │  ← Interface utilisateur
├──────────────────────────────────────┤
│        Core (Application)            │  ← Logique métier + Services
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
public class AuthService(
    IUserRepository _userRepository,
    IPasswordHasherService _passwordHasherService,
    IJwtService _jwtService
) : IAuthService
{    
    public async Task<LoginResponseDto> Login(LoginRequestDto credentials)
    {
        // 1. Validation des entrées
        if (string.IsNullOrWhiteSpace(credentials.Email) || 
            string.IsNullOrWhiteSpace(credentials.Password))
            throw new ArgumentException("Email et mot de passe requis");
        
        // 2. Récupération de l'utilisateur
        var user = await _userRepository.GetUserByEmail(credentials.Email);
        
        // 3. Vérification du mot de passe
        if (user == null || !_passwordHasherService.VerifyPassword(credentials.Password, user.Password))
            throw new UnauthorizedAccessException("Email ou mot de passe incorrect");
        
        // 4. Génération du token JWT
        return await _jwtService.GenerateToken(user);
    }
}
```

**Responsabilités** :
- ✅ Validation des règles métier
- ✅ Coordination entre plusieurs repositories
- ✅ Gestion des transactions
- ✅ Transformation des données (via Mappers)

### 4. **Dependency Injection**

L'injection de dépendance est configurée dans `Program.cs` et les `ServiceExtensions` :

```csharp
// Program.cs
builder.Services.ConfigureInfrastructure(builder.Configuration); // Repositories + DbContext
builder.Services.ConfigureCore();                                // Services métier
builder.Services.ConfigureCorsPolicy(builder.Configuration);     // CORS
builder.Services.ConfigureJwTAuthentication(builder.Configuration); // JWT

// ServiceExtensions.cs (Core)
public static void ConfigureCore(this IServiceCollection services)
{
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<ITodoService, TodoService>();
    services.AddScoped<IAuthService, AuthService>();
    services.AddScoped<IPasswordHasherService, PasswordHasherService>();
    services.AddScoped<IJwtService, JwtService>();
}
```

**Pattern utilisé** : Constructor Injection (C# 12 Primary Constructors)
```csharp
public class AuthService(
    IUserRepository _userRepository,
    IPasswordHasherService _passwordHasherService,
    IJwtService _jwtService
) : IAuthService
{
    // Les dépendances sont automatiquement injectées
}
```

#### 📚 Les 3 Lifetimes d'Injection de Dépendance

ASP.NET Core propose 3 méthodes pour enregistrer les services, chacune avec un cycle de vie différent :

##### 1️⃣ **AddTransient** - Instance par injection

```csharp
builder.Services.AddTransient<IEmailService, EmailService>();
```

**Comportement** :
- ✅ Une **nouvelle instance** est créée **à chaque injection**
- ✅ Même au sein d'une même requête HTTP

**Quand l'utiliser** :
- ✅ Services **légers et sans état** (stateless)
- ✅ Services qui ne doivent **pas être partagés**

##### 2️⃣ **AddScoped** - Instance par requête HTTP ⭐ **(Recommandé pour les repositories et services)**

```csharp
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
```

**Comportement** :
- ✅ Une **instance unique** par **requête HTTP**
- ✅ La même instance est réutilisée dans toute la requête
- ✅ Détruite à la fin de la requête

**Quand l'utiliser** :
- ✅ **Repositories** (accès aux données)
- ✅ **Services métier** (business logic)
- ✅ **DbContext** d'Entity Framework Core
- ✅ Services qui doivent **partager l'état durant une requête**

##### 3️⃣ **AddSingleton** - Instance unique pour toute l'application

```csharp
builder.Services.AddSingleton<ICacheService, MemoryCacheService>();
```

**Comportement** :
- ✅ **Une seule instance** pour toute la durée de vie de l'application
- ✅ Partagée entre **toutes les requêtes** et **tous les threads**

**Quand l'utiliser** :
- ✅ **Configuration** (IConfiguration, IOptions)
- ✅ **Cache en mémoire** (IMemoryCache)
- ✅ **Services coûteux** à initialiser

#### 📊 Tableau Comparatif

| Lifetime | Durée de vie | Instance par requête | Thread-safe requis | Usage typique |
|----------|--------------|----------------------|--------------------|---------------|
| **Transient** | Par injection | ❌ Non | ❌ Non | Services légers, stateless |
| **Scoped** | Par requête HTTP | ✅ Oui | ❌ Non | Repositories, Services, DbContext |
| **Singleton** | Toute l'application | ✅ Oui | ✅ **OUI** | Configuration, Cache, Loggers |

### 5. **Entity Framework Core Configurations**

Les configurations utilisent **Fluent API** pour plus de contrôle :

```csharp
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Contrainte d'email au niveau DB
        builder.ToTable(t => 
            t.HasCheckConstraint("CK_User_Email_Format", "Email LIKE '%_@%_.%_'"));
        
        // Relation 1-N avec cascade delete
        builder.HasMany(u => u.Todos)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Longueur max du mot de passe (pour Argon2id)
        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(100);
    }
}
```

### 6. **Primary Constructor (C# 12)**

Syntaxe simplifiée pour l'injection de dépendance :

```csharp
// Ancienne syntaxe
public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasherService;
    
    public AuthService(
        IUserRepository userRepository,
        IPasswordHasherService passwordHasherService)
    {
        _userRepository = userRepository;
        _passwordHasherService = passwordHasherService;
    }
}

// Nouvelle syntaxe (C# 12)
public class AuthService(
    IUserRepository _userRepository,
    IPasswordHasherService _passwordHasherService
) : IAuthService
{
    // _userRepository et _passwordHasherService sont directement disponibles
}
```

### 7. **DTOs et Mappers**

Les DTOs (Data Transfer Objects) séparent les entités du domaine des données exposées par l'API :

```csharp
// DTO de requête
public class RegisterRequestDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?=&])[A-Za-z\d@$!%*?=&]{8,}$")]
    public string Password { get; set; } = null!;
}

// DTO de réponse
public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    // ❌ Pas de Password dans la réponse !
}

// Mapper (Extension Method)
public static class UserMapperExtensions
{
    public static UserResponseDto ToUserResponseDto(this User user)
    {
        return new UserResponseDto
        {
            Id = user.Id,
            Email = user.Email,
            Firstname = user.Firstname,
            Lastname = user.Lastname
        };
    }
}
```

**Avantages** :
- ✅ **Sécurité** : Empêche l'exposition de données sensibles (mot de passe)
- ✅ **Validation** : Contrôle des données entrantes avec Data Annotations
- ✅ **Découplage** : Le modèle de domaine peut évoluer indépendamment de l'API
- ✅ **Flexibilité** : Différentes représentations pour Create/Update/Response

## 🔮 Fonctionnalités à Venir

### Phase 1 : Améliorations des Endpoints *(En cours)*
- [ ] Implémenter `PUT /api/todos/{id}` (Update Todo)
- [ ] Implémenter la pagination pour les listes
- [ ] Ajouter des filtres de recherche (par status, par date)
- [ ] Implémenter le soft delete pour les utilisateurs

### Phase 2 : Sécurité Avancée
- [ ] **Refresh Tokens**
  - Endpoint `/api/auth/refresh`
  - Stockage sécurisé des refresh tokens
  - Rotation automatique des tokens
  
- [ ] **Rate Limiting**
  - Limitation des tentatives de connexion
  - Protection contre les attaques par force brute
  
- [ ] **Email Confirmation**
  - Envoi d'email de confirmation à l'inscription
  - Validation du compte avant activation

### Phase 3 : Monitoring et Logging
- [ ] **Serilog** pour le logging structuré
- [ ] **Application Insights** pour le monitoring
- [ ] **Health Checks** pour vérifier l'état de l'API
- [ ] **Middleware de gestion d'erreurs** global

### Phase 4 : Tests
- [ ] Tests unitaires des Services
- [ ] Tests unitaires des Repositories
- [ ] Tests d'intégration des Controllers
- [ ] Tests de sécurité (authentication/authorization)

### Phase 5 : DevOps
- [ ] Dockerisation de l'application
- [ ] CI/CD avec GitHub Actions
- [ ] Déploiement sur Azure App Service
- [ ] Configuration des secrets avec Azure Key Vault

### Phase 6 : Fonctionnalités Avancées *(Optionnel)*
- [ ] Versioning de l'API (v1, v2)
- [ ] GraphQL endpoint
- [ ] SignalR pour les notifications en temps réel
- [ ] Export des todos en PDF/Excel
- [ ] Système de tags pour les todos
- [ ] Partage de todos entre utilisateurs

## 📊 Schéma de la Base de Données

```sql
┌──────────────────────────────┐
│           Users              │
├──────────────────────────────┤
│ Id (PK)         GUID         │
│ Email           NVARCHAR(255)│ ← Contrainte format email
│ Password        NVARCHAR(100)│ ← Hashé avec Argon2id
│ Role            INT          │ ← 0=User, 1=Admin
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
│ Status          INT           │ ← 0=NotStarted, 1=InProgress, 2=Completed
│ UserId (FK)     GUID          │
│ CreatedAt       DATETIME2     │ ← Défaut: GETDATE()
│ IsDeleted       BIT           │ ← Soft delete
└───────────────────────────────┘

Relation : Users.Id (1) ←──→ (N) Todos.UserId
Cascade Delete : Activé
```


## 📝 Licence

Ce projet est sous licence MIT - voir le fichier [LICENSE](LICENSE.txt) pour plus de détails.

## 📚 Ressources

### Documentation Officielle
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [JWT Bearer Authentication](https://jwt.io/introduction)
- [Argon2 OWASP Recommendations](https://cheatsheetseries.owasp.org/cheatsheets/Password_Storage_Cheat_Sheet.html#argon2id)

### Architecture
- [Clean Architecture par Uncle Bob](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Repository Pattern](https://docs.microsoft.com/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)
- [Dependency Injection in .NET](https://docs.microsoft.com/aspnet/core/fundamentals/dependency-injection)

### Sécurité
- [JWT Best Practices](https://auth0.com/blog/a-look-at-the-latest-draft-for-jwt-bcp/)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [Password Hashing with Argon2](https://www.twelve21.io/how-to-use-argon2-for-password-hashing-in-csharp/)

---

**Développé avec ❤️ pour l'apprentissage de ASP.NET Core Web API**

*Pour toute question ou suggestion, n'hésitez pas à ouvrir une issue ou à me contacter.*

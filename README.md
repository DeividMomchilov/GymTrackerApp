# 🏋️ GymTrackerApp

![.NET Version](https://img.shields.io/badge/.NET-10.0-purple)
![License](https://img.shields.io/badge/License-MIT-blue)
![Deployment](https://img.shields.io/badge/Deployment-Azure-0078D4?logo=microsoftazure)
![Status](https://img.shields.io/badge/Status-Completed-green)

**GymTrackerApp** is a robust ASP.NET Core MVC web application designed to help users track their fitness journey. It allows users to create personalized workout routines, manage a library of exercises, explore muscle groups, and track their historical workout sessions efficiently.

---

## ☁️ Live Deployment & Testing
* **Live Demo:** [Visit GymTrackerApp Here](https://[YOUR-AZURE-LINK-HERE].azurewebsites.net)
* **Cloud Infrastructure:** Fully deployed to the public using **Azure App Service**, connected to a securely configured **Azure SQL Database**.
* **Unit Testing:** The core business logic is heavily tested using the **NUnit** framework and the **EF Core In-Memory Database** to ensure 100% data integrity without touching production tables.

---

## 🚀 Key Features

### 👑 **Administration Area & Roles**
* **MVC Admin Area:** A completely isolated, secure routing area (`/Admin/...`) dedicated to system management.
* **Role-Based Access Control:** Uses ASP.NET Core Identity to distinguish between regular `User` and `Admin` roles.
* **Global Moderation:** Administrators bypass standard ownership checks, allowing them to edit or delete *any* exercise in the system to maintain quality control.
* **Anatomy Catalog Control:** Only Administrators have the authority to edit Muscle groups and update their anatomical descriptions and images.

### 👤 **User System & Security**
* **Authentication & Authorization:** Secure Registration and Login using **ASP.NET Core Identity**.
* **Resource-Based Authorization:** Users have exclusive control over their own routines, custom exercises, and workout history. They cannot edit or delete data created by others.
* **CSRF Protection & Validation:** Full Anti-Forgery Token implementation and rigorous ViewModel `[Required]` / `[StringLength]` validations to prevent bad data.

### 📚 **Exercise & Muscle Library**
* **Browse by Muscle Group:** Interactive UI to explore different muscle groups and view all specific exercises targeting them.
* **Create Custom Exercises:** Users can expand the library by adding new exercises with descriptions, images, and targeted muscle groups.
* **Search & Pagination:** Optimized data querying to handle large catalogs of exercises smoothly.

### 📋 **Workout Management**
* **Create Routines:** Build custom workout plans (e.g., "Monday Chest Day", "Full Body Friday").
* **Workout Builder:** Add exercises to specific workouts with custom **Sets**, **Reps**, and **Weight** targets.
* **Safety Checks:** Backend logic prevents the deletion of exercises that are currently tied to historical workout sessions.

### ⏱️ **Session Tracking & History**
* **Log Workouts:** Users can mark a workout as "Completed" directly from the details page.
* **Chronological History:** A dedicated history dashboard displaying all past completed sessions, keeping users motivated.

### 🎨 **Premium UI / UX Design**
* Fully responsive, custom dark-themed UI utilizing **Bootstrap 5**.
* Features modern web design elements including **CSS keyframe animations (pulse effects)**, **hover-lift cards**, **image zooming**, **glassmorphism (backdrop filters)**, and **gradient typography**.

---

## 🏗️ Architecture & Technologies

The solution follows a strict **N-Tier Architecture** to cleanly separate concerns, ensure maintainability, and allow for easy unit testing.

### **1. Layered Architecture**
* **GymTrackerApp (Web Layer):** Contains Controllers, Razor Views, MVC Areas (`Admin`), and the Dependency Injection container (`Program.cs`).
* **GymTrackerApp.Services:** Contains the core business logic (`WorkoutService`, `ExerciseService`, `MuscleService`, `SessionService`) utilizing Interfaces to keep Controllers thin.
* **GymTrackerApp.Data:** Handles the Database Context (`ApplicationDbContext`), Migrations, and `IEntityTypeConfiguration` seeding files.
* **GymTrackerApp.Data.Models:** Defines the database entities (`Workout`, `Exercise`, `Muscle`, `WorkoutExercise`, `WorkoutSession`, `IdentityUser`).
* **GymTrackerApp.ViewModels:** Defines ViewModels for data transfer between Views and Controllers, utilizing strict Data Annotations.
* **GymTrackerApp.Common:** Holds global constants, validation constraints, and helper logic.
* **GymTrackerApp.Tests:** Dedicated test project guaranteeing the integrity of the business logic.

### **2. Tech Stack**
* **Framework:** ASP.NET Core MVC (.NET 10.0)
* **Database:** Microsoft SQL Server & Azure SQL Database
* **ORM:** Entity Framework Core (Code-First Approach)
* **Testing:** NUnit, EF Core In-Memory Database
* **Front-End:** HTML5, CSS3, Bootstrap 5, Bootstrap Icons, jQuery Validation Unobtrusive.
* **Deployment:** Microsoft Azure App Service

---

## ⚙️ Setup & Installation Instructions

To run this project locally, follow these steps:

1. **Clone the repository:**
   ```git clone [https://github.com/your-username/GymTrackerApp.git](https://github.com/your-username/GymTrackerApp.git)```
2. Set up the Database:
Open the Package Manager Console in Visual Studio, ensure GymTrackerApp.Data is selected as the Default Project, and run:
   ```Update-Database```
3.Run the Application:
Set GymTrackerApp as the startup project and press F5.

🔑 Default Seeded Data

Upon running Update-Database, Entity Framework Core will automatically seed the database with:
```bash
    17 Anatomically accurate Muscle Groups (with descriptions and images).
    8 Standard Global Exercises.
    Identity Roles (Admin and User).
    A default Administrator account.
```
To access the Admin Panel, log in with:
```bash
    Email: admin@gymtracker.com
    Password: Admin123!
```

📂 Project Structure Snapshot:
```bash
GymTrackerApp/
├── GymTrackerApp/              # Web Layer (Controllers, Views, wwwroot)
│   ├── Areas/Admin/            # MVC Administration Area
│   └── Areas/Identity/         # ASP.NET Core Identity Pages
├── GymTrackerApp.Services/     # Business Logic (Services & Interfaces)
├── GymTrackerApp.Data/         # DbContext, Migrations, Seeding Configurations
├── GymTrackerApp.Data.Models/  # Database Entities
├── GymTrackerApp.ViewModels/   # DTOs and Form Validation Models
├── GymTrackerApp.Common/       # Constants & Validation Helpers
└── GymTrackerApp.Tests/        # NUnit Tests Project

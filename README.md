# 🏋️ GymTrackerApp

![.NET Version](https://img.shields.io/badge/.NET-10.0-purple)
![License](https://img.shields.io/badge/License-MIT-blue)
![Status](https://img.shields.io/badge/Status-Completed-green)

**GymTrackerApp** is a robust ASP.NET Core MVC web application designed to help users track their fitness journey. It allows users to create personalized workout routines, manage a library of exercises, explore muscle groups, and track their historical workout sessions efficiently.

Originally developed for the **ASP.NET Fundamentals** course, this project has been heavily expanded for the **ASP.NET Advanced** course. It demonstrates mastery of modern web development practices, **SOLID principles**, and **N-Tier Architecture**.

---

## 🚀 Key Features

### 👤 **User System**
* **Authentication & Authorization:** Secure Registration and Login using **ASP.NET Core Identity**.
* **Personalized Data:** Users have exclusive control over their own routines, custom exercises, and workout history.

### 📚 **Exercise & Muscle Library**
* **Browse by Muscle Group:** Interactive UI to explore different muscle groups and view all specific exercises targeting them.
* **Public Exercise Library:** View a comprehensive list of exercises. 
* **Create Custom Exercises:** Users can expand the library by adding new exercises with descriptions, images, and targeted muscle groups.
* **Validation:** Prevents duplicate exercise names and ensures database integrity.

### 📋 **Workout Management**
* **Create Routines:** Build custom workout plans (e.g., "Monday Chest Day", "Full Body Friday").
* **Workout Builder:** Add exercises to specific workouts with custom **Sets**, **Reps**, and **Weight** targets.
* **Dynamic Editing:** Add or remove exercises from routines seamlessly.
* **Safety Checks:** Backend logic prevents the deletion of exercises that are currently in use by any workout routine.

### ⏱️ **Session Tracking & History**
* **Log Workouts:** Users can mark a workout as "Completed" directly from the details page.
* **Adjustable Duration:** Includes a sleek UI to adjust the total time (in minutes) spent on the session.
* **Chronological History:** A dedicated history dashboard displaying all past completed sessions, keeping users motivated.

---

## 🏗️ Architecture & Technologies

The solution follows a strict **N-Tier Architecture** to cleanly separate concerns, ensure maintainability, and allow for easy unit testing.

### **1. Architecture Overview**
* **GymTrackerApp (Web Layer):** Contains Controllers (`WorkoutsController`, `ExercisesController`, `MusclesController`, `SessionsController`), Views (Razor Pages), and the Dependency Injection container (`Program.cs`).
* **GymTrackerApp.Services:** Contains the business logic layer (`WorkoutService`, `ExerciseService`, `MuscleService`, `SessionService`) implementing Interfaces to keep Controllers thin.
* **GymTrackerApp.Data:** Handles the Database Context (`ApplicationDbContext`), Migrations, and Entity Configurations.
* **GymTrackerApp.Data.Models:** Defines the database entities (`Workout`, `Exercise`, `Muscle`, `WorkoutExercise`, `WorkoutSession`).
* **GymTrackerApp.ViewModels:** Defines ViewModels for data transfer between Views and Controllers, including strict Data Annotations.
* **GymTrackerApp.Common:** Holds global constants, validation constraints, and helper logic.

### **2. Tech Stack**
* **Framework:** ASP.NET Core MVC (.NET 10)
* **Database:** Microsoft SQL Server
* **ORM:** Entity Framework Core (Code-First Approach)
* **Front-End:**
    * **Bootstrap 5:** For responsive, dark-themed, and modern UI.
    * **Razor Views (.cshtml):** For dynamic server-side HTML rendering.
    * **Bootstrap Icons:** For clean and scalable visual elements.
    * **Validation:** jQuery Validation Unobtrusive for instant client-side feedback.

---

## 📂 Project Structure

```bash
GymTrackerApp/
├── GymTrackerApp/              # Web Layer (Controllers, Views, wwwroot)
├── GymTrackerApp.Services/     # Business Logic (Services & Interfaces)
├── GymTrackerApp.Data/         # DbContext, Migrations, Seeding
├── GymTrackerApp.Data.Models/  # Database Entities
├── GymTrackerApp.ViewModels/   # DTOs and Form Models
└── GymTrackerApp.Common/       # Constants & Validation Helpers

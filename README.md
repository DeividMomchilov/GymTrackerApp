# 🏋️ GymTrackerApp

![.NET Version](https://img.shields.io/badge/.NET-10.0-purple)
![License](https://img.shields.io/badge/License-MIT-blue)
![Status](https://img.shields.io/badge/Status-Completed-green)

**GymTrackerApp** is a robust ASP.NET Core MVC web application designed to help users track their fitness journey. It allows users to create personalized workout routines, manage a library of exercises, and track their progress efficiently.

This project was developed as a submission for the **ASP.NET Fundamentals** course, demonstrating adherence to modern web development practices, **SOLID principles**, and **N-Tier Architecture**.

---

## 🚀 Key Features

### 👤 **User System**
* **Authentication & Authorization:** Secure Registration and Login using **ASP.NET Core Identity**.
* **Personalized Data:** Users can only view, edit, and delete their own workouts and custom exercises.

### 📚 **Exercise Library**
* **Browse Exercises:** View a public library of exercises categorized by muscle groups (e.g., Chest, Back, Legs).
* **Create Custom Exercises:** Users can add new exercises with descriptions and images.
* **Validation:** Prevents duplicate exercise names and ensures data integrity.

### 📋 **Workout Management**
* **Create Routines:** Build custom workout plans (e.g., "Monday Chest Day").
* **Workout Builder:** Add exercises to specific workouts with custom **Sets**, **Reps**, and **Weight** targets.
* **Dynamic Editing:** Add or remove exercises from routines seamlessly.
* **Safety Checks:** Logic to prevent deleting exercises that are currently in use by a workout.

---

## 🏗️ Architecture & Technologies

The solution follows a modular **N-Tier Architecture** to separate concerns and ensure maintainability:

### **1. Architecture Overview**
* **GymTrackerApp (Web Layer):** Contains Controllers (`WorkoutsController`, `ExercisesController`, `MuscleController`), Views (Razor Pages), and the Dependency Injection container (`Program.cs`).
* **GymTrackerApp.Services:** Contains the business logic layer (`WorkoutService`, `ExerciseService`, `MuscleService`) implementing Interfaces to keep Controllers "skinny."
* **GymTrackerApp.Data:** Handles the Database Context (`ApplicationDbContext`) and Entity Configurations.
* **GymTrackerApp.Data.Models:** Defines the database entities (`Workout`, `Exercise`, `Muscle`, `WorkoutExercise`).
* **GymTrackerApp.ViewModels:** Defines ViewModels for data transfer between Views and Controllers, including validation attributes.
* **GymTrackerApp.Common:** Holds global constants and validation rules.

### **2. Tech Stack**
* **Framework:** ASP.NET Core MVC (.NET 10)
* **Database:** Microsoft SQL Server
* **ORM:** Entity Framework Core (Code-First Approach)
* **Front-End:**
    * **Bootstrap 5:** For responsive, dark-themed UI.
    * **Razor Views (.cshtml):** For server-side rendering.
    * **Bootstrap Icons:** For visual elements.
    * **Validation:** jQuery Validation Unobtrusive.

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

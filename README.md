# Homely Web Api

A RESTful API built using ASP.NET Core for managing residential unit listings, reservations, user authentication, and wishlists. Designed to serve as the backend for a property rental web application.

## 🚀 Features:

### 🔐 Authentication & Authorization
   - User Registration & Login
   - JWT & Refresh Token Support
   - Role-Based Authorization
   - 🏡 Residential Units Management
   - Add, Edit, Delete Units (by Host)
   - Filter Units by Host ID or Unit ID
### 💖 Wishlist
   - Add to Wishlist
   - View Wishlist by User
   - Remove from Wishlist
### 📅 Reservation System
   - Create Reservation
   - Update Reservation
   - Get Reservations by User
   - Date Conflict Validation
 
 ## 🛠 Tech Stack:
  
  - ASP.NET Core 9
  - Entity Framework Core
  - SQL Server
  - JWT Authentication
  - Swagger for API Documentation

## 📁 Project Structure 
      |- Controllers
      |- Data
      |- DTOs
      |-Models
      |- Services
        |- Interfaces
        |- Implementation

## 🔐 Environment Variables
### Create a .env file in the root with the following:
   - ConnectionStrings__DefaultConnection="<your-connection-string>"
   -  Jwt__Key="<your-jwt-secret>"
   -  Jwt__Issuer="<your-jwt-Issuer>"
   -  Jwt__Audience="<your-jwt-Audience>"
   -  Jwt__ExpireMinutes=<Minutes Num>
   -  Jwt__RefreshTokenExpiryInDays=<Days Num>

## 🧪 Development Setup
   1-  git clone https://github.com/yourusername/Homely-Api.git
   
   2- Add a .env file with your sensitive configurations.
   
   3- Run the API locally: 
   
      dotnet run .
    

 
  

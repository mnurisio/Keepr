# Keepr 📸🔒

Keepr is a web application that allows users to create and organize image collections. Users can create **Vaults** based on categories or topics and store **Keeps**—individual images—inside them. Vaults can be public or private, giving users control over their collections.

## 🚀 Features

- 🔹 **Vaults**: Create and manage categorized collections of images.
- 🔹 **Keeps**: Add images to your vaults with a short description.
- 🔹 **VaultKeeps**: Represents the many-to-many relationship created when a Keep is added to a Vault, allowing Keeps to exist in multiple Vaults.
- 🔹 **Privacy Control**: Choose to make vaults private or share them with others.
- 🔹 **Modal View**: Clicking on a Keep opens a modal with details and an option to add it to a vault.

## 🛠 Tech Stack

| **Technology**   | **Description**            |
|-----------------|---------------------------|
| 🖥️ **Frontend**  | Vue.js                     |
| 🔙 **Backend**   | .NET (C#)                  |
| 🗄 **Database**  | MySQL                      |
| 🔐 **Auth**      | Auth0                      |

## 🎯 Project Purpose

Keepr is a **portfolio project** designed to demonstrate full-stack development skills. It showcases the ability to build a dynamic web application with user authentication, database interactions, and front-end functionality.

## ⚙️ Technical Highlights

- 📡 **RESTful API Structure**: The backend follows a RESTful architecture with clear endpoints for Vaults, Keeps, and VaultKeeps.
- 🛡 **Middleware Security**: Middleware is implemented in the C# repository folders to prevent SQL injection and enhance security.
- 🔑 **Authorization**: Auth0 is used for authentication, and authorization is enforced to restrict actions such as creating, deleting, and fetching user-specific data.
- 📊 **Database Design**: The database employs **foreign keys** and **cascade deletes** to maintain referential integrity.
- 🔄 **VaultKeeps Relationship**: The `VaultKeeps` table represents a many-to-many relationship with:
  - `vaultKeepId` (Primary Key)
  - `keepId`
  - `vaultId`
  - `accountId`
  - Various VaultKeep models inherit other classes to fit specific CRUD methods.

## 📌 Usage Overview

1. **🔑 Sign up or log in** to create and manage vaults.
2. **🌍 Browse the homepage** for keeps shared by other users.
3. **🖼 Click on a Keep** to open a modal with details and the option to add it to a vault.
4. **📂 Create Vaults** to organize your keeps by category or topic.
5. **🔒 Set Vault Privacy** to keep collections private or share them publicly.

## 📬 Contact

Developed by **Mike Nurisio**  
📂 GitHub: mnurisio

# 🧑‍💻 Internship Application Portal

A secure and cloud-based internship application portal built with **ASP.NET Core Web API**, **SQL Server**, and a **static HTML frontend** hosted on Azure.

---

## 🚀 Live Demo

- 🌐 Frontend: [internfrontendweb01.z13.web.core.windows.net](https://internfrontendweb01.z13.web.core.windows.net)
- 🔗 Backend API: [intern-api-alif.azurewebsites.net/api/Interns](https://intern-api-alif.azurewebsites.net/api/Interns)

---

## 📌 Features

✅ Submit internship applications via a simple HTML form  
✅ Admin-only page to view submitted applications  
✅ Resume upload functionality (PDF/JPG)  
✅ SQL Server database integration via Entity Framework Core  
✅ Secrets securely retrieved from **HashiCorp Vault**  
✅ Deployed to Azure using **GitHub Actions (CI/CD)**  
✅ CORS enabled for frontend-backend communication  

---

## 🛡️ Security

🔒 Database credentials (username & password) are **not hardcoded**.  
They are securely stored and retrieved from **HashiCorp Vault** at runtime.  
The app uses environment variables to fetch secrets safely.

---

## 🛠️ Tech Stack

| Layer       | Technology                          |
|------------|--------------------------------------|
| Frontend    | HTML5, Bootstrap 5, JavaScript       |
| Backend     | ASP.NET Core Web API (C#)            |
| Secrets     | HashiCorp Vault (local dev setup)    |
| Database    | Azure SQL Database (EF Core)         |
| Deployment  | Azure App Service + Static Web App   |
| CI/CD       | GitHub Actions                       |

---

## 📸 Screenshots

### 📝 Submit Internship Application Form  
![Submit Form Screenshot](screenshots/submit-form.png)

### 🔐 Admin Login Page  
![Admin Login Screenshot](screenshots/admin-login.png)

### 📋 Admin Application Dashboard  
![Admin Dashboard Screenshot](screenshots/admin-application-data.png)

### 🗄️ Data Stored in SQL Server  
![SQL Server Screenshot](screenshots/SQL-server-database.png)

### 📝 Vault Code 
![SQL Server Screenshot](screenshots/vault-code.png)

---

## 🧠 Learning Highlights

- Azure App Service & Static Web App deployment  
- ASP.NET Core Web API with secure credentials handling  
- Entity Framework Core with Azure SQL  
- GitHub Actions for automated CI/CD  
- CORS setup for frontend-backend communication  
- Secrets Management using HashiCorp Vault

---

## 📬 Contact

👤 **Name:** Alif Danial  
💼 **LinkedIn:** [linkedin.com/in/alifdanial969](https://www.linkedin.com/in/alifdanial969)  
📧 **Email:** alifdanial969@gmail.com

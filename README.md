# MsOtomasyon - WPF Business Management Application 🖥️

[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![WPF](https://img.shields.io/badge/WPF-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)

**MsOtomasyon** is a desktop application built with Windows Presentation Foundation (WPF) and .NET. It serves as a basic business management system, providing a clean and user-friendly interface to manage customers, products, and orders.

---

## 📝 Table of Contents

- [✨ Core Features](#-core-features)
- [🛠️ Tech Stack](#️-tech-stack)
- [📂 Project Structure](#-project-structure)
- [🚀 Setup and Launch](#-setup-and-launch)
- [🤝 Contributing](#-contributing)

---

## ✨ Core Features

-   **Customer Management:** Add, view, update, and delete customer records.
-   **Product Management:** Manage the product catalog, including details like name, price, and stock.
-   **Order Management:** Create and track customer orders.
-   **Modern UI:** A clean, navigable user interface with a sidebar for easy access to different modules.
-   **Page-Based Navigation:** A single-window application that dynamically loads different pages (Customers, Products, etc.) into the main content area.
-   **Custom Styling:** Centralized styling for a consistent look and feel across the application.

---

## 🛠️ Tech Stack

### Framework & Language

-   **Framework:** .NET 7, WPF (Windows Presentation Foundation)
-   **Language:** C#
-   **Architecture:** The project follows the MVVM (Model-View-ViewModel) design pattern, separating the UI from the business logic.

### User Interface

-   **XAML:** Used for defining the user interface and layout.
-   **XAML Styles:** Reusable styles are defined in a separate resource dictionary for consistency.

---

## 📂 Project Structure

The project is organized with a clear separation of concerns, making it easy to maintain and scale.

```
MsOtomasyon/
├── Models/                 # Contains the data models (Customer, Product, Order)
│   ├── Customer.cs
│   ├── Product.cs
│   └── Order.cs
├── Pages/                  # UI Pages for different modules
│   └── CustomersPage.xaml
│   └── CustomersPage.xaml.cs
├── Resources/              # Application resources like icons
│   └── app.ico
├── Styles/                 # Shared XAML styles
│   └── MainStyles.xaml
├── App.xaml                # Application definition
├── MainWindow.xaml         # The main application window and navigation host
├── MsOtomasyon.csproj      # Project file
└── MsOtomasyon.sln         # Solution file
```

---

## 🚀 Setup and Launch

### Prerequisites

-   [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
-   [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) with the ".NET desktop development" workload installed.

### Installation Steps

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/your-username/MsOtomasyon.git](https://github.com/your-username/MsOtomasyon.git)
    cd MsOtomasyon
    ```

2.  **Open the solution:**
    Open the `MsOtomasyon.sln` file in Visual Studio 2022.

3.  **Restore NuGet Packages:**
    Visual Studio should automatically restore the required packages. If not, right-click the solution in the Solution Explorer and select "Restore NuGet Packages".

4.  **Build and Run:**
    Press `F5` or click the "Start" button in the Visual Studio toolbar to build and run the application.

---

## 🤝 Contributing

Contributions are welcome! If you have suggestions or want to improve the application, please follow these steps:

1.  **Fork** this repository.
2.  Create a new feature branch (`git checkout -b feature/new-feature`).
3.  **Commit** your changes (`git commit -m 'feat: Add some new feature'`).
4.  **Push** to the branch (`git push origin feature/new-feature`).
5.  Open a **Pull Request**.

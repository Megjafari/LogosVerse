# LogosVerse

A modern Bible application built with C#.

## Features

*   **Bible Reading:** Access and read different books and verses of the Bible.
*   **AI Service:** Integrates an AI service for enhanced features.
*   **User Management:** Supports user accounts for a personalized experience.
*   **Notifications:** A notification system to keep users engaged.

## Project Structure

The project is organized into the following directories:

-   `Models/`: Contains the data models for the application (e.g., `BibleBook`, `BibleVerse`, `User`).
-   `Services/`: Houses the business logic and services (e.g., `BibleService`, `AIService`, `UserService`, `NotificationService`).
-   `Helper/`: Includes helper classes and utilities (e.g., `BibleBooks`, `MenuHelper`).
-   `Properties/`: Contains project properties and launch settings.

## Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

-   [.NET SDK](https://dotnet.microsoft.com/download)

### Installation

1.  Clone the repo
    ```sh
    git clone https://github.com/Megjafari/LogosVerse.git
    ```
2.  Navigate to the project directory
    ```sh
    cd LogosVerse
    ```
3.  Restore dependencies
    ```sh
    dotnet restore
    ```
4.  Run the application
    ```sh
    dotnet run
    ```

## Usage

Use the application through the console menu to navigate through different books of the Bible, read verses, and interact with the AI features.

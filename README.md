### Hotel-Management-System-Using-Microsoft-Access-Database

This is a simple desktop application for managing a hotel, built with C# and the .NET Framework/.NET Core. The application allows adding and managing available rooms, recording reservations, and tracking their status.

## Technologies Used

- **C#** - Programming language used for developing the application.
- **.NET Framework/.NET Core** - Development platform.
- **Visual Studio** - IDE used for development.
- **Microsoft Access** - Database for storing room and reservation information.

## Installation

1. **Clone the Repository**
   - To get started with the project, clone the repository using the following command:
     ```bash
     git clone https://github.com/username/HotelApp.git
     ```

2. **Install Dependencies**
   - Make sure you have [Visual Studio](https://visualstudio.microsoft.com/) installed with support for C# development.
   - Open the project folder in Visual Studio.
   - If the app uses NuGet packages, run the following command:
     ```bash
     dotnet restore
     ```

3. **Set Up the Database**
   - The application uses **Microsoft Access** for storing data.
   - Ensure you have Microsoft Access installed or use **Microsoft Access Database Engine** if you don’t have Access installed.
   - The database file is located in the project folder. Ensure the connection string in the application is properly set to point to the `.accdb` file.

4. **Configure the Database Connection**
   - Open the connection string in the application’s configuration settings (e.g., `app.config` or `appsettings.json`).
   - Update the path to the Access database file (`AplicatieHotel.accdb`).

## Features

- **Room Management**: Allows adding, editing, and deleting available rooms in the hotel.
- **Reservations**: Allows users to make reservations for rooms and view current bookings.
- **Data Storage**: Data is stored in a Microsoft Access database.

## Screenshots

Here are some screenshots of the application in action:

1. ![Screenshot 1](image1.png)
2. ![Screenshot 2](image2.png)
3. ![Screenshot 3](image3.png)
4. ![Screenshot 4](image4.png)

## License

This project is licensed under the [MIT License](LICENSE).

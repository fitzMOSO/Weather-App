# Weather App

This is a .NET-based Weather Application that demonstrates the implementation of Object-Oriented Programming (OOP) principles and secure configuration management.

## Object-Oriented Programming Implementation

### 1. Encapsulation
- **Implementation**: The application uses proper data encapsulation through models and viewmodels
- **Location**: `/Models` and `/ViewModel` directories
- **Purpose**: Data and behavior are bundled together, with internal state protected from unauthorized access
- **Example**: Weather-related data models encapsulate their properties with proper access modifiers

### 2. Inheritance
- **Implementation**: Utilizes class inheritance for extending base functionality
- **Location**: `/Controllers` and `/Services` directories
- **Purpose**: Promotes code reuse and establishes "is-a" relationships
- **Example**: Controllers inherit from base Controller class, providing common functionality

### 3. Polymorphism
- **Implementation**: Interface-based polymorphism through service interfaces
- **Location**: `/Services/Interfaces` directory
- **Purpose**: Enables different implementations of the same interface, allowing for flexibility and testability
- **Example**: Weather service implementations can be swapped without changing dependent code

### 4. Abstraction
- **Implementation**: Abstract interfaces and service layers hiding implementation details
- **Location**: `/Services/Interfaces` directory
- **Purpose**: Hides complex implementation details and exposes only necessary features
- **Example**: Weather data retrieval abstracted behind clean service interfaces

## Configuration Management

### API Keys and Secrets in appsettings.json

The application uses `appsettings.json` for configuration management for several reasons:

1. **Built-in Support**: 
   - ASP.NET Core's configuration system natively supports JSON configuration files
   - Seamless integration with dependency injection

2. **Environment-Specific Configuration**:
   - Supports different settings for development, staging, and production
   - Easy to override settings using environment variables

3. **Security Considerations**:
   - `appsettings.json` should be added to `.gitignore` for production environments
   - Secrets can be managed using Azure Key Vault or similar services in production
   - Development secrets can be stored in `appsettings.Development.json`

4. **Best Practices**:
   - Configuration is externalized from code
   - Easy to modify without recompiling
   - Follows the 12-factor app methodology for config management

## Project Structure

```
Weather-App/
├── Controllers/         # MVC Controllers
├── Models/             # Data models
├── Services/           # Business logic and external service integration
│   └── Interfaces/    # Service contracts
├── ViewModel/          # View-specific models
├── Views/              # MVC Views
└── wwwroot/           # Static files (CSS, JS, etc.)
```

## Getting Started

1. Clone the repository
2. Update `appsettings.json` with your API keys
3. Run the application using `dotnet run`

## Security Note

For production deployment:
1. Never commit sensitive data to source control
2. Use secure secret management solutions
3. Consider using Azure Key Vault or similar services
4. Use environment variables for sensitive configuration in production 
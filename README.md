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

## Production Build

### Release Configuration

1. Clean the solution:

   ```bash
   dotnet clean
   ```

2. Build in Release mode:

   ```bash
   dotnet build --configuration Release
   ```

3. Publish the application:
   ```bash
   dotnet publish --configuration Release --output ./publish
   ```

### Release Build Benefits

- Optimized code execution
- Removal of debug symbols
- Smaller deployment size
- Better performance
- Just-In-Time (JIT) compilation optimizations

### Pre-deployment Checklist

1. Verify all debug/development settings are disabled
2. Ensure logging levels are appropriate for production
3. Check all production connection strings
4. Validate HTTPS configuration
5. Review and update application pool settings
6. Perform security scanning of dependencies

## Environment Configuration

### Setting Environment

1. Development (uses `appsettings.Development.json`):

   ```bash
   set ASPNETCORE_ENVIRONMENT=Development  # Windows CMD
   $env:ASPNETCORE_ENVIRONMENT="Development"  # Windows PowerShell
   export ASPNETCORE_ENVIRONMENT=Development  # Linux/macOS
   ```

2. Production (uses `appsettings.json`):
   ```bash
   set ASPNETCORE_ENVIRONMENT=Production  # Windows CMD
   $env:ASPNETCORE_ENVIRONMENT="Production"  # Windows PowerShell
   export ASPNETCORE_ENVIRONMENT=Production  # Linux/macOS
   ```

### Build Configuration

1. Command Line:

   ```bash
   dotnet build --configuration Release  # Uses Production settings
   dotnet build --configuration Debug    # Uses Development settings
   ```

2. Visual Studio:
   - Debug mode: Uses `appsettings.Development.json`
   - Release mode: Uses `appsettings.json`

### Publishing with Specific Configuration

```bash
# Publish with Release configuration (Production)
dotnet publish --configuration Release --output ./publish

# Publish with specific environment
dotnet publish --configuration Release /p:EnvironmentName=Staging --output ./publish
```

### Configuration Precedence

1. Environment Variables
2. appsettings.{Environment}.json
3. appsettings.json
4. Default values in code

### Best Practices

1. Keep sensitive data in:
   - User Secrets (Development)
   - Azure Key Vault (Production)
   - Environment Variables
2. Version control:
   - Commit `appsettings.json` with default values
   - Ignore `appsettings.Development.json`
   - Ignore `appsettings.Production.json`

## Security Note

For production deployment:

1. Never commit sensitive data to source control
2. Use secure secret management solutions
3. Consider using Azure Key Vault or similar services
4. Use environment variables for sensitive configuration in production

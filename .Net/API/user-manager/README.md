# User Manager - Full Stack Application

A modern full-stack application built with **ASP.NET Core Web API** and **React TypeScript**.

## 🚀 Features

- **User Management**: Complete CRUD operations for users
- **Modern UI**: React TypeScript frontend with Material-UI components
- **RESTful API**: ASP.NET Core Web API backend
- **Real-time Updates**: Responsive UI with instant feedback
- **Type Safety**: End-to-end TypeScript for better development experience
- **Swagger Documentation**: Interactive API documentation

## 🛠️ Technology Stack

### Backend
- **ASP.NET Core 9.0** - Web API framework
- **C#** - Primary backend language
- **Swagger/OpenAPI** - API documentation
- **Dependency Injection** - Built-in IoC container

### Frontend
- **React 18** - Frontend framework
- **TypeScript** - Type-safe JavaScript
- **Material-UI (MUI)** - React component library
- **React Router** - Client-side routing
- **Axios** - HTTP client for API calls

## 📁 Project Structure

```
user-manager/
├── Controllers/              # API Controllers
│   └── UsersController.cs   # User management endpoints
├── Models/                  # Data models
│   └── User.cs             # User entity
├── Repositories/           # Data access layer
│   ├── IUserRepository.cs  # Repository interface
│   └── UserRepository.cs   # Repository implementation
├── frontend/               # React TypeScript frontend
│   ├── src/
│   │   ├── components/     # React components
│   │   │   ├── Header.tsx
│   │   │   ├── Dashboard.tsx
│   │   │   ├── UserManagement.tsx
│   │   │   └── About.tsx
│   │   ├── services/       # API service layer
│   │   │   └── userService.ts
│   │   ├── types/          # TypeScript type definitions
│   │   │   └── User.ts
│   │   └── App.tsx         # Main React component
│   └── package.json        # Frontend dependencies
├── Program.cs              # Application entry point
├── user-manager.csproj     # Project file
└── package.json           # Full-stack scripts
```

## 🚀 Getting Started

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org/)
- [npm](https://www.npmjs.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd user-manager
   ```

2. **Install frontend dependencies**
   ```bash
   npm run install:frontend
   ```

3. **Install concurrently for running both servers**
   ```bash
   npm install
   ```

### Running the Application

#### Option 1: Run Both Servers Together (Recommended)
```bash
npm run dev
```
This will start both the API server (localhost:5226) and React frontend (localhost:3000).

#### Option 2: Run Servers Separately

**Terminal 1 - API Server:**
```bash
npm run start:api
# or
dotnet run
```

**Terminal 2 - Frontend Server:**
```bash
npm run start:frontend
# or
cd frontend && npm start
```

### Building for Production

```bash
# Build both API and frontend
npm run build

# Or build separately
npm run build:api
npm run build:frontend
```

## 📱 Usage

1. **Access the Application**
   - Frontend: http://localhost:3000
   - API: http://localhost:5226
   - Swagger UI: http://localhost:5226/swagger

2. **Navigate the Application**
   - **Dashboard**: Overview and statistics
   - **Users**: Manage users (Create, Read, Update, Delete)
   - **About**: Project information

3. **User Management Features**
   - View all users in a table format
   - Add new users with the "Add User" button
   - Edit existing users by clicking the edit icon
   - Delete users with confirmation dialog
   - Real-time feedback with success/error messages

## 🔧 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/users` | Get all users |
| GET | `/api/users/{id}` | Get user by ID |
| POST | `/api/users` | Create new user |
| PUT | `/api/users/{id}` | Update user |
| DELETE | `/api/users/{id}` | Delete user |

### Example API Usage

```bash
# Get all users
curl -X GET "http://localhost:5226/api/users"

# Create a new user
curl -X POST "http://localhost:5226/api/users" \
  -H "Content-Type: application/json" \
  -d '{"name": "John Doe"}'

# Update a user
curl -X PUT "http://localhost:5226/api/users/1" \
  -H "Content-Type: application/json" \
  -d '{"id": 1, "name": "Jane Doe"}'

# Delete a user
curl -X DELETE "http://localhost:5226/api/users/1"
```

## 🎨 UI Components

### Dashboard
- User statistics cards
- Welcome message
- Growth metrics

### User Management
- Data table with user information
- Add/Edit user dialog
- Delete confirmation
- Success/Error notifications

### Header Navigation
- Responsive navigation bar
- Active page highlighting
- Consistent branding

## 🔒 CORS Configuration

The API is configured to accept requests from the React frontend running on `http://localhost:3000`. To modify this for production, update the CORS policy in `Program.cs`.

## 🐛 Troubleshooting

### Common Issues

1. **API not accessible from frontend**
   - Ensure CORS is properly configured
   - Check that API is running on localhost:5226
   - Verify firewall settings

2. **Frontend build errors**
   - Run `npm install` in the frontend directory
   - Check Node.js version compatibility
   - Clear npm cache: `npm cache clean --force`

3. **Port conflicts**
   - API default port: 5226 (configurable in launchSettings.json)
   - Frontend default port: 3000 (configurable in package.json)

## 📈 Future Enhancements

- [ ] Database integration (Entity Framework Core)
- [ ] User authentication and authorization
- [ ] Pagination for large user lists
- [ ] Advanced filtering and search
- [ ] User profile images
- [ ] Export functionality
- [ ] Dark mode support
- [ ] Mobile responsive improvements

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License.

## 👨‍💻 Author

Created as a learning project demonstrating modern full-stack development practices.
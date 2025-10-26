import React from 'react';
import {
  Container,
  Typography,
  Card,
  CardContent,
  Box,
  Chip,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
} from '@mui/material';
import {
  Code as CodeIcon,
  Api as ApiIcon,
  Web as WebIcon,
  Security as SecurityIcon,
} from '@mui/icons-material';

const About: React.FC = () => {
  const features = [
    {
      icon: <ApiIcon />,
      title: 'ASP.NET Core Web API',
      description: 'RESTful API built with .NET 9 and Entity Framework',
    },
    {
      icon: <WebIcon />,
      title: 'React TypeScript Frontend',
      description: 'Modern React app with TypeScript and Material-UI',
    },
    {
      icon: <CodeIcon />,
      title: 'Full CRUD Operations',
      description: 'Create, Read, Update, and Delete user operations',
    },
    {
      icon: <SecurityIcon />,
      title: 'Type Safety',
      description: 'End-to-end type safety with TypeScript',
    },
  ];

  const technologies = [
    { name: 'ASP.NET Core', category: 'Backend' },
    { name: 'React', category: 'Frontend' },
    { name: 'TypeScript', category: 'Language' },
    { name: 'Material-UI', category: 'UI Framework' },
    { name: 'Axios', category: 'HTTP Client' },
    { name: 'React Router', category: 'Navigation' },
  ];

  return (
    <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
      <Typography variant="h4" component="h1" gutterBottom>
        About User Manager
      </Typography>

      <Card sx={{ mb: 4 }}>
        <CardContent>
          <Typography variant="h6" gutterBottom>
            Project Overview
          </Typography>
          <Typography variant="body1" paragraph>
            This is a full-stack application demonstrating modern web development practices.
            It features a React TypeScript frontend communicating with an ASP.NET Core Web API backend.
            The application provides user management functionality with a clean, responsive interface.
          </Typography>
          <Typography variant="body1">
            The project showcases best practices in both frontend and backend development,
            including proper separation of concerns, type safety, and modern UI/UX patterns.
          </Typography>
        </CardContent>
      </Card>

      <Card sx={{ mb: 4 }}>
        <CardContent>
          <Typography variant="h6" gutterBottom>
            Key Features
          </Typography>
          <List>
            {features.map((feature, index) => (
              <ListItem key={index}>
                <ListItemIcon>{feature.icon}</ListItemIcon>
                <ListItemText
                  primary={feature.title}
                  secondary={feature.description}
                />
              </ListItem>
            ))}
          </List>
        </CardContent>
      </Card>

      <Card>
        <CardContent>
          <Typography variant="h6" gutterBottom>
            Technologies Used
          </Typography>
          <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 1 }}>
            {technologies.map((tech) => (
              <Chip
                key={tech.name}
                label={`${tech.name} (${tech.category})`}
                variant="outlined"
                color="primary"
              />
            ))}
          </Box>
        </CardContent>
      </Card>
    </Container>
  );
};

export default About;
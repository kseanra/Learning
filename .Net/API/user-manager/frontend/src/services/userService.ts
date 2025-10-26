import axios from 'axios';
import { User, CreateUserRequest, UpdateUserRequest } from '../types/User';

const API_BASE_URL = 'http://localhost:5226/api';

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

export const userService = {
  // Get all users
  getAllUsers: async (): Promise<User[]> => {
    const response = await api.get<User[]>('/users');
    return response.data;
  },

  // Get user by ID
  getUserById: async (id: number): Promise<User> => {
    const response = await api.get<User>(`/users/${id}`);
    return response.data;
  },

  // Create new user
  createUser: async (user: CreateUserRequest): Promise<User> => {
    const response = await api.post<User>('/users', user);
    return response.data;
  },

  // Update user
  updateUser: async (user: UpdateUserRequest): Promise<User> => {
    const response = await api.put<User>(`/users/${user.id}`, user);
    return response.data;
  },

  // Delete user
  deleteUser: async (id: number): Promise<void> => {
    await api.delete(`/users/${id}`);
  },
};

export default api;
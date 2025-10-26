export interface User {
  id: number;
  name: string;
}

export interface CreateUserRequest {
  name: string;
}

export interface UpdateUserRequest {
  id: number;
  name: string;
}
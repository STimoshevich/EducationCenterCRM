export interface RegistrationModel {
  email: string;
  password: string;
  lastname: string;
  phone: string;
  birthdate: Date;
}
export interface LoginModel {
  email: string;
  password: string;
}
export interface AuthentificationResult {
  Success: boolean;
  token: string;
  refreshToken: string;
  Erorrs: string[];
}
export interface Tokens {
  token: string;
  refreshToken: string;
}
export interface RequestErrors {
  key: string;
  errors: string[];
}
export interface User {
  id: string;
  fullName: string;
  email: string;
  phoneNumber: string;
  roles: string[];
}

export interface UserFilter {
  roleId: number;
}

export interface RoleNameWithId {
  id: string;
  name: string;
}

export interface UserList {
  users: User[];
  usersAmount: number;
}

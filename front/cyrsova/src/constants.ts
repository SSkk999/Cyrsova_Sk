import Login from "./pages/Auth/RegistrPage";

export const HEADER_ROUTES = {
  HOME: '/',
  TESTS: '/tests',
  SUBSCRIPTION: '/subscription',
  LOGIN: '/login',
  REGISTER: '/register',
  PROFILE: '/profile',
  COMMENTS: '/comments',
  LOGIKA: '/tests/logic',
  SPEED: '/tests/speed',
  MEMORY:'/tests/memory',
  FOCUS: '/tests/focus',
  MyTests: '/tests/my-tests',
  AddTest : '/tests/add-test',
  AdminPanel: '/admin',
  Reneme: '/rename',
  RenemeTest: '/tests/rename/:id', 

} as const;

export const CRYSTALS_API_URL = '/api/crystals';

export const AUTH_STORAGE_KEY = 'testflow_auth_user';

export const ROLE = Object.freeze({
  USER: 0,
  ADMIN: 1,
});
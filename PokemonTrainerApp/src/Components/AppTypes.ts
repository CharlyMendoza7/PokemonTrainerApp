export type RegisterModel = {
    userName: string;
    passwordHash: string;
    email: string;
    birth: string;
    firstName: string | null;
    lastName: string | null;
    gender: string | null;
}
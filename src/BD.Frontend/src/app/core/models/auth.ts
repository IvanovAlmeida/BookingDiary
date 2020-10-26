export class Auth {
    email: string;
    password: string;
    accessToken: string;
    expiresIn: number;
    userToken: AuthToken;
}

export class AuthToken {
    id: number;
    email: string;
    claims: AuthClaim[];
}

export class AuthClaim {
    id: number;
    type: string;
    value: string;
    
    roleId: number;
    claimType: string;
    claimValue: string;
}
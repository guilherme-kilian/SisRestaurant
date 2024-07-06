class AuthenticationResult{
    userId: string
    authorizationToken: string

    constructor(userId: string, authorizationToken: string){
        this.userId = userId;
        this.authorizationToken = authorizationToken;
    }
}

export default AuthenticationResult;

class CreateUserModel{
    fullName: string
    userName: string
    email: string
    password: string

    constructor(fullName: string, userName: string, email: string, password: string){
        this.fullName = fullName;
        this.userName = userName;
        this.email = email;
        this.password = password;
    }
}

export default CreateUserModel
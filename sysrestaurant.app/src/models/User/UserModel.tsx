export class UserModel{
    id: string
    email: string
    userName: string
    name: string
    
    constructor(id: string, email: string, userName: string, name: string){
        this.id = id;
        this.email = email;
        this.userName = userName;
        this.name = name;
    }
}
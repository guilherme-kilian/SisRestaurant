export class ShortRestaurantModel{
    id: number;
    name: string;
    open: boolean;
    email: string;
    phoneNumber: string;
    picture: string;
    description: string;

    constructor (id: number, name: string, open: boolean, email: string, phoneNumber: string, picture:string, description: string){
        this.id = id;
        this.name = name;
        this.open = open;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.picture = picture;
        this.description = description;
    }
}


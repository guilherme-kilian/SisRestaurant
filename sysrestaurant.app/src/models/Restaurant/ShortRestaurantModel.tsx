export class ShortRestaurantModel{
    id: number;
    name: string;
    open: boolean;
    email: string;
    phoneNumber: string;
    picture: string;

    constructor (id: number, name: string, open: boolean, email: string, phoneNumber: string, picture:string){
        this.id = id;
        this.name = name;
        this.open = open;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.picture = picture;
    }
}


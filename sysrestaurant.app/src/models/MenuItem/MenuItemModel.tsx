export class MenuItemModel {
    id: number
    name: string
    price: number
    categoryName: string
    picture: string | null
    description: string

    constructor (id: number, name: string, price: number, categoryName: string, picture: string | null, description: string){    
        this.id = id;
        this.name = name;
        this.price = price;
        this.categoryName = categoryName;
        this.picture = picture;
        this.description = description;
    }
}
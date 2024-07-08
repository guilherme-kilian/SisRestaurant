export class CreateMenuItemModel{
    name: string
    product: string
    price: number
    categoryName: string
    description: string
    picture: string

    constructor(name: string, product: string, price: number, categoryName: string, picture: string, description: string){
        this.name = name;
        this.product = product;
        this.price = price;
        this.categoryName = categoryName;
        this.picture = picture;
        this.description = description;
    }
}
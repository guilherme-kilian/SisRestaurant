export class CreateMenuItemModel{
    name: string
    product: string
    price: number
    categoryName: string

    constructor(name: string, product: string, price: number, categoryName: string){
        this.name = name;
        this.product = product;
        this.price = price;
        this.categoryName = categoryName;
    }
}
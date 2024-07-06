import { CreateMenuItemModel } from "../MenuItem/CreateMenuItemModel"

export class CreateMenuModel{
    name: string
    restaurantId: string
    items: CreateMenuItemModel[]

    constructor(name: string, restaurantId: string, items: CreateMenuItemModel[]){
        this.name = name;
        this.restaurantId = restaurantId;
        this.items = items;
    }
}
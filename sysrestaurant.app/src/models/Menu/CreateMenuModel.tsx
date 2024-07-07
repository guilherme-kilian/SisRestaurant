import { CreateMenuItemModel } from "../MenuItem/CreateMenuItemModel"

export class CreateMenuModel{
    name: string
    restaurantId: number
    items: CreateMenuItemModel[] | null

    constructor(name: string, restaurantId: number, items: CreateMenuItemModel[] | null){
        this.name = name;
        this.restaurantId = restaurantId;
        this.items = items;
    }
}
import { MenuItemModel } from "../MenuItem/MenuItemModel"

export class MenuModel{
    id: number
    name: string 
    items: MenuItemModel[]

    constructor(id: number, name: string, items: MenuItemModel[]){
        this.id = id;
        this.name = name;
        this.items = items;
    }
}
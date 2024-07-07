import { MenuModel } from "../Menu/MenuModel"
import { ReservationModel } from "../Reservation/ReservationModel"
import { UserModel } from "../User/UserModel"

export class RestaurantModel {
    id: number
    name: string
    email: string
    phoneNumber: string
    menus: MenuModel[]
    settings: ReservationSettingsModel
    reservations: ReservationModel[]
    users: UserModel[]
    open: boolean
    picture: string
    
    constructor (id: number, name: string, email: string, phoneNumber: string, menus: MenuModel[], settings: ReservationSettingsModel, reservations: ReservationModel[], users: UserModel[], open: boolean, picture: string){
        this.id = id;
        this.name = name;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.menus = menus;
        this.settings = settings;
        this.reservations = reservations;
        this.users = users;
        this.open = open;
        this.picture = picture;
    }
}

export class ReservationSettingsModel {
    id: number
    capacity: number
    finishAt: string
    startAt: string
    paymentRequired: boolean

    constructor(id: number, capacity: number, finishAt: string, startAt: string, paymentRequired: boolean){
        this.id = id;
        this.capacity = capacity;
        this.finishAt = finishAt;
        this.startAt = startAt;
        this.paymentRequired = paymentRequired;
    }
}


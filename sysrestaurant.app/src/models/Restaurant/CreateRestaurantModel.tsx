export class CreateRestaurantModel{
    name: string
    phoneNumber: string
    email: string
    settings: CreateReservationSettingsModel
    picture: string
    details: string

    constructor (name: string, phoneNumber: string, email: string, settings: CreateReservationSettingsModel, picture: string, details: string){
        this.name = name;
        this.phoneNumber = phoneNumber;
        this.email = email;
        this.settings = settings;
        this.picture = picture;
        this.details = details;
    }
}

export class CreateReservationSettingsModel{
    paymentRequired: boolean
    capacity: number
    startAt: string
    finishAt: string

    constructor (paymentRequired: boolean, capacity: number, startAt: string, finishAt: string){
        this.paymentRequired = paymentRequired;
        this.capacity = capacity;
        this.startAt = startAt;
        this.finishAt = finishAt;
    }
}
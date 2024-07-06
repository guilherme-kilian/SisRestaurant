export class CreateRestaurantModel{
    name: string
    phoneNumber: string
    email: string
    settings: CreateReservationSettingsModel

    constructor (name: string, phoneNumber: string, email: string, settings: CreateReservationSettingsModel){
        this.name = name;
        this.phoneNumber = phoneNumber;
        this.email = email;
        this.settings = settings;
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
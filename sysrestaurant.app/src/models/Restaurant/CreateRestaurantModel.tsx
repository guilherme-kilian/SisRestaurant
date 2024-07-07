export class CreateRestaurantModel{
    name: string
    phoneNumber: string
    email: string
    settings: CreateReservationSettingsModel
    picture: string
    description: string

    constructor (name: string, phoneNumber: string, email: string, settings: CreateReservationSettingsModel, picture: string, details: string){
        this.name = name;
        this.phoneNumber = phoneNumber;
        this.email = email;
        this.settings = settings;
        this.picture = picture;
        this.description = details;
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
        this.startAt = this.setTime(startAt);
        this.finishAt = this.setTime(finishAt);
    }

    setTime(time: string) : string {
        if(time.length === 5){
            return time  + ":00";
        }
        return time;
    }
}
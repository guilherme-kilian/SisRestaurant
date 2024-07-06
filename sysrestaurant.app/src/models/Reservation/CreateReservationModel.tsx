export class CreateReservationModel {
    restaurantId: number
    date: Date
    count: number
    details: string | null

    constructor(restaurantId: number, date: Date, count: number, details: string | null
    ){
        this.restaurantId = restaurantId;
        this.date = date;
        this.count = count;
        this.details = details;
    }
}
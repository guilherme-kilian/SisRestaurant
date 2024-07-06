export class ReservationModel {
    id: number
    date: Date
    count: number
    details: string | null

    constructor(id: number, date: Date, count: number, details: string | null){
        this.id = id;
        this.date = date;
        this.count = count;
        this.details = details;
    }
}
export class FilterRestaurantModel {
    name: string | null
    category: string | null
    open: boolean | null

    constructor (name: string | null, category: string | null, open: boolean | null){
        this.name = name;
        this.category = category;
        this.open = open;
    }

    getQueryString() : string{

        if(!this.name && !this.category && !this.open){
            return "";
        }

        let queryString = "?";
        
        if(this.name){
            queryString += `name=${this.name}&`
        }
        if(this.category){
            queryString += `category=${this.category}&`
        }
        if(this.open){
            queryString += `open=${this.open}&`
        }
        
        return queryString;
    }
}